using LavenderMotors.Entities;
using Microsoft.EntityFrameworkCore;

namespace LavenderMotors.Database.Repository;

internal class CustomerRepo : IEntityRepo<Customer>
{
    private readonly GarageContext _context;

    public CustomerRepo(GarageContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Customer entity)
    {
        _context.Customers.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var customer = await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);

        if (customer is null)
            return;
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public Task<Customer?> GetByIdAsync(Guid id)
    {
        return _context.Customers.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Guid id, Customer entity)
    {
        var customer = await GetByIdAsync(id);

        if (customer is null)
            throw new KeyNotFoundException($"Customer {id} was removed in the middle of being updated");
        await _context.SaveChangesAsync();
    }
}
