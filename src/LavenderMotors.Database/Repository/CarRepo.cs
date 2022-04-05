using LavenderMotors.Entities;
using Microsoft.EntityFrameworkCore;

namespace LavenderMotors.Database.Repository;

internal class CarRepo : IEntityRepo<Car>
{
    private readonly GarageContext _context;

    public CarRepo(GarageContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Car entity)
    {
        _context.Cars.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var car = await _context.Cars.SingleOrDefaultAsync(x => x.Id == id);

        if (car is null)
            return;
        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        return await _context.Cars.ToListAsync();
    }

    public Task<Car?> GetByIdAsync(Guid id)
    {
        return _context.Cars.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Guid id, Car entity)
    {
        var car = await GetByIdAsync(id);

        if (car is null)
            throw new KeyNotFoundException($"Car {id} was removed in the middle of being updated");
        await _context.SaveChangesAsync();
    }
}
