using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OceanRestaurant.Dtos.Dishes;
using OceanRestaurant.EF.Core;
using OceanRestaurant.Entites;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace OceanRestaurant.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DishesController : ControllerBase
    {


        #region Data and Const
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<OrdersController> _logger;
        private readonly IValidator<DishDto> _validator;

        public DishesController(ApplicationDbContext context, IMapper mapper, ILogger<OrdersController> logger, IValidator<DishDto> validator)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }
        #endregion

        #region Actions

        [HttpGet]
        public async Task<List<DishListDto>> GetDishes()
        {
            var dishes = await _context.Dishes.ToListAsync();

            var dishesDto = _mapper.Map<List<DishListDto>>(dishes);

            return dishesDto;


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DishDetailsDto>> GetDish(int id)
        {
            var dish = await _context.Dishes.FindAsync(id);


            if (dish == null)
            {
                return NotFound();
            }

            var dishDto = _mapper.Map<DishDetailsDto>(dish);

            return dishDto;




        }

        [HttpPost]
        public async Task<IActionResult> CreateDish([FromBody] DishDto dishDto)
        {
            ValidationResult result = await _validator.ValidateAsync(dishDto);

            if (result.IsValid)
            {
                var dish = _mapper.Map<Dish>(dishDto);

                _context.Dishes.Add(dish);
                await _context.SaveChangesAsync();

                return Ok();
            }

            return BadRequest(new Exception($"{result}"));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DishDto>> EditDish(int id, [FromBody] DishDto dishDto)
        {

            if (id != dishDto.Id)
            {
                return BadRequest();
            }

                var dish = _mapper.Map<Dish>(dishDto);

            _context.Entry(dish).State = EntityState.Modified;

            try
            {


                _context.Dishes.Update(dish);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!DishExists(id))
                {
                    return NotFound();
                }
                else
                {

                    throw new DbUpdateException($"Couldn't update guest ID=[{id}]", ex);

                }
            }

            return NoContent();


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDish(int id)
        {

            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }

            var dishDto = _mapper.Map<Dish>(dish);

            _context.Dishes.Remove(dishDto);
            await _context.SaveChangesAsync();

            return NoContent();


        }

       

        #endregion

        #region Private Methods

        private bool DishExists(int id)
        {
            return _context.Dishes.Any(e => e.Id == id);

        }

        #endregion

    }
}
