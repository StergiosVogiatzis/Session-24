using Microsoft.AspNetCore.Mvc;
using RedMotors.Blazor.Shared;
using RedMotors.Database.Repository;
using RedMotors.Entities;

namespace RedMotors.Blazor.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ServiceTaskController : ControllerBase
    {
        private readonly IEntityRepo<ServiceTask> _serviceTaskRepo;

        public ServiceTaskController(IEntityRepo<ServiceTask> serviceTaskRepo)
        {
            _serviceTaskRepo = serviceTaskRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceTaskListViewModel>> Get()
        {
            var result = await _serviceTaskRepo.GetAllAsync();
            return result.Select(task => new ServiceTaskListViewModel
            {
                Id = task.Id,
                Code = task.Code,
                Description = task.Description,
                Hours = task.Hours,
            });
        }

        [HttpGet("{id}")]
        public async Task<ServiceTaskEditViewModel> Get(Guid id)
        {
            ServiceTaskEditViewModel model = new();
            if (id != Guid.Empty)
            {
                var existing = await _serviceTaskRepo.GetByIdAsync(id);
                model.Id = existing.Id;
                model.Code = existing.Code;
                model.Description = existing.Description;
                model.Hours = existing.Hours;
            }
            return model;
        }

        [HttpPost]
        public async Task Post(ServiceTaskListViewModel serviceTask)
        {
            var newServiceTask = new ServiceTask
            {
                Code = serviceTask.Code,
                Description = serviceTask.Description,
                Hours = Convert.ToDecimal(serviceTask.Hours),
            };
            await _serviceTaskRepo.AddAsync(newServiceTask);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _serviceTaskRepo.DeleteAsync(id);
        }

        ////[HttpPut]
        ////public async Task<ActionResult> Put(ServiceTaskListViewModel serviceTask)
        ////{
        ////    var itemToUpdate = await _serviceTaskRepo.GetByIdAsync(serviceTask.Id);
        ////    if (itemToUpdate == null) return NotFound();

        ////    itemToUpdate.Code = serviceTask.Code;
        ////    itemToUpdate.Description = serviceTask.Description;
        ////    itemToUpdate.Hours = Convert.ToDecimal(serviceTask.Hours);

        ////    await _serviceTaskRepo.UpdateAsync(serviceTask.Id, itemToUpdate);
        ////    return Ok();
        ////}
    }
}
