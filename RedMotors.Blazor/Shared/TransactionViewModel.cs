﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMotors.Blazor.Shared
{
    public class TransactionViewModel
    {
        public Guid Id { get; set; }
        public Guid ManagerId { get; set; }
        public Guid CarId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalPrice { get; set;}

    }
    public class TransactionEditViewModel
    {
        public Guid Id { get; set; }
        public Guid ManagerId { get; set; }
        public Guid CarId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<TransactionLineViewModel> TransactionLines { get; set; } = new();
        public List<CustomerListViewModel> Customers { get; set; } = new();
    }
}