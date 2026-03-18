
using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Autorizacion.Middleware;
using DA;
using DA.Repositorio;
using Flujo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Reglas;
using System.Net;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var tokenConfig = builder.Configuration.GetSection("Token").Get<TokenConfiguracion>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenConfig.Issuer,
            ValidAudience = tokenConfig.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfig.key))
        };
    });


builder.Services.AddControllers();
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

builder.Services.AddTransient<Autorizacion.Abstracciones.Flujo.IAutorizacionFlujo,
                               Autorizacion.Flujo.AutorizacionFlujo>();
builder.Services.AddTransient<Autorizacion.Abstracciones.DA.ISeguridadDA,
                               Autorizacion.DA.SeguridadDA>();
builder.Services.AddTransient<Autorizacion.Abstracciones.DA.IRepositorioDapper,
                               Autorizacion.DA.Repositorios.RepositorioDapper>();

var politicaAcceso = "Politica de acceso";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: politicaAcceso,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost", "https://localhost:7280", "https://localhost:7253")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(politicaAcceso);
app.AutorizacionClaims();
app.UseAuthorization();
app.MapControllers();

app.Run();