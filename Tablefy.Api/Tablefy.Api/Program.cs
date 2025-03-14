using AutoMapper;
using Tablefy.Api.Company.Services;
using Tablefy.Api.Data;
using Tablefy.Api.Product.Services;
using Tablefy.Order.Api.Data;
using Tablefy.Order.Api.Order.Entities.Profiles;
using Tablefy.Order.Api.Order.Services;
using Tablefy.Order.Api.Table;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ProductErpService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<TableService>();
builder.Services.AddScoped<ProductMenuService>();
builder.Services.AddAutoMapper(typeof(TablefyContext));
builder.Services.AddAutoMapper(typeof(OrderProfile));
builder.Services.AddDbContext<TablefyContext>();
builder.Services.AddDbContext<TablefyOrderContext>();
builder.Services.AddControllers().AddApplicationPart(typeof(TablefyOrderContext).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
