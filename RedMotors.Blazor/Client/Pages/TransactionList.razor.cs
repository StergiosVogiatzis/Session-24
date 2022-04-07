using System.Net.Http.Json;
using RedMotors.Blazor.Shared;

namespace RedMotors.Blazor.Client.Pages
{
    public partial class TransactionList
    {
        
        List<TransactionViewModel> transactionList = new();
        private List<CustomerEditListViewModel> customers { get; set; }
        private List<CarEditListViewModel> cars { get; set; }
        private List<ManagerEditViewModel> managers { get; set; }
        public List<EngineerEditViewModel> engineers { get; set; } 
        public List<ServiceTaskEditViewModel> serviceTasks { get; set; } 
        bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {

            await LoadItemsFromServer();
            isLoading = false;
        }

        private async Task LoadItemsFromServer()
        {
            serviceTasks = await httpClient.GetFromJsonAsync<List<ServiceTaskEditViewModel>>("servicetask");
            engineers = await httpClient.GetFromJsonAsync<List<EngineerEditViewModel>>("engineer");
            managers = await httpClient.GetFromJsonAsync<List<ManagerEditViewModel>>("manager");
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

