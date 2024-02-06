using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;
using ToDoWasmSqlLite;
using ToDoWasmSqlLite.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ToDoService>();
builder.Services.AddSqliteWasmDbContextFactory<ToDoContext>(opt =>
    opt.UseSqlite("Data Source=todos.db"));

await builder.Build().RunAsync();
