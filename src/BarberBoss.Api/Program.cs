using BarberBoss.Api.Filters;
using BarberBoss.Api.Midleware;
using BarberBoss.Application;
using BarberBoss.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(opt =>
{
    opt.Filters.Add(typeof(ExceptionFilter));
});

builder.Services.AddApplication();
builder.Services.AddInfraestructure(builder.Configuration);
//builder.Services.AddRepository();
//DependencyInjectionExtension.AddApplication(builder.Services);


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMidleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
