using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RedMotors.Blazor.Shared;
using System.Net.Http.Json;

namespace RedMotors.Blazor.Client.Pages
{
    public partial class ManagerList
    {
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

            navigationManager.NavigateTo("/managerlist/edit");
        }

        async Task EditManager(ManagerListViewModel managerToEdit)
        {
            navigationManager.NavigateTo($"/managerlist/edit/{managerToEdit.Id}");
        }

        async Task DeleteManager(ManagerListViewModel managerToDelete)
        {
            var response = await httpClient.DeleteAsync($"manager/{managerToDelete.Id}");
            response.EnsureSuccessStatusCode();
            await LoadManagerFromServer();

        }

    }
}
