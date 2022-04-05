using RedMotors.Entities;
using Microsoft.EntityFrameworkCore;

namespace RedMotors.Database.Repository;

internal class ManagerRepo : IEntityRepo<Manager>
{
    private readonly GarageContext _context;

    public ManagerRepo(GarageContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Manager entity)
    {
        _context.Managers.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var manager = await _context.Managers.SingleOrDefaultAsync(x => x.Id == id);

        if (manager is null)
            return;
        _context.Managers.Remove(manager);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Manager>> GetAllAsync()
    {
        return await _context.Managers.ToListAsync();
    }

    public Task<Manager?> GetByIdAsync(Guid id)
    {
        return _context.Managers.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Guid id, Manager entity)
    {
        var manager = await GetByIdAsync(id);

        if (manager is null)
            throw new KeyNotFoundException($"Manager {id} was removed in the middle of being updated");
        await _context.SaveChangesAsync();
    }
}
