using Microsoft.AspNetCore.Mvc;
using RedMotors.Blazor.Shared;
using RedMotors.Database.Repository;
using RedMotors.Entities;

namespace RedMotors.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EngineerController : ControllerBase
    {
        private readonly IEntityRepo<Engineer> _engineerRepo;
        public EngineerController(IEntityRepo<Engineer> engineerRepo)
        {
            _engineerRepo = engineerRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<EngineerListViewModel>> GetEngineer()
        {
            var engineerResult = await _engineerRepo.GetAllAsync();
            return engineerResult.Select(engineer => new EngineerListViewModel
            {
                Id = engineer.Id,
                Name = engineer.Name,
                Surname = engineer.Surname,
                SalaryPerMonth = engineer.SalaryPerMonth,

            });

        }
        [HttpPost]
        public async Task PostEngineer(EngineerListViewModel engineer)
        {
            var newEngineer = new Engineer();

            newEngineer.Id = engineer.Id;
            newEngineer.Name = engineer.Name;
            newEngineer.Surname = engineer.Surname;
            newEngineer.SalaryPerMonth = engineer.SalaryPerMonth;
            await _engineerRepo.AddAsync(newEngineer);
        }

    }
}
