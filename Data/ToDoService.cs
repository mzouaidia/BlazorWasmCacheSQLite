using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;

namespace ToDoWasmSqlLite.Data
{
    public class ToDoService(ISqliteWasmDbContextFactory<ToDoContext> dbFactory)
    {
        public async Task<IEnumerable<ToDoItem>> GetTasksAsync()
        {
            await using var ctx = await dbFactory.CreateDbContextAsync();

            return await ctx.ToDoItems.ToListAsync();
        }

        public async Task AddTaskAsync(string task)
        {
            await using var ctx = await dbFactory.CreateDbContextAsync();

            ctx.Add(new ToDoItem
            {
                Id = Guid.NewGuid(),
                Task = task,
                IsDone = false
            });

            await ctx.SaveChangesAsync();
        }

        public async Task DoneTaskAsync(Guid id)
        {
            await using var ctx = await dbFactory.CreateDbContextAsync();

            var toUpdate = await ctx.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);

            if (toUpdate == null) return;

            toUpdate.IsDone = !toUpdate.IsDone;

            await ctx.SaveChangesAsync();
        }

        public async Task RemoveTask(Guid id)
        {
            await using var ctx = await dbFactory.CreateDbContextAsync();

            var toDelete = await ctx.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);

            if (toDelete == null) return;

            ctx.ToDoItems.Remove(toDelete);
            await ctx.SaveChangesAsync();
        }
    }
}
