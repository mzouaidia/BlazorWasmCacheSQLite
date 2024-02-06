namespace ToDoWasmSqlLite.Data
{
    public class ToDoItem
    {
        public Guid Id { get; set; }

        public string Task { get; set; } = string.Empty;

        public bool IsDone { get; set; }
    }
}
