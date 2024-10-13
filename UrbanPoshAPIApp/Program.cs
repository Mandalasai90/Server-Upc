using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Urban.BAL;
using Urban.DAL.Contexts;
using Urban.DAL.Models;
using Urban.DAL.UPCService;
using UrbanPoshAPIApp.Repository.UPCServices;
using UrbanPoshAPIApp.UrbanServices;
using AuthenticationService = UrbanPoshAPIApp.UrbanServices.AuthenticationService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UPCDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UPCConnection"), b => b.MigrationsAssembly("UrbanPoshAPIApp")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUPCDbServices,UPCDBServices>();
builder.Services.AddScoped<IUPCServiceRepo,UPCServicesRepo>();
builder.Services.AddScoped<UPCServicesHelper>();
// Register the custom services
var issuer = builder.Configuration["Keycloak:Authority"];
var audience = builder.Configuration["Keycloak:ClientId"];   // "<your-client-id>";
var secretKey = builder.Configuration["Keycloak:ClientSecret"]; // If using confidential clients

var authService = new AuthenticationService(issuer, audience, secretKey);
var authorizationService = new AuthorizationService();

// Register services in the DI container
builder.Services.AddSingleton(authService);
builder.Services.AddSingleton(authorizationService);

// Configure JWT Bearer authentication
ConfigureAuthentication(builder, authService);
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

// Middleware for authentication and authorization
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingUPCMiddleware>();
app.MapControllers();

app.Run();
// Separate method to configure authentication
void ConfigureAuthentication(WebApplicationBuilder builder, AuthenticationService authService)
{
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = authService.GetTokenValidationParameters();
    });
}
