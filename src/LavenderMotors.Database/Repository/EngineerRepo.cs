using LavenderMotors.Entities;
using Microsoft.EntityFrameworkCore;

namespace LavenderMotors.Database.Repository;

internal class EngineerRepo : IEntityRepo<Engineer>
{
    private readonly GarageContext _context;

    public EngineerRepo(GarageContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Engineer entity)
    {
        _context.Engineers.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var engineer = await _context.Engineers.SingleOrDefaultAsync(x => x.Id == id);

        if (engineer is null)
            return;
        _context.Engineers.Remove(engineer);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Engineer>> GetAllAsync()
    {
        return await _context.Engineers.ToListAsync();
    }

    public Task<Engineer?> GetByIdAsync(Guid id)
    {
        return _context.Engineers.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Guid id, Engineer entity)
    {
        var engineer = await GetByIdAsync(id);

        if (engineer is null)
            throw new KeyNotFoundException($"Engineer {id} was removed in the middle of being updated");
        await _context.SaveChangesAsync();
    }
}
