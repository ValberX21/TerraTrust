using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TerraTrust.API.Middlewares;
using TerraTrust.Business.Handlers;
using TerraTrust.Business.Validators;
using TerraTrust.Core.Interfaces;
using TerraTrust.Core.Interfaces.Repositories;
using TerraTrust.Data.Context;
using TerraTrust.Data.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<CreatePropertyHandler>());

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork>(sp =>
    sp.GetRequiredService<ApplicationDbContext>());

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TerraTrust API V1");
    c.RoutePrefix = string.Empty; 
});

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization(); 

app.MapControllers();

app.Run();
