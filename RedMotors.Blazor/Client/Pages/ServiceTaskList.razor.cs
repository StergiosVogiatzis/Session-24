using Microsoft.AspNetCore.Components;
using RedMotors.Blazor.Shared;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;


namespace RedMotors.Blazor.Client.Pages
{
    public partial class ServiceTaskList
    {
        private string NewCodeText { get; set; }
        private string NewDescriptionText { get; set; }
        public decimal? NewHoursInput { get; set; }
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

        async Task AddItem()
        {
            if (string.IsNullOrWhiteSpace(NewCodeText) && string.IsNullOrWhiteSpace(NewDescriptionText) && NewHoursInput is null || NewHoursInput == 0) return;
            var newServiceTask = new ServiceTaskListViewModel
            {
                Code = NewCodeText,
                Description = NewDescriptionText,
                Hours = NewHoursInput,

            };
            NewCodeText = null;
            NewDescriptionText = null;
            NewHoursInput = 0;
            await httpClient.PostAsJsonAsync("serviceTask", newServiceTask);
            await LoadItemsFromServer();
        }

        async Task DeleteItem(ServiceTaskListViewModel itemToDelete)
        {
            var response = await httpClient.DeleteAsync($"serviceTask/{itemToDelete.Id}");
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }

        async Task CodeChanged(ChangeEventArgs e, ServiceTaskListViewModel item)
        {
            item.Code = e.Value?.ToString();
            var response = await httpClient.PutAsJsonAsync("serviceTask", item);
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }
        async Task DescriptionChanged(ChangeEventArgs e, ServiceTaskListViewModel item)
        {
            item.Description = e.Value?.ToString();
            var response = await httpClient.PutAsJsonAsync("serviceTask", item);
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }
        async Task HoursChanged(ChangeEventArgs e, ServiceTaskListViewModel item)
        {
            item.Hours = Convert.ToDecimal(e.Value);
            var response = await httpClient.PutAsJsonAsync("serviceTask", item);
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }
    }
}
