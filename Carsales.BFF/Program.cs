using Carsales.BFF.Application.Interfaces;
using Carsales.BFF.Application.Services;
using Carsales.BFF.Infrastructure.External;

var builder = WebApplication.CreateBuilder(args);
var rickAndMortyConfig = builder.Configuration.GetSection("RickAndMortyApi");
builder.Services.Configure<RickAndMortyApiOptions>(rickAndMortyConfig);
builder.Services.AddScoped<IRickAndMortyService, RickAndMortyService>();

//HTTP CLIENT (Adapter Pattern)
builder.Services.AddHttpClient<IRickAndMortyApiClient, RickAndMortyApiClient>(client =>
{
    client.BaseAddress = new Uri(rickAndMortyConfig["BaseUrl"]!);
});

//controllers
builder.Services.AddControllers();

//registra MemoryCache en el IoC container
builder.Services.AddMemoryCache();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

//swagger
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
