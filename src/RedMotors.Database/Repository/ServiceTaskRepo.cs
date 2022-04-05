using RedMotors.Entities;
using Microsoft.EntityFrameworkCore;

namespace RedMotors.Database.Repository
{
    public class ServiceTaskRepo : IEntityRepo<ServiceTask>
    {
        private readonly GarageContext _context;

        public ServiceTaskRepo(GarageContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddAsync(ServiceTask entity)
        {
            AddLogic(entity,_context);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            DeleteLogic(id,_context);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ServiceTask>> GetAllAsync()
        {
            return await _context.ServiceTasks.ToListAsync();
        }

        public async Task<ServiceTask?> GetByIdAsync(Guid id)
        {
            return await _context.ServiceTasks.SingleOrDefaultAsync(serviceTask => serviceTask.Id == id);
        }

        public async Task UpdateAsync(Guid id, ServiceTask entity)
        {
            UpdateLogic(id, entity,_context);
            await _context.SaveChangesAsync();
        }


        private void AddLogic(ServiceTask entity, GarageContext context)
        {
            if (entity.Id != Guid.Empty)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));

            context.ServiceTasks.Add(entity);
        }

        private void DeleteLogic (Guid id,GarageContext context)
        {
            var dbServiceTask = context.ServiceTasks.SingleOrDefault(serviceTask => serviceTask.Id == id);
            if (dbServiceTask is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            context.ServiceTasks.Remove(dbServiceTask);
        }

        private void UpdateLogic(Guid id, ServiceTask entity,GarageContext context)
        {
            var dbServiceTask = context.ServiceTasks.SingleOrDefault(serviceTask =>serviceTask.Id == id);
            if (dbServiceTask is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            dbServiceTask.Code = entity.Code;
            dbServiceTask.Description = entity.Description;
            dbServiceTask.Hours = entity.Hours;
        }
    }
}
 
