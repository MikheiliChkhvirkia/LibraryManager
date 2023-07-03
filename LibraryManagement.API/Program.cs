using LibraryManagement.API.Tools.Extensions;
using LibraryManagement.API.Tools.Extentions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Assembly assembly = Assembly.GetExecutingAssembly();
// Add services to the container.
builder.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureMiddlewares(assembly);

app.Run();
