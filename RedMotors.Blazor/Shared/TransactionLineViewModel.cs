using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMotors.Blazor.Shared
{
    public class TransactionLineViewModel
    {
        public Guid Id { get; set; }
        public Guid ServiceTaskId { get; set; }
        public Guid EngineerId { get; set; }
        public Guid TransactionId { get; set; }
        public decimal Hours { get; set;}
        public decimal PricePerHour { get; set; } = 44.5m;
        public decimal TotalPrice { get; set; }
    }
}
