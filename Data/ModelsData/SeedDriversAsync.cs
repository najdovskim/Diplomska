using JsonToDbTest.Models;

namespace JsonToDbTest.Data.ModelsData
{
   public class DataSeeder
{
    private readonly ErgastService _ergastService;
    private readonly DataContext _dataContext;

    public DataSeeder(ErgastService ergastService, DataContext dataContext)
    {
        _ergastService = ergastService;
        _dataContext = dataContext;
    }

    public async Task SeedDriversAsync(string season)
    {
        try
        {
            var drivers = await _ergastService.GetDriversAsync(season);

            if (drivers != null && drivers.MRData.DriverTable.Drivers != null)
            {
                foreach (var driver in drivers.MRData.DriverTable.Drivers)
                {
                    var newDriver = new Driver
                    {
                        DriverId = driver.DriverId,
                        GivenName = driver.GivenName,
                        FamilyName = driver.FamilyName,
                        Nationality = driver.Nationality,
                        Url = driver.Url
                    };

                    _dataContext.Drivers.Add(newDriver);
                }

                await _dataContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Error: drivers object is null");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public async Task SeedConstructorsAsync(string season)
    {
        try
        {
            var constructors = await _ergastService.GetConstructorsAsync(season);

            if (constructors != null && constructors.MRData.ConstructorTable.Constructors != null)
            {
                foreach (var constructor in constructors.MRData.ConstructorTable.Constructors)
                {
                    var newConstructor = new Constructor
                    {
                        ConstructorId = constructor.ConstructorId,
                        Name = constructor.Name,
                        Nationality = constructor.Nationality,
                        Url = constructor.Url
                    };

                    _dataContext.Constructors.Add(newConstructor);
                }

                await _dataContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Error: constructors object is null");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
}
