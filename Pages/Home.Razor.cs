using Microsoft.AspNetCore.Components;
using ToDoWasmSqlLite.Data;

namespace ToDoWasmSqlLite.Pages
{
    public partial class Home
    {
        [Inject]
        public ToDoService Service { get; set; } = null!;

        private string _todoInput { get; set; } = string.Empty;

        private List<ToDoItem> _taskList { get; set; } = [];

        protected override async Task OnInitializedAsync() => await Refresh();

        private async Task Add()
        {
            await Service.AddTaskAsync(_todoInput);
            await Refresh();
            _todoInput = string.Empty;
        }

        private async Task Remove(string id)
        {
            var guid = Guid.Parse(id);

            await Service.RemoveTask(guid);
            await Refresh();
        }

        private async Task Done(string id)
        {
            var guid = Guid.Parse(id);

            await Service.DoneTaskAsync(guid);

            await Refresh();
        }

        private async Task Refresh() => _taskList = (await Service.GetTasksAsync()).ToList();
    }
}
