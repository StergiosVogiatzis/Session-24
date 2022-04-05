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
                Code = task.Code,
                Description = task.Description,
                Hours = task.Hours,
            });
        }

        [HttpPost]
        public async Task Post(ServiceTaskListViewModel serviceTask)
        {
            var newServiceTask = new ServiceTask();
            newServiceTask.Code = serviceTask.Code;
            newServiceTask.Description = serviceTask.Description;
            newServiceTask.Hours = Convert.ToDecimal(serviceTask.Hours);
            await _serviceTaskRepo.AddAsync(newServiceTask);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _serviceTaskRepo.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(ServiceTaskListViewModel serviceTask)
        {
            var itemToUpdate = await _serviceTaskRepo.GetByIdAsync(serviceTask.Id);
            if (itemToUpdate == null) return NotFound();
            //TODO: This i Dont Like Maybe this should not excist
            //if (serviceTask.Code != itemToUpdate.Code ||
            //    serviceTask.Description != itemToUpdate.Description ||
            //    serviceTask.Hours != itemToUpdate.Hours)
            //{
            //    itemToUpdate.Code = serviceTask.Code;
            //    itemToUpdate.Description = serviceTask.Description;
            //    itemToUpdate.Hours = Convert.ToDecimal(serviceTask.Hours);
            //}
            itemToUpdate.Code = serviceTask.Code;
            itemToUpdate.Description = serviceTask.Description;
            itemToUpdate.Hours = Convert.ToDecimal(serviceTask.Hours);
            await _serviceTaskRepo.UpdateAsync(serviceTask.Id, itemToUpdate);
            return Ok();
        }
    }
}
