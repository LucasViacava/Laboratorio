using Laboratorio.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de la cadena de conexi�n de la base de datos
builder.Services.AddDbContext<RestauranteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LaboratorioDb")));

// Configuraci�n de JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Validar el emisor
            ValidateAudience = true, // Validar la audiencia
            ValidateLifetime = true, // Validar que el token no est� expirado
            ValidateIssuerSigningKey = true, // Validar la firma del token
            ValidIssuer = builder.Configuration["Jwt:Issuer"], // Emisor v�lido (definido en appsettings.json)
            ValidAudience = builder.Configuration["Jwt:Audience"], // Audiencia v�lida (definido en appsettings.json)
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])) // Clave de firma
        };
    });

// Servicios adicionales
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Manejador global de excepciones
app.UseExceptionHandler(configureOptions =>
{
    configureOptions.Run(async context =>
    {
        var exceptionHandler = context.Features.Get<IExceptionHandlerFeature>();
        var exception = exceptionHandler?.Error;

        context.Response.StatusCode = (int)HttpStatusCode.Conflict;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new { estatus = 409, message = "Ocurri� un error", cause = exception?.Message });
    });
});

// Configuraci�n del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar autenticaci�n y autorizaci�n
app.UseAuthentication(); // JWT middleware
app.UseAuthorization();

// Mapear los controladores
app.MapControllers();

app.Run();
