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
        private readonly IEntityRepo<Manager> _managerRepo;
        public EngineerController(IEntityRepo<Engineer> engineerRepo, IEntityRepo<Manager> managerRepo)
        {
            _engineerRepo = engineerRepo;
            _managerRepo = managerRepo;
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
                ManagerId = engineer.ManagerId,

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
            newEngineer.ManagerId = engineer.ManagerId;
            await _engineerRepo.AddAsync(newEngineer);
        }

        [HttpDelete("{ID}")]
        public async Task DeleteEngineer(Guid id)
        {
            await _engineerRepo.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EngineerListViewModel engineer)
        {
            var engineerToUpdate = await _engineerRepo.GetByIdAsync(engineer.Id);
            if (engineerToUpdate == null) return NotFound();

            engineerToUpdate.Name = engineer.Name;
            engineerToUpdate.Surname = engineer.Surname;
            engineerToUpdate.SalaryPerMonth = engineer.SalaryPerMonth;
            engineerToUpdate.ManagerId = engineer.ManagerId;
            await _engineerRepo.UpdateAsync(engineer.Id, engineerToUpdate);

            return Ok();
        }
    }
}
