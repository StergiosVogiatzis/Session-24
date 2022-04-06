using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RedMotors.Blazor.Shared;
using System.Net.Http.Json;

namespace RedMotors.Blazor.Client.Pages
{
    public partial class ManagerList
    {
        private string? managerName { get; set; }
        private string? managerSurname { get; set; }
        private decimal managerSalaryPerMonth { get; set; }

        List<ManagerListViewModel> managerList = new();
        bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadManagersFromServer();
            isLoading = false;
        }

        //protected override async Task OnInitializedAsync()
        //{
        //    //managerList = await httpClient.GetFromJsonAsync<List<ManagerListViewModel>>("manager");
        //    await LoadManagersFromServer();
        //}
        private async Task LoadManagersFromServer()
        {
            managerList = await httpClient.GetFromJsonAsync<List<ManagerListViewModel>>("manager");
        }
        async Task AddManager()
        {
            if (string.IsNullOrWhiteSpace(managerName) && string.IsNullOrWhiteSpace(managerSurname) && string.IsNullOrWhiteSpace(Convert.ToString(managerSalaryPerMonth))) return;
            var newManager = new ManagerListViewModel
            {
                Name = managerName,
                Surname = managerSurname,
                SalaryPerMonth = managerSalaryPerMonth
            };
            managerName = null;
            managerSurname = null;
            managerSalaryPerMonth = 0;


            await httpClient.PostAsJsonAsync("manager", newManager);
            await LoadManagersFromServer();

        }

        void DeleteManager(MouseEventArgs e, ManagerListViewModel managerToDelete)
        {
            managerList.Remove(managerToDelete);
        }

        async Task NameChanged(ChangeEventArgs m, ManagerListViewModel item)
        {
            item.Name = m.Value?.ToString();
            var response = await httpClient.PutAsJsonAsync("manager", item);
            response.EnsureSuccessStatusCode();
            await LoadManagersFromServer();
        }
        async Task SurnameChanged(ChangeEventArgs m, ManagerListViewModel item)
        {
            item.Surname = m.Value?.ToString();
            var response = await httpClient.PutAsJsonAsync("manager", item);
            response.EnsureSuccessStatusCode();
            await LoadManagersFromServer();
        }
        async Task SalaryPerMonthChanged(ChangeEventArgs m, ManagerListViewModel item)
        {
            (item.SalaryPerMonth) = Convert.ToDecimal(m.Value);
            var response = await httpClient.PutAsJsonAsync("manager", item);
            response.EnsureSuccessStatusCode();
            await LoadManagersFromServer();
        }
    }
}
