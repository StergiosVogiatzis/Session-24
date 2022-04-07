using Microsoft.AspNetCore.Mvc;
using RedMotors.Blazor.Shared;
using RedMotors.Database.Repository;
using RedMotors.Entities;

namespace RedMotors.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IEntityRepo<Manager> _managerRepo;
        public ManagerController(IEntityRepo<Manager> managerRepo)
        {
            _managerRepo = managerRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<ManagerListViewModel>> GetManager()
        {
            var managerResult = await _managerRepo.GetAllAsync();
            return managerResult.Select(manager => new ManagerListViewModel
            {
                Id = manager.Id,
                Name = manager.Name,
                Surname = manager.Surname,
                SalaryPerMonth = manager.SalaryPerMonth,

            });

        }
        [HttpGet("{Id}")]
        public async Task<ManagerEditViewModel> Get(Guid Id)
        {
            ManagerEditViewModel viewModel = new ManagerEditViewModel();
            if (Id != Guid.Empty)
            {
                var existing = await _managerRepo.GetByIdAsync(Id);
                viewModel.Id = existing.Id;
                viewModel.Name = existing.Name;
                viewModel.Surname = existing.Surname;
                viewModel.SalaryPerMonth = existing.SalaryPerMonth;
            }
            return viewModel;

        }

        [HttpPost]
        public async Task PostManager(ManagerEditViewModel manager)
        {
            var newManager = new Manager {

               Name = manager.Name,
               Surname = manager.Surname,
               SalaryPerMonth = manager.SalaryPerMonth,
            };
            await _managerRepo.AddAsync(newManager);


        }
        [HttpDelete("{Id}")]
        public async Task Delete(Guid Id)
        {
            await _managerRepo.DeleteAsync(Id);
        }
        [HttpPut]
        public async Task<ActionResult> Put(ManagerEditViewModel manager)
        {
            var updatedManager = await _managerRepo.GetByIdAsync(manager.Id);
            if (updatedManager == null) return NotFound();
            updatedManager.Surname = manager.Surname;
            updatedManager.Name = manager.Name;
            updatedManager.SalaryPerMonth = manager.SalaryPerMonth;
            await _managerRepo.UpdateAsync(manager.Id, updatedManager);
            return Ok();
        }

    }
}
