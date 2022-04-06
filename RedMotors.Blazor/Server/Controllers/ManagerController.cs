using Microsoft.AspNetCore.Mvc;
using RedMotors.Database.Repository;
using RedMotors.Entities;

namespace RedMotors.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[managercontroller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IEntityRepo<Manager> _managerRepo;
        public ManagerController(IEntityRepo<Manager> managerRepo)
        {
            _managerRepo = managerRepo;
        }
    }
}
