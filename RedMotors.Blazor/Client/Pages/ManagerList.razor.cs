using Microsoft.AspNetCore.Components.Web;
using RedMotors.Blazor.Shared;

namespace RedMotors.Blazor.Client.Pages
{
    public partial class ManagerList
    {
        private string? managerName { get; set; }
        private string managerSurname { get; set; }
        private decimal managerSalaryPerMonth { get; set; }

        List<ManagerListViewModel> managerList = new()
        {
            new ManagerListViewModel
            {
                Id = new Guid(),
                Name = "MockName",
                Surname = "MockSurname",
                SalaryPerMonth = 557.14M
            }
        };

        void AddManager()
        {
            if (string.IsNullOrWhiteSpace(managerName)
            && string.IsNullOrWhiteSpace(managerSurname)
            && managerSalaryPerMonth != null) return;
            managerList.Add(new ManagerListViewModel
            {
                Id = new Guid(),
                Name = managerName,
                Surname = managerSurname,
                SalaryPerMonth = managerSalaryPerMonth
            });
        }
        void DeleteManager(MouseEventArgs e, ManagerListViewModel managerToDelete)
        {
            managerList.Remove(managerToDelete);
        }
    }
}
