using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RedMotors.Blazor.Shared;
using System.Net.Http.Json;

namespace RedMotors.Blazor.Client.Pages
{
    public partial class EngineerList
    {
        List<EngineerListViewModel> engineerList = new();
        bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadEngineerFromServer();
            isLoading = false;
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

