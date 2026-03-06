
using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using DA;
using DA.Repositorio;
using Flujo;
using Reglas;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IProductoFlujo, ProductoFlujo>();
builder.Services.AddScoped<IProductoDA, ProductoDA>();
builder.Services.AddScoped<IPromocionFlujo, PromocionFlujo>();
builder.Services.AddScoped<IPromocionDA, PromocionDA>();
builder.Services.AddScoped<IPedidoFlujo, PedidoFlujo>();
builder.Services.AddScoped<IPedidoDA, PedidoDA>();
builder.Services.AddScoped<IReservaFlujo, ReservaFlujo>();
builder.Services.AddScoped<IReservaDA, ReservaDA>();
builder.Services.AddScoped<IMenuFlujo, MenuFlujo>();
builder.Services.AddScoped<IMenuDA, MenuDA>();
builder.Services.AddScoped<IDetalleFlujo, DetalleFlujo>();
builder.Services.AddScoped<IDetalleDA, DetalleDA>();

builder.Services.AddScoped<IUsuarioFlujo, UsuarioFlujo>();
builder.Services.AddScoped<IUsuarioDA, UsuarioDA>();
builder.Services.AddScoped<IClienteFlujo, ClienteFlujo>();
builder.Services.AddScoped<IClienteDA, ClienteDA>();
builder.Services.AddScoped<IEmpleadoFlujo, EmpleadoFlujo>();
builder.Services.AddScoped<IEmpleadoDA, EmpleadoDA>();
builder.Services.AddScoped<IRolFlujo, RolFlujo>();
builder.Services.AddScoped<IRolDA, RolDA>();


builder.Services.AddScoped<IRestauranteFlujo, RestauranteFlujo>();
builder.Services.AddScoped<IRestauranteDA, RestauranteDA>();
builder.Services.AddScoped<IRepositorioDapper, RepositorioDapper>();
builder.Services.AddScoped<IConfiguracion, Configuracion>();





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