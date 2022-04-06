using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMotors.Blazor.Shared
{
    public class CarListViewModel
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarRegistrationNumber { get; set; }
    }
    public class CarEditListViewModel
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarRegistrationNumber { get; set; }
    }
}

