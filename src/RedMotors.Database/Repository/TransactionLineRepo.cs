using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedMotors.Entities;

namespace RedMotors.Database.Repository
{
    public class TransactionLinesRepo : IEntityRepo<TransactionLine>
    {
        private readonly GarageContext _context;
        public TransactionLinesRepo(GarageContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TransactionLine entity)
        {
            await _context.TransactionLines.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var foundTransactionLine = await _context.TransactionLines.SingleOrDefaultAsync(transactionLine => transactionLine.Id == id);
            if (foundTransactionLine is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            _context.TransactionLines.Remove(foundTransactionLine);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TransactionLine>> GetAllAsync()
        {
            return await _context.TransactionLines.ToListAsync();
        }

        public async Task<TransactionLine?> GetByIdAsync(Guid id)
        {
            return await _context.TransactionLines.Where(transaction => transaction.Id == id).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Guid id, TransactionLine entity)
        {
            var currentTransactionLine = await _context.TransactionLines.SingleOrDefaultAsync(transactionLine => transactionLine.Id == id);
            if (currentTransactionLine is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            currentTransactionLine.TransactionId = entity.TransactionId;
            currentTransactionLine.ServiceTaskId = entity.ServiceTaskId;
            currentTransactionLine.EngineerId = entity.EngineerId;
            //currentTransactionLine.ServiceTask = entity.ServiceTask;
            currentTransactionLine.Engineer = entity.Engineer;
            currentTransactionLine.Hours = entity.Hours;
            await _context.SaveChangesAsync();
        }

        Task<IEnumerable<TransactionLine>> IEntityRepo<TransactionLine>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task AddAsync(TransactionLine entity)
        {
            throw new NotImplementedException();
        }
    }
}
