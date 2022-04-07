using Microsoft.AspNetCore.Mvc;
using RedMotors.Blazor.Shared;
using RedMotors.Database.Repository;
using RedMotors.Entities;

namespace RedMotors.Blazor.Server.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IEntityRepo<Car> _carRepo;

        public CarController(IEntityRepo<Car> carRepo)
        {
            _carRepo = carRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<CarListViewModel>> Get()
        {
            var result = await _carRepo.GetAllAsync();
            return result.Select(x => new CarListViewModel
            {
                Id = x.Id,
                Brand = x.Brand,
                Model = x.Model,
                CarRegistrationNumber = x.CarRegistrationNumber
               
            });
        }
        [HttpGet("{id}")]
        public async Task<CarEditListViewModel> Get(Guid id)
        {
            CarEditListViewModel model = new();
            if (id != Guid.Empty)
            {
                var existing = await _carRepo.GetByIdAsync(id);
                model.Id = existing.Id;
                model.Brand = existing.Brand;
                model.Model = existing.Model;
                model.CarRegistrationNumber = existing.CarRegistrationNumber;
            }
            return model;
        }

        [HttpPost]
        public async Task Post(CarEditListViewModel car)
        {
            var newCar = new Car
            {
                CarRegistrationNumber=car.CarRegistrationNumber,
                Brand = car.Brand,
                Model=car.Model,
            };
            await _carRepo.AddAsync(newCar);
        }
        

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _carRepo.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(CarEditListViewModel car)
        {
            var itemToUpdate = await _carRepo.GetByIdAsync(car.Id);
            if (itemToUpdate == null) return NotFound();

            itemToUpdate.Brand = car.Brand;
            itemToUpdate.Model = car.Model;
            itemToUpdate.CarRegistrationNumber = car.CarRegistrationNumber;

            await _carRepo.UpdateAsync(car.Id, itemToUpdate);

            return Ok();
        }
    }
}

