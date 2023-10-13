using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OceanRestaurant.Api.Controllers;
using OceanRestaurant.Dtos.Guests;
using OceanRestaurant.EF.Core;
using OceanRestaurant.Entites;

namespace OceanRestaurant.Tests.GuestTest
{
    public class GuestsControllerTest 
    {

        #region Data and Const
        
        private readonly IMapper _mapper;
        private readonly IValidator<GuestDto> _validator;

        public GuestsControllerTest()
        {
            _mapper = A.Fake<IMapper>();
            _validator = A.Fake<IValidator<GuestDto>>();
        }
        #endregion


        private async Task<ApplicationDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().
                            UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).
                            Options;

            var databaseContext = new ApplicationDbContext(options);
             databaseContext.Database.EnsureCreated();

            if (await databaseContext.Guests.CountAsync() <= 0) 
            {
                
                    databaseContext.Guests.Add(
                        new Guest()
                        {
                            Id = 3,
                            Name = "Mobss"
                        }


                        ); 
                
                await databaseContext.SaveChangesAsync();
            }

            return databaseContext;
        }

        [Fact]
        public async void GuestsController_GetGuest_ReturnGuestRightIdAndName()
        {
            //Arrange
            int id = 3;
            var dbContext = await GetDatabaseContext();
            var geustController = new GuestsController(dbContext, _mapper, _validator);
            var product = dbContext.Guests.Find(3);
            //Act
            var result = await geustController.GetGuest(id);

            //Assert
            result.Should().Match<Guest>(d =>  d.Name == "Mobss" && d.Id == id );

        }


    /*    [Fact]
        public void GuestsController_GetGuests_ReturnOk()
        {
            //Arrange

            int id = 2;
            var guest = A.Fake<Guest>();
            var guestDto = A.Fake<GuestDto>();
            var guestsListDto = A.Fake<List<GuestDto>>();
            A.CallTo(() => _mapper.Map<GuestDto>(guestDto)).Returns(guestDto);
            var guestController = new GuestsController(_context, _mapper, _validator);

            //Act
            var results = guestController.EditGuest(id , guestDto);

            //Assert
            results.Should().BeOfType(typeof(Task<IActionResult>));
        }*/



    }
}
