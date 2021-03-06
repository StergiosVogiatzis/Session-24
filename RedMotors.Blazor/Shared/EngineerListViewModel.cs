using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMotors.Blazor.Shared
{
    public class EngineerListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal SalaryPerMonth { get; set; }
        public Guid ManagerId { get; set; }
        public List<ManagerEditViewModel> Managers { get; set; } = new();

    }
    public class EngineerEditViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal SalaryPerMonth { get; set; }
        public Guid ManagerId { get; set; }
        public List<ManagerEditViewModel> Managers { get; set; } = new();
    }


}


