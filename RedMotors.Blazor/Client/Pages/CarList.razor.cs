using Microsoft.AspNetCore.Components;
using RedMotors.Blazor.Shared;
using System.Net.Http.Json;

namespace RedMotors.Blazor.Client.Pages
{
    public partial class CarList
    {
        private string BrandText { get; set; }
        private string ModelText { get; set; }
        private string RegNumText { get; set; }
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
            if (string.IsNullOrWhiteSpace(BrandText) && string.IsNullOrWhiteSpace(ModelText) && string.IsNullOrWhiteSpace(RegNumText)) return;
            var newCar = new CarListViewModel
            {
                Brand = BrandText,
                Model = ModelText,
                CarRegistrationNumber = RegNumText
            };
            BrandText = null;
            ModelText = null;
            RegNumText = null;

            await httpClient.PostAsJsonAsync("car", newCar);
            await LoadItemsFromServer();
            
        }

        async Task DeleteItem(CarListViewModel itemToDelete)
        {
                var response = await httpClient.DeleteAsync($"car/{itemToDelete.Id}");
                response.EnsureSuccessStatusCode();
                await LoadItemsFromServer();  
        }

        async Task BrandChanged(ChangeEventArgs e, CarListViewModel item)
        {
            item.Brand = e.Value?.ToString();
            var response = await httpClient.PutAsJsonAsync("car", item);
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }
        async Task ModelChanged(ChangeEventArgs e, CarListViewModel item)
        {
            item.Model = e.Value?.ToString();
            var response = await httpClient.PutAsJsonAsync("car", item);
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }
        async Task RegNumChanged(ChangeEventArgs e, CarListViewModel item)
        {
            item.CarRegistrationNumber = e.Value?.ToString();
            var response = await httpClient.PutAsJsonAsync("car", item);
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }

    }
}
