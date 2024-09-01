using Strategy.Factory;
using Strategy.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<PagamentoFactory>();

//https://github.com/khellang/Scrutor
builder.Services.Scan(scan =>
   scan.FromAssembliesOf(typeof(Program))
   .AddClasses(classes => classes.AssignableTo<IServices>())
         .AsImplementedInterfaces()
         .WithScopedLifetime()
   .AddClasses(classes => classes.AssignableTo<IFacade>())
         .AsImplementedInterfaces()
         .WithScopedLifetime()
);

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
