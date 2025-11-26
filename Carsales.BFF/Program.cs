using Carsales.BFF.Application.Interfaces;
using Carsales.BFF.Application.Services;
using Carsales.BFF.Infraestructure.External;
using Carsales.BFF.Infrastructure.External;
using Serilog;



Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
/*Esto hace que toda la app use Serilog de forma nativa.*/

/*configuracion desde appsettings.json*/
var rickAndMortyConfig = builder.Configuration.GetSection("RickAndMortyApi");
builder.Services.Configure<RickAndMortyApiOptions>(rickAndMortyConfig);

/*REGISTRO DE SERVICIOS DEL BFF (DI)*/
builder.Services.AddScoped<IRickAndMortyService, RickAndMortyService>();


// 3. HTTP CLIENT (Adapter Pattern)
builder.Services.AddHttpClient<IRickAndMortyApiClient, RickAndMortyApiClient>(client =>
{
    client.BaseAddress = new Uri(rickAndMortyConfig["BaseUrl"]!);
});


// Add services to the container.

/*controllers*/
builder.Services.AddControllers();

/*registra MemoryCache en el IoC container.*/
builder.Services.AddMemoryCache();

/*CORS*/
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

/*swagger*/
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
app.UseMiddleware<Carsales.BFF.Middleware.ErrorHandlingMiddleware>();


app.UseAuthorization();

app.UseCors("AllowAngular");

app.MapControllers();

app.Run();
