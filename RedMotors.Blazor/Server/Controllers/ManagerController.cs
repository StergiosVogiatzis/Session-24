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
        [HttpPost]
        public async Task PostManager(ManagerListViewModel manager)
        {
            var newManager = new Manager();

            newManager.Id = manager.Id;
            newManager.Name = manager.Name;
            newManager.Surname = manager.Surname;
            newManager.SalaryPerMonth = manager.SalaryPerMonth;
            await _managerRepo.AddAsync(newManager);
        }

    }
}
