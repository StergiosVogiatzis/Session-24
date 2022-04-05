using LavenderMotors.Entities;
using Microsoft.EntityFrameworkCore;

namespace LavenderMotors.Database.Repository;

internal class TransactionRepo : IEntityRepo<Transaction>
{
    private readonly GarageContext _context;

    public TransactionRepo(GarageContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Transaction entity)
    {
        _context.Transactions.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var transaction = await _context.Transactions.SingleOrDefaultAsync(x => x.Id == id);

        if (transaction is null)
            return;
        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        return await _context.Transactions.ToListAsync();
    }

    public Task<Transaction?> GetByIdAsync(Guid id)
    {
        return _context.Transactions.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Guid id, Transaction entity)
    {
        var transaction = await GetByIdAsync(id);

        if (transaction is null)
            throw new KeyNotFoundException($"Transaction {id} was removed in the middle of being updated");
        await _context.SaveChangesAsync();
    }
}
