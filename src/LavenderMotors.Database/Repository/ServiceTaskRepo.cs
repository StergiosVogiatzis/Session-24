using LavenderMotors.Entities;
using Microsoft.EntityFrameworkCore;

namespace LavenderMotors.Database.Repository
{
    internal class ServiceTaskRepo : IEntityRepo<ServiceTask>
    {
        private readonly GarageContext _context;

        public ServiceTaskRepo(GarageContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ServiceTask entity)
        {
            _context.ServiceTasks.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var serviceTask = await _context.ServiceTasks.SingleOrDefaultAsync(x => x.Id == id);

            if (serviceTask is null)
                return;
            _context.ServiceTasks.Remove(serviceTask);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ServiceTask>> GetAllAsync()
        {
            return await _context.ServiceTasks.ToListAsync();
        }

        public Task<ServiceTask?> GetByIdAsync(Guid id)
        {
            return _context.ServiceTasks.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Guid id, ServiceTask entity)
        {
            var serviceTask = await GetByIdAsync(id);

            if (serviceTask is null)
                throw new KeyNotFoundException($"Service Task {id} was removed in the middle of being updated");
            await _context.SaveChangesAsync();
        }

    }
}
 
