using Microsoft.AspNetCore.Components;
using RedMotors.Blazor.Shared;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;


namespace RedMotors.Blazor.Client.Pages
{
    public partial class ServiceTaskList
    {
        List<ServiceTaskListViewModel> serviceTaskList = new();
        bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadItemsFromServer();
            isLoading = false;
        }
        private async Task LoadItemsFromServer()
        {
            serviceTaskList = await httpClient.GetFromJsonAsync<List<ServiceTaskListViewModel>>("serviceTask");
        }

        async Task AddItemPage()
        {
            navigationManager.NavigateTo("ServiceTaskList/edit");
        }
        async Task EditServiceTaskItem(ServiceTaskListViewModel itemToEdit)
        {
            navigationManager.NavigateTo($"/ServiceTaskList/edit/{itemToEdit.Id}");
        }
        async Task DeleteItem(ServiceTaskListViewModel itemToDelete)
        {
            var response = await httpClient.DeleteAsync($"serviceTask/{itemToDelete.Id}");
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }

    }
}
