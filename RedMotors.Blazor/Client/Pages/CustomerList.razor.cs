using RedMotors.Blazor.Shared;
using System.Net.Http.Json;

namespace RedMotors.Blazor.Client.Pages
{
    public partial class CustomerList
    {
        List<CustomerListViewModel> customerList = new();
        bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadItemsFromServer();
            isLoading = false;
        }

        private async Task LoadItemsFromServer()
        {
            customerList = await httpClient.GetFromJsonAsync<List<CustomerListViewModel>>("customer");
        }

        async Task AddItem()
        {
            navigationManager.NavigateTo("/customerlist/edit");
        }

        async Task DeleteItem(CustomerListViewModel itemToDelete)
        {
            var response = await httpClient.DeleteAsync($"customer/{itemToDelete.Id}");
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }
        async Task EditItem(CustomerListViewModel itemToEdit)
        {
            navigationManager.NavigateTo($"/customerlist/edit/{itemToEdit.Id}");
        }
    }
}