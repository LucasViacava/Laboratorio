using Laboratorio.Data;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Agregar el contexto de la base de datos
builder.Services.AddDbContext<RestauranteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LaboratorioDb")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddExceptionHandler(configureOptions =>
{
    configureOptions.ExceptionHandler = new RequestDelegate(async context =>
    {

        IExceptionHandlerFeature? exceptionHandler = context.Features.Get<IExceptionHandlerFeature>();
        Exception? exception = exceptionHandler?.Error;

        context.Response.StatusCode = (int)HttpStatusCode.Conflict;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new { estatus = 409, message = "ocurrio un error", cause = exception?.Message });

    });

});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
