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
        [HttpGet("{Id}")]
        public async Task<EngineerEditViewModel> Get(Guid Id)
        {
            EngineerEditViewModel viewModel = new EngineerEditViewModel();
            if (Id != Guid.Empty)
            {
                var existing = await _managerRepo.GetByIdAsync(Id);
                viewModel.Id = existing.Id;
                viewModel.Name = existing.Name;
                viewModel.Surname = existing.Surname;
                viewModel.SalaryPerMonth = existing.SalaryPerMonth;
            }
            var manager = await _managerRepo.GetAllAsync();
            viewModel.Managers = manager.Select(x => new ManagerEditViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
            }).ToList();
            return viewModel;

        }
        [HttpPost]
        public async Task Post(EngineerListViewModel engineer)
        {
            var newEngineer = new Engineer {

                Id = engineer.Id,
                Name = engineer.Name,
                Surname = engineer.Surname,
                SalaryPerMonth = engineer.SalaryPerMonth,
                ManagerId = engineer.ManagerId,
            };
            foreach (var manager in engineer.Managers)
            {
                newEngineer.Managers.Add(new Manager()
                {

                });
            }
            await _engineerRepo.AddAsync(newEngineer);
        }

        [HttpDelete("{ID}")]
        public async Task DeleteEngineer(Guid id)
        {
            await _engineerRepo.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EngineerEditViewModel engineer)
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
