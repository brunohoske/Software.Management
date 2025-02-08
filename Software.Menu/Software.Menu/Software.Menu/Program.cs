using Software.Menu.Client;
using Software.Menu.Components;
using Software.Menu.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddScoped(sp =>
{
    var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7289") };
    httpClient.DefaultRequestHeaders.Add("cnpj", "42591651000143");
    return httpClient;
});
//Clients
builder.Services.AddScoped<MenuClient>();
builder.Services.AddScoped<IngredientClient>();
builder.Services.AddScoped<ProductClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Software.Menu.Client._Imports).Assembly);


app.Urls.Add($"https://0.0.0.0:7124");
app.Run();
