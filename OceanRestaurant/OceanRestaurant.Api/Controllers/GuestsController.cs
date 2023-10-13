using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OceanRestaurant.Dtos.Guests;
using OceanRestaurant.Dtos.Uploaders;
using OceanRestaurant.EF.Core;
using OceanRestaurant.Entites;


namespace OceanRestaurant.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        #region Data and Const
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<GuestDto> _validator;

        public GuestsController(ApplicationDbContext context, IMapper mapper, IValidator<GuestDto> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        } 
        #endregion


        #region Actions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestListDto>>> GetGuests()
        {
            var guests = await _context.Guests.ToListAsync();

            var guestsDto = _mapper.Map<List<Guest>, List<GuestListDto>>(guests);


            return guestsDto;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GuestDetailsDto>>GetGuest(int id)
        {
            var guest = await _context.Guests
                                       .Include(d => d.Images)
                                       .SingleOrDefaultAsync(d => d.Id == id);


            if (guest == null)
            {
                return NotFound();
            }

            var guestDto = _mapper.Map<GuestDetailsDto>(guest);

            return guestDto;
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> EditGuest(int id, GuestDto guestDto)
        {
            if (id != guestDto.Id)
            {
                return BadRequest();
            }

            var guest = _mapper.Map<Guest>(guestDto);

            _context.Guests.Update(guest);
            await _context.SaveChangesAsync();


           await UpdateGuestImage(guestDto.Images, id);

           await _context.SaveChangesAsync();


            try
            {
                _context.Guests.Update(guest);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DbUpdateException($"Couldn't update guest ID=[{id}]", ex);
            }

            return Ok();

        }


        [HttpPost]
        public async Task<ActionResult<GuestDto>> CreateGuest(GuestDto guestDto)
        {

            ValidationResult result = await _validator.ValidateAsync(guestDto);


            if (result.IsValid)
            {



                var guest = _mapper.Map<Guest>(guestDto);



                _context.Guests.Add(guest);
                await _context.SaveChangesAsync();

                var guestDtoToReturn = _mapper.Map<GuestDto>(guest);

                return guestDtoToReturn;
            }

            return BadRequest(new Exception($"{result}"));


        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }

            var guestDto = _mapper.Map<Guest>(guest);

            _context.Guests.Remove(guestDto);
            await _context.SaveChangesAsync();

            return Ok();
        }
        #endregion

        #region Private
        private async Task UpdateGuestImage(List<UploaderImageDto> images, int id)
        {
            var guest = await _context.Guests.Include(c => c.Images).SingleAsync(c => c.Id == id);
            guest.Images.Clear();

            var guestImages = _mapper.Map<List<UploaderImageDto>, List<GuestImage>>(images);

            guest.Images.AddRange(guestImages);
        }
        #endregion


    }
} 
