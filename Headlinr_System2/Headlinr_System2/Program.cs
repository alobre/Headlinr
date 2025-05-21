using Headlinr_System2.Models;
using Headlinr_System2.Repository;
using Headlinr_System2.Services.Rss;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Dependencies
builder.Services.AddSingleton<HeadlinrConfigurationProvider>();
builder.Services.AddSingleton<NewsRepository>();
builder.Services.AddTransient<RssService>();

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
