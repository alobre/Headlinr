using System.ServiceModel;
using Headlinr_System2.Models;
using Headlinr_System2.Repository;
using Headlinr_System2.Services;
using Headlinr_System2.Services.Rss;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSoapCore();


//Dependencies
builder.Services.AddSingleton<HeadlinrConfigurationProvider>();
builder.Services.AddSingleton<NewsRepository>();
builder.Services.AddTransient<RssService>();
builder.Services.AddTransient<JsonNewsFeedService>();
builder.Services.AddTransient<SoapNewsFeedService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors();
app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<SoapNewsFeedService>("/SoapNewsFeedService.asmx", new
        SoapEncoderOptions(), SoapSerializer.XmlSerializer);
    endpoints.MapControllers();
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.Run();
