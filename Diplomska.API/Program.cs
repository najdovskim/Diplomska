using AutoMapper;
using Diplomska.Dal;
using Diplomska.Dal.Data;
using Diplomska.Dal.Interfaces;
using Diplomska.Dal.Repository;
using Diplomska.Service.Automapper;
using Diplomska.Service.Interfaces;
using Diplomska.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(cs);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});



var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new CircuitMappingProfile());
    mc.AddProfile(new ConstructorMappingProfile());
    mc.AddProfile(new DriverMappingProfile());
    mc.AddProfile(new DriverStandingMappingProfile());
    mc.AddProfile(new RaceMappingProfile());
    mc.AddProfile(new ResultMappingProfile());
    mc.AddProfile(new SeasonMappingProfile());
    mc.AddProfile(new TransformedDataMappingProfile());
});
//builder.Services.AddAutoMapperProfile<CircuitMappingProfile>();
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper); 
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IFromula1Repository, Fromula1Repository>();
builder.Services.AddScoped<IFormula1Service, Formula1Service>();

builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IDriverService, DriverService>();

builder.Services.AddScoped<IConstructorRepository, ConstructorRepository>();
builder.Services.AddScoped<IConstructorService, ConstructorService>();

builder.Services.AddScoped<ICircuitRepository, CircuitRepository>();
builder.Services.AddScoped<ICircuitService, CircuitService>();

builder.Services.AddScoped<ISeasonRepository, SeasonRepository>();
builder.Services.AddScoped<ISeasonService, SeasonService>();

builder.Services.AddScoped<IRaceRepository, RaceRepository>();
builder.Services.AddScoped<IRaceService, RaceService>();

builder.Services.AddScoped<IDriverStandingRepository, DriverStandingRepository>();
builder.Services.AddScoped<IDriverStandingService, DriverStandingService>();

builder.Services.AddScoped<ITransformedData, TransformedDataService>();


builder.Services.AddScoped<SeedData>();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));





var app = builder.Build();
/*
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var seedData = services.GetRequiredService<SeedData>(); 
        await seedData.InitializeAsync(services); 
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
*/



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
