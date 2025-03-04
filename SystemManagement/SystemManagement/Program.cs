

using Microsoft.OpenApi.Models;
using Mysqlx.Crud;
using SystemManagement.Dao;
using SystemManagement.DAO;
using SystemManagement.Data;
using SystemManagement.Middlewares;
using SystemManagement.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<ConnectionFabric>();
builder.Services.AddSingleton<OrderDao>();
builder.Services.AddSingleton<CategoryDao>();
builder.Services.AddSingleton<ProductDao>();
builder.Services.AddSingleton<GrupoDao>();
builder.Services.AddSingleton<CheckDao>();
builder.Services.AddSingleton<ComboDao>();
builder.Services.AddSingleton<StoreDao>();
builder.Services.AddSingleton<IngredientDao>();
builder.Services.AddSingleton<HeaderService>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Add Security Definition for "cnpj" Header
    c.AddSecurityDefinition("CnpjHeader", new OpenApiSecurityScheme
    {
        Description = "Enter your CNPJ (e.g., 12345678000195) in the header.",
        Type = SecuritySchemeType.ApiKey,
        Name = "cnpj",
        In = ParameterLocation.Header,
        Scheme = "CnpjHeader"
    });

    // Add Security Requirement for All Endpoints
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "CnpjHeader"
                }
            },
            Array.Empty<string>()
        }
    });
});


var app = builder.Build();

app.UseMiddleware<HeaderMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
