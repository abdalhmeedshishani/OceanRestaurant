using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OceanRestaurant.Dtos.Orders;
using OceanRestaurant.EF.Core;
using OceanRestaurant.Entites;
using System.Net;
using System;

namespace OceanRestaurant.Api.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        #region Data and Const
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ApplicationDbContext context, IMapper mapper, ILogger<OrdersController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Actions

        [HttpGet]
        public async Task<ActionResult<List<OrderListDto>>> GetOrders()
        {
            var orders = await _context.Orders
                                      .Include(d => d.Dishes)
                                      .ToListAsync();


            var orderListDto = _mapper.Map<List<OrderListDto>>(orders);

            //TODO set the total price 

            return orderListDto;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailsDto>> GetOrder(int id)
        {
            var order = await _context.Orders
                                      .Include(d => d.Dishes)
                                      .Include(d => d.Guest)
                                      .SingleOrDefaultAsync(d => d.Id == id);


            if (order == null)
            {
                return NotFound();
            }

            var orderDetailsDto = _mapper.Map<OrderDetailsDto>(order);

            return orderDetailsDto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetEditOrder(int id)
        {
            var order = await _context.Orders
                                      .Include(d => d.Dishes)
                                      .Where(d => d.Id == id)
                                      .SingleOrDefaultAsync();

            if (order == null)
            {
                return NotFound();
            }

            var orderDto = _mapper.Map<OrderDto>(order);

            orderDto.DishIds =  order.Dishes.Select(d => d.Id).ToList();


            return orderDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditOrder(int id, OrderDto orderDto)
        {
            if (id != orderDto.Id)
            {
                return BadRequest();
            }

            var order = _mapper.Map<Order>(orderDto);

            try
            {
                _context.Orders.Update(order);
                await UpdateDishInOrder(orderDto.DishIds, id);
                order.OrderDate = DateTime.Now;
                order.TotalPrice = await CalculateTotalePrice(orderDto.DishIds);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {

                    throw new DbUpdateException($"Couldn't update guest ID=[{id}]", ex);

                }
            }

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);

            order.OrderDate = DateTime.Now;
     
            await AddDishToOrder(orderDto.DishIds, order);

            order.TotalPrice = await CalculateTotalePrice(orderDto.DishIds);

            _logger.LogInformation("Ordered this dish...");

            _context.Add(order);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var orderDto = _mapper.Map<Order>(order);

            _context.Orders.Remove(orderDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost]
        public async Task<double> GetOrderTotalPrice(List<int> dishIds)
        {
            var dishesTotalPrice = await _context
                                    .Dishes
                                    .Where(d => dishIds.Contains(d.Id)) // 1,2 == Salmon, Tuna
                                    .SumAsync(d => d.Price);

            return dishesTotalPrice;
        }

        #endregion        

        #region Private Methods
        private async Task AddDishToOrder(List<int> DishIds, Order order)
        {
            var dishes = await _context.Dishes
                                              .Where(d => DishIds.Contains(d.Id))
                                              .ToListAsync();
            if (dishes.Any())
            {
                order.Dishes.AddRange(dishes);
            }
        }

        private async Task UpdateDishInOrder(List<int> DishIds, int orderId)
        {

            var order = await _context.Orders
                                   .Include(d => d.Dishes)
                                   .Where(d => d.Id == orderId)
                                   .SingleAsync();
            order.Dishes.Clear();

            var dishes = await _context.Dishes
                                             .Where(d => DishIds.Contains(d.Id))
                                             .ToListAsync();

            
            if (dishes.Any())
            {
                order.Dishes.AddRange(dishes);
            }
        }


        private async Task<double> CalculateTotalePrice(List<int> dishIds)
        {

            var dishesPrices = await _context.Dishes
                                                .Where(d => dishIds.Contains(d.Id))
                                                .Select(d => d.Price)
                                                .ToListAsync();
            return dishesPrices.Sum();

        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        } 
        #endregion





    }
}