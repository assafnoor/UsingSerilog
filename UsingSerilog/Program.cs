using Microsoft.Extensions.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
configurationlog();
builder.Host.UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();


#region helper
void configurationlog()
{
    var config=new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(config) 
        .CreateLogger();
	try
	{
		Log.Information("App Sarting");
	}
	catch (Exception)
	{

		throw;
	}
}
#endregion