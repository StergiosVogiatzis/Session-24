using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RedMotors.Blazor.Shared;
using System.Net.Http.Json;

namespace RedMotors.Blazor.Client.Pages
{
    public partial class ManagerList
    {
        //private string? managerName { get; set; }
        //private string? managerSurname { get; set; }
        //private decimal managerSalaryPerMonth { get; set; }

        List<ManagerListViewModel> managerList = new();
        bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadManagerFromServer();
            isLoading = false;
        }

        private async Task LoadManagerFromServer()
        {
            managerList = await httpClient.GetFromJsonAsync<List<ManagerListViewModel>>("manager");
        }
        async Task AddManager()
        {
            //if (string.IsNullOrWhiteSpace(managerName) && string.IsNullOrWhiteSpace(managerSurname) && string.IsNullOrWhiteSpace(Convert.ToString(managerSalaryPerMonth))) return;
            //var newManager = new ManagerListViewModel
            //{
            //    Name = managerName,
            //    Surname = managerSurname,
            //    SalaryPerMonth = managerSalaryPerMonth
            //};
            //managerName = null;
            //managerSurname = null;
            //managerSalaryPerMonth = 0;
            //await httpClient.PostAsJsonAsync("manager", newManager);
            //await LoadManagersFromServer();
            navigationManager.NavigateTo("/managerlist/edit");
        }

        async Task EditManager(ManagerListViewModel managerToEdit)
        {
            navigationManager.NavigateTo($"/managerlist/edit/{managerToEdit.Id}");
        }

        async Task DeleteManager(ManagerListViewModel managerToDelete)
        {
            var response = await httpClient.DeleteAsync($"car/{managerToDelete.Id}");
            response.EnsureSuccessStatusCode();
            await LoadManagerFromServer();

        }

        //async Task NameChanged(ChangeEventArgs m, ManagerListViewModel item)
        //{
        //    item.Name = m.Value?.ToString();
        //    var response = await httpClient.PutAsJsonAsync("manager", item);
        //    response.EnsureSuccessStatusCode();
        //    await LoadManagerFromServer();
        //}
        //async Task SurnameChanged(ChangeEventArgs m, ManagerListViewModel item)
        //{
        //    item.Surname = m.Value?.ToString();
        //    var response = await httpClient.PutAsJsonAsync("manager", item);
        //    response.EnsureSuccessStatusCode();
        //    await LoadManagerFromServer();
        //}
        //async Task SalaryPerMonthChanged(ChangeEventArgs m, ManagerListViewModel item)
        //{
        //    (item.SalaryPerMonth) = Convert.ToDecimal(m.Value);
        //    var response = await httpClient.PutAsJsonAsync("manager", item);
        //    response.EnsureSuccessStatusCode();
        //    await LoadManagerFromServer();
        //}
    }
}
