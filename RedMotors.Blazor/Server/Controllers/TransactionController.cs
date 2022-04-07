using Microsoft.AspNetCore.Mvc;
using RedMotors.Blazor.Shared;
using RedMotors.Database.Repository;
using RedMotors.Entities;

namespace RedMotors.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<TransactionLine> _transactionLineRepo;
        private readonly IEntityRepo<Customer> _customerRepo;
        private readonly IEntityRepo<Car> _carRepo;
        private readonly IEntityRepo<Manager> _managerRepo;

        public TransactionController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<TransactionLine> transactionLineRepo,  IEntityRepo<Customer> customerRepo, IEntityRepo<Car> carRepo, IEntityRepo<Manager> managerRepo)
        {
            _transactionRepo = transactionRepo;
            _transactionLineRepo = transactionLineRepo;
            _customerRepo = customerRepo;
            _carRepo = carRepo;
            _managerRepo = managerRepo;
           
        }

        [HttpGet]
        public async Task<IEnumerable<TransactionViewModel>> Get()
        {
            var result = await _transactionRepo.GetAllAsync();
            return result.Select(x => new TransactionViewModel
            {
                Id = x.Id,
                CarId = x.CarId,
                CustomerId = x.CustomerId,
                ManagerId = x.ManagerId,
                TotalPrice = x.TotalPrice
            });
        }

        [HttpGet("{id}")]
        public async Task<TransactionEditViewModel> Get(Guid id)
        {
            TransactionEditViewModel model = new();
            if (id != Guid.Empty)
            {
                var existing = await _transactionRepo.GetByIdAsync(id);
                model.Id = existing.Id;
                model.CarId = existing.CarId;
                model.CustomerId = existing.CustomerId;
                model.ManagerId = existing.ManagerId;
                model.TotalPrice = existing.TotalPrice;
                
                model.TransactionLines = existing.Lines.Select(transactionLine => new TransactionLineViewModel
                {
                    Id = transactionLine.Id,
                    EngineerId = transactionLine.EngineerId,
                    Hours = transactionLine.Hours,
                    PricePerHour = transactionLine.PricePerHour,
                    TotalPrice = transactionLine.Price,
                    ServiceTaskId = transactionLine.ServiceTaskId,
                    TransactionId = transactionLine.TransactionId
                    
                }).ToList();
            }

            var customer = await _customerRepo.GetAllAsync();
            model.Customers = customer.Select(x => new CustomerEditListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Phone = x.Phone,
                TIN = x.TIN
               
            }).ToList();
            var car = await _carRepo.GetAllAsync();
            model.Cars = car.Select(x => new CarEditListViewModel
            {
                Id = x.Id,
                Brand = x.Brand,
                Model = x.Model,
                CarRegistrationNumber = x.CarRegistrationNumber

            }).ToList();
            var manager = await _managerRepo.GetAllAsync();
            model.Managers = manager.Select(x => new ManagerEditViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                SalaryPerMonth = x.SalaryPerMonth,    
            }).ToList();

            return model;
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _transactionRepo.DeleteAsync(id);
        }



        [HttpPost]
        public async Task Post(TransactionEditViewModel transaction)
        {
            Transaction newTransaction = new Transaction
            {
                Id = transaction.Id,
                Date = transaction.Date,
                CarId = transaction.CarId,
                ManagerId = transaction.ManagerId,
                CustomerId = transaction.CustomerId,
                
            };

            //foreach (var transactionsLine in transaction.TransactionLines)
            //{
            //    newTransaction.Lines.Add(new TransactionLine()
            //    {
            //        Id = transactionsLine.Id,
            //        EngineerId = transactionsLine.EngineerId,
            //        Hours = transactionsLine.Hours,
            //        PricePerHour = transactionsLine.PricePerHour,
            //        Price = transactionsLine.TotalPrice,
            //        ServiceTaskId = transactionsLine.ServiceTaskId,
            //        TransactionId = transactionsLine.TransactionId
            //    });
            //}
            await _transactionRepo.AddAsync(newTransaction);
        }

        [HttpPut]
        public async Task<ActionResult> Put(TransactionEditViewModel transaction)
        {
            var itemToUpdate = await _transactionRepo.GetByIdAsync(transaction.Id);
            if (itemToUpdate == null) return NotFound();

            itemToUpdate.CarId = transaction.CarId;
            itemToUpdate.CustomerId = transaction.CustomerId;
            itemToUpdate.ManagerId = transaction.ManagerId;
            
            
            itemToUpdate.Lines = transaction.TransactionLines.Select(transactionLine => new TransactionLine()
            {
                Id = transactionLine.Id,
                EngineerId = transactionLine.EngineerId,
                Hours = transactionLine.Hours,
                PricePerHour = transactionLine.PricePerHour,
                Price = transactionLine.TotalPrice,
                ServiceTaskId = transactionLine.ServiceTaskId,
                TransactionId = transactionLine.TransactionId
            }).ToList();

            await _transactionRepo.UpdateAsync(transaction.Id, itemToUpdate);

            return Ok();
        }
    }
}
