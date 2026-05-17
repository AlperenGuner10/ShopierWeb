using Shopier.Application.Interfaces;
using Shopier.Application.Usecases.CartItemsServices;
using Shopier.Application.Usecases.CartServices;
using Shopier.Application.Usecases.CategoryServices;
using Shopier.Application.Usecases.CustomerServices;
using Shopier.Application.Usecases.OrderItemItemServices;
using Shopier.Application.Usecases.OrderItemServices;
using Shopier.Application.Usecases.OrderServices;
using Shopier.Application.Usecases.ProductServices;
using Shopier.Persistance.Context;
using Shopier.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderItemItemService, OrderItemService>();
builder.Services.AddScoped<IProductServices, ProductService>();
builder.Services.AddScoped<ICartServices, CartServices>();
builder.Services.AddScoped<ICartItemServices, CartItemServices>();


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
