using Microsoft.EntityFrameworkCore;

namespace ToDoWasmSqlLite.Data
{
    public class ToDoContext(DbContextOptions<ToDoContext> opt) : DbContext(opt)
    {
        public DbSet<ToDoItem> ToDoItems { get; set; } = null!;
    }
}
