using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMotors.Blazor.Shared
{
    public class ManagerEditViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal SalaryPerMonth { get; set; }
        public List<EngineerEditViewModel> Engineers { get; set; } = new();

    }
    public class ManagerListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal SalaryPerMonth { get; set; }
       

    }

    public class EngineerEditListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    
}
