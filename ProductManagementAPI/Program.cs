using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NativApps.Products.Core.Repositories;
using NativApps.Products.Core.Services;
using NativApps.Products.Core.Services.Impl;
using NativApps.Products.Data;
using NativApps.Products.Data.Repositories;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Agrega los servicios al contenedor de dependencias.
builder.Services.AddControllers();

// Carga la configuración desde appsettings.json
var configuration = builder.Configuration;

// Configura Entity Framework y SQL Server
builder.Services.AddDbContext<ProductDBContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("ProductsDBConexion")));

// Configura autenticación y JWT
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });

// Registra los servicios de la aplicación y los repositorios
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Configura AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Configura Swagger para la documentación de la API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Product Management API", Version = "v1" });

    // Configuración para Swagger y JWT
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Bearer token required. Please enter your JWT token preceded by 'Bearer ' in the format 'Bearer {token}'",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    var securityRequirement = new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference { Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    };
    c.AddSecurityRequirement(securityRequirement);
});

var app = builder.Build();

// Configura el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Management API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
