using Microsoft.AspNetCore.Components;
using RedMotors.Blazor.Shared;
using System.Net.Http.Json;

namespace RedMotors.Blazor.Client.Pages
{
    public partial class CustomerList
    {
        private string NameText { get; set; }
        private string SurnameText { get; set; }
        private string PhoneText { get; set; }
        private string TINText { get; set; }
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
            if (string.IsNullOrWhiteSpace(NameText) && string.IsNullOrWhiteSpace(SurnameText) && string.IsNullOrWhiteSpace(PhoneText) && string.IsNullOrWhiteSpace(TINText)) return;
            var newCustomer = new CustomerListViewModel
            {
                Name = NameText,
                Surname = SurnameText,
                Phone = PhoneText,
                TIN = TINText
            };
            NameText = null;
            SurnameText = null;
            PhoneText = null;
            TINText = null;

            await httpClient.PostAsJsonAsync("customer", newCustomer);
            await LoadItemsFromServer();
            
        }

        async Task DeleteItem(CustomerListViewModel itemToDelete)
        {
                var response = await httpClient.DeleteAsync($"customer/{itemToDelete.Id}");
                response.EnsureSuccessStatusCode();
                await LoadItemsFromServer();  
        }

        async Task NameChanged(ChangeEventArgs e, CustomerListViewModel item)
        {
            item.Name = e.Value?.ToString();
            var response = await httpClient.PutAsJsonAsync("customer", item);
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }
        async Task SurnameChanged(ChangeEventArgs e, CustomerListViewModel item)
        {
            item.Surname = e.Value?.ToString();
            var response = await httpClient.PutAsJsonAsync("customer", item);
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }
        async Task PhoneChanged(ChangeEventArgs e, CustomerListViewModel item)
        {
            item.Phone = e.Value?.ToString();
            var response = await httpClient.PutAsJsonAsync("customer", item);
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }
        async Task TINChanged(ChangeEventArgs e, CustomerListViewModel item)
        {
            item.TIN = e.Value?.ToString();
            var response = await httpClient.PutAsJsonAsync("customer", item);
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }

    }
}
