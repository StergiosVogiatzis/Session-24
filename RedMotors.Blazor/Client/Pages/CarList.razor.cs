using Microsoft.AspNetCore.Components;
using RedMotors.Blazor.Shared;
using System.Net.Http.Json;

namespace RedMotors.Blazor.Client.Pages
{
    public partial class CarList
    {
        List<CarListViewModel> carList = new();
        bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadItemsFromServer();
            isLoading = false;
        }

        private async Task LoadItemsFromServer()
        {
            carList = await httpClient.GetFromJsonAsync<List<CarListViewModel>>("car");
        }

        async Task AddItem()
        {
            navigationManager.NavigateTo("/carlist/edit");

        }
        async Task EditItem(CarListViewModel itemToEdit)
        {
            navigationManager.NavigateTo($"/carlist/edit/{itemToEdit.Id}");
        }

        async Task DeleteItem(CarListViewModel itemToDelete)
        {
                var response = await httpClient.DeleteAsync($"car/{itemToDelete.Id}");
                response.EnsureSuccessStatusCode();
                await LoadItemsFromServer();  
        }
    }
}
