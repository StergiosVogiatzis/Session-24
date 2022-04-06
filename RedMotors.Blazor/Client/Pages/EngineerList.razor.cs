using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RedMotors.Blazor.Shared;
using System.Net.Http.Json;

namespace RedMotors.Blazor.Client.Pages
{
    public partial class EngineerList
    {
        private string? engineerName { get; set; }
        private string? engineerSurname { get; set; }
        private decimal engineerSalaryPerMonth { get; set; }

        List<EngineerListViewModel> engineerList = new();
        bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadEngineersFromServer();
            isLoading = false;
        }

        private async Task LoadEngineersFromServer()
        {
            engineerList = await httpClient.GetFromJsonAsync<List<EngineerListViewModel>>("engineer");
        }
        async Task AddEngineer()
        {
            if (string.IsNullOrWhiteSpace(engineerName) && string.IsNullOrWhiteSpace(engineerSurname) && string.IsNullOrWhiteSpace(Convert.ToString(engineerSalaryPerMonth))) return;
            var newEngineer = new EngineerListViewModel
            {
                Name = engineerName,
                Surname = engineerSurname,
                SalaryPerMonth = engineerSalaryPerMonth
            };
            engineerName = null;
            engineerSurname = null;
            engineerSalaryPerMonth = 0;


            await httpClient.PostAsJsonAsync("engineer", newEngineer);
            await LoadEngineersFromServer();

        }

        void DeleteEngineer(MouseEventArgs e, EngineerListViewModel engineerToDelete)
        {
            engineerList.Remove(engineerToDelete);
        }

        async Task NameChanged(ChangeEventArgs m, EngineerListViewModel item)
        {
            item.Name = m.Value?.ToString();
            var response = await httpClient.PutAsJsonAsync("engineer", item);
            response.EnsureSuccessStatusCode();
            await LoadEngineersFromServer();
        }
        async Task SurnameChanged(ChangeEventArgs m, EngineerListViewModel item)
        {
            item.Surname = m.Value?.ToString();
            var response = await httpClient.PutAsJsonAsync("engineer", item);
            response.EnsureSuccessStatusCode();
            await LoadEngineersFromServer();
        }
        async Task SalaryPerMonthChanged(ChangeEventArgs m, EngineerListViewModel item)
        {
            (item.SalaryPerMonth) = Convert.ToDecimal(m.Value);
            var response = await httpClient.PutAsJsonAsync("engineer", item);
            response.EnsureSuccessStatusCode();
            await LoadEngineersFromServer();
        }
    }
}

