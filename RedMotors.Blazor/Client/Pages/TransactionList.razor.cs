using System.Net.Http.Json;
using RedMotors.Blazor.Shared;

namespace RedMotors.Blazor.Client.Pages
{
    public partial class TransactionList
    {
        
        List<TransactionViewModel> transactionList = new();
        private List<CustomerEditListViewModel> customers { get; set; }
        private List<CarEditListViewModel> cars { get; set; }
        private List<ManagerEditListViewModel> managers { get; set; }
        bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {

            await LoadItemsFromServer();
            isLoading = false;
        }

        private async Task LoadItemsFromServer()
        {
            managers = await httpClient.GetFromJsonAsync<List<ManagerEditListViewModel>>("manager");
            cars = await httpClient.GetFromJsonAsync<List<CarEditListViewModel>>("car");
            customers = await httpClient.GetFromJsonAsync<List<CustomerEditListViewModel>>("customer");
            transactionList = await httpClient.GetFromJsonAsync<List<TransactionViewModel>>("transaction");
        }

        async Task AddItem()
        {
            navigationManager.NavigateTo("/transactionlist/edit");

        }
        async Task EditItem(TransactionViewModel itemToEdit)
        {
            navigationManager.NavigateTo($"/transactionlist/edit/{itemToEdit.Id}");
        }

        async Task DeleteItem(TransactionViewModel itemToDelete)
        {
            var response = await httpClient.DeleteAsync($"transactionlist/{itemToDelete.Id}");
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }
    }
}

