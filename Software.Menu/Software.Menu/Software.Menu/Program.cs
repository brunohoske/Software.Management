using Software.Menu.Client.Pages;
using Software.Menu.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
    builder.Services.AddScoped(sp => new HttpClient {
    
        BaseAddress = new Uri("https://localhost:7289") 
        

});

builder.Services.AddScoped(sp =>
{
    var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7289") };
    httpClient.DefaultRequestHeaders.Add("cnpj", "42591651000143");
    return httpClient;
});


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



app.Run();
