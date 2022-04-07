using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RedMotors.Blazor.Shared;
using System.Net.Http.Json;

namespace RedMotors.Blazor.Client.Pages
{
    public partial class EngineerList
    {
        List<EngineerListViewModel> engineerList = new();
        private List<ManagerListViewModel> managerList = new();
        bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {

            await LoadEngineerFromServer();
            await LoadManagerFromServer();
            isLoading = false;
        }

        private async Task LoadManagerFromServer()
        {
            managerList = await httpClient.GetFromJsonAsync<List<ManagerListViewModel>>("manager");
        }
        private async Task LoadEngineerFromServer()
        {
            engineerList = await httpClient.GetFromJsonAsync<List<EngineerListViewModel>>("engineer");
        }
        async Task AddEngineer()
        {
            navigationManager.NavigateTo("/engineerlist/edit");
        }

        async Task DeleteEngineer(EngineerListViewModel engineerToDelete)
        {
            var response = await httpClient.DeleteAsync($"engineer/{engineerToDelete.Id}");
            response.EnsureSuccessStatusCode();
            await LoadEngineerFromServer();
        }

        async Task EditEngineer(EngineerListViewModel engineerToEdit)
        {
            navigationManager.NavigateTo($"/engineerlist/edit/{engineerToEdit.Id}");
            
        }

    }
}

