using JsonToDbTest;
using JsonToDbTest.Data;
using JsonToDbTest.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var cs = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<DataContext>(options => { options.UseSqlServer(cs); });   

   
    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
    var services = scope.ServiceProvider;
    try
    {
        SeedData.InitializeAsync(services).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}




/*
using JsonToDbTest;
using JsonToDbTest.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(options => { options.UseSqlServer(cs); });


var app = builder.Build();


// Call SeedData to populate the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.InitializeAsync(services).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}*/

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
*/

//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
//using JsonToDbTest.Data;
//using JsonToDbTest.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

/*class Program
{
    static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        IConfigurationRoot configuration = builder.Build();

        var connectionString = configuration.GetConnectionString("Default");

        var services = new ServiceCollection();

        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddTransient<ErgastService>();

        services.AddHttpClient<ErgastService>(client =>
        {
            client.BaseAddress = new Uri("http://ergast.com/api/f1");
        });

        var serviceProvider = services.BuildServiceProvider();

        var ergastService = serviceProvider.GetService<ErgastService>();

        try
        {
            var constructors = await ergastService.GetConstructorsAsync("2020");

            if (constructors != null && constructors.MRData.ConstructorTable.Constructors != null)
            {
                foreach (var constructor in constructors.MRData.ConstructorTable.Constructors)
                {
                    Console.WriteLine(constructor.Name);

                    // Create a new instance of the DataContext and add the Constructor to the database
                    using (var context = new DataContext(new DbContextOptions<DataContext>()))
                    {
                        var newConstructor = new Constructor
                        {
                            ConstructorId = constructor.ConstructorId,
                            Name = constructor.Name,
                            Nationality = constructor.Nationality,
                            Url = constructor.Url
                        };

                        try
                        {
                            context.Constructors.Add(newConstructor);
                            context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error saving constructor to the database: " + ex.Message);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error getting constructors from Ergast API: " + ex.Message);
        }
    }
}
*/

