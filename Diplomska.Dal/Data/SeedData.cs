using Diplomska.Dal.RootTable;
using Diplomska.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Diplomska.Dal.Data
{
    public class SeedData
    {
        private readonly DataContext _data;
        public SeedData(DataContext data) => _data = data;


        public async Task InitializeAsync(IServiceProvider serviceProvider)
        {

            var httpClient = new HttpClient();
            var ergastService = new ErgastService(httpClient) { BaseUrl = "http://ergast.com/api/f1" };

            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("Default");


            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(connectionString);



            using (var context = serviceProvider.GetRequiredService<DataContext>())
            {
                /*  await SeedCircuitData(context, ergastService);
                  await SeedDriversData(context, ergastService);
                  await SeedConstructorData(context, ergastService);
                  await SeedSeasonData(context, ergastService);*/
                //await SeedRaceData(context, ergastService);
                //await SeedRaceDataNew(context, ergastService);

                try
                {
                    var seasonYear = 2021;
                    int raceRound = 1;

                    string season = seasonYear.ToString();

                    while (true) // Continue fetching data until there is no more data
                    {
                        var standingsData = await ergastService.GetDriverStandings(season, raceRound);

                        // Check if the response contains the expected data structure                        
                        if (standingsData == null || standingsData.MRData == null || standingsData.MRData.StandingsTable == null)
                        {
                            Console.WriteLine("API response does not contain the expected data structure.");
                            Console.WriteLine(standingsData);
                            break; // Break out of the loop if data is not as expected
                        }

                        // Save driver standings data to the database for the current round
                        foreach (var driverStanding in standingsData.MRData.StandingsTable.StandingsLists.FirstOrDefault()?.Driverstandings)
                        {
                            if (driverStanding == null)
                            {
                                break;
                            }

                            // Ensure you construct the composite key for DriverStanding
                            var seasonId = seasonYear;
                            var round = raceRound;
                            var driverId = driverStanding.Driver.DriverId;

                            // Check if a DriverStanding record already exists for the current season, round, and driver
                            var existingDriverStanding = _data.DriverStandings.FirstOrDefault(ds =>
                                ds.SeasonsId == seasonId &&
                                ds.Round == round &&
                                ds.DriverId == driverId);

                            if (existingDriverStanding == null)
                            {
                                // Create a new DriverStanding entity
                                var newDriverStanding = new DriverStanding
                                {
                                    SeasonsId = seasonId,
                                    Round = round,
                                    DriverId = driverId,
                                    Position = driverStanding.Position,
                                    positionText = driverStanding.PositionText,
                                    Points = driverStanding.Points,
                                    Wins = driverStanding.Wins,
                                    ConstructorId = driverStanding.Constructors?.FirstOrDefault()?.ConstructorId
                                };

                                // Add the new DriverStanding to the context
                                _data.DriverStandings.Add(newDriverStanding);
                            }
                            else
                            {
                                // Update the existing DriverStanding record if needed
                                existingDriverStanding.Position = driverStanding.Position;
                                existingDriverStanding.positionText = driverStanding.PositionText;
                                existingDriverStanding.Points = driverStanding.Points;
                                existingDriverStanding.Wins = driverStanding.Wins;
                                existingDriverStanding.ConstructorId = driverStanding.Constructors?.FirstOrDefault()?.ConstructorId;
                            }
                        }

                        await _data.SaveChangesAsync(); // Save all changes to the database

                        raceRound++; // Increment the round for the next iteration
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Exception innerException = ex;
                    while (innerException.InnerException != null)
                    {
                        innerException = innerException.InnerException;
                    }

                    Console.WriteLine("Error: " + innerException.Message);
                }







                /*

                                try
                                  {
                                      var seasonYear = 2020;
                                      int raceRound = 17;

                                      string season = seasonYear.ToString();

                                      while (true) // Continue fetching data until there is no more data
                                      {
                                          var standingsData = await ergastService.GetDriverStandings(season, raceRound);

                                          // Check if the response contains the expected data structure                        
                                          if (standingsData == null || standingsData.MRData == null || standingsData.MRData.StandingsTable == null)
                                          {
                                              Console.WriteLine("API response does not contain expected data structure.");
                                              Console.WriteLine(standingsData);
                                              break; // Break out of the loop if data is not as expected
                                          }

                                          // Save driver standings data to the database for the current round
                                          foreach (var driverStanding in standingsData.MRData.StandingsTable.StandingsLists.FirstOrDefault()?.Driverstandings)
                                          {
                                              if (driverStanding == null)
                                              {
                                                  break;
                                              }
                                              var apiDriverStanding = new Driverstanding
                                              {

                                                  Position = driverStanding.Position,
                                                  PositionText = driverStanding.PositionText,
                                                  Points = driverStanding.Points,
                                                  Wins = driverStanding.Wins,
                                                  Driver = new Driver { DriverId = driverStanding.Driver.DriverId },
                                                  Constructors = driverStanding?.Constructors,
                                              };

                                              // Translate data from Driverstanding to DriverStanding (for the database)
                                              var dbDriverStanding = new DriverStanding
                                              {
                                                  Position = apiDriverStanding.Position,
                                                  positionText = apiDriverStanding.PositionText,
                                                  Points = apiDriverStanding.Points,
                                                  Wins = apiDriverStanding.Wins,
                                                  DriverId = apiDriverStanding.Driver.DriverId,
                                                  SeasonsId = seasonYear,
                                                  ConstructorId = apiDriverStanding.Constructors?.FirstOrDefault()?.ConstructorId
                                              };

                                              _data.DriverStandings.Add(dbDriverStanding);  // Save to database context
                                          }

                                          await _data.SaveChangesAsync(); // Save all changes to the database

                                          raceRound++; // Increment the round for the next iteration
                                      }
                                  }
                                  catch (Exception ex)
                                  {
                                      Console.WriteLine("Error: " + ex.Message);
                                      Exception innerException = ex;
                                      while (innerException.InnerException != null)
                                      {
                                          innerException = innerException.InnerException;
                                      }

                                      Console.WriteLine("Error: " + innerException.Message);
                                  }*/
            }

        }
       

        private async Task SeedDriversData(DataContext context, ErgastService ergastService)
        {
            var drivers = await ergastService.GetDriversAsync("2020");

            if (drivers != null && drivers.MRData != null && drivers.MRData.DriverTable.Drivers != null)
            {
                if (drivers.MRData.DriverTable.Drivers != null)
                {
                    foreach (var driver in drivers.MRData.DriverTable.Drivers)
                    {
                        var newDriver = new Driver
                        {
                            DriverId = driver.DriverId,
                            PermanentNumber = driver.PermanentNumber,
                            Code = driver.Code,
                            GivenName = driver.GivenName,
                            FamilyName = driver.FamilyName,
                            Nationality = driver.Nationality,
                            DateOfBirth = driver.DateOfBirth,
                            Url = driver.Url
                        };

                        context.Drivers.Add(newDriver);
                    }

                    await context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("Error: drivers object is null");
                }
            }
        }
        private async Task SeedConstructorData(DataContext context, ErgastService ergastService)
        {
            var constructors = await ergastService.GetConstructorsAsync("2020");

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

                    context.Constructors.Add(newConstructor);
                }

                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Error: constructors object is null");
            }
        }

        private async Task SeedRaceData(DataContext context, ErgastService ergastService)
        {
            var year = "2020";
            var races = await ergastService.GetRacesAsync(year);
            //var GetSeasonId = await _data.

            // Retrieve existing circuits and create a dictionary to map names to IDs
            var circuitNameToIdMap = await context.Circuits.AsNoTracking().ToDictionaryAsync(c => c.CircuitName, c => c.CircuitId);

            if (races != null && races.MRData != null && races.MRData.RaceTable.Races != null)
            {
                foreach (var apiRace in races.MRData.RaceTable.Races)
                {
                    var newRace = new Race
                    {
                        raceName = apiRace.RaceName,
                        Date = apiRace.Date,
                        Time = apiRace.Time
                    };

                    // Establish foreign key relationship with Season
                    newRace.SeasonId = int.Parse(year);

                    if (circuitNameToIdMap.TryGetValue(apiRace.Circuit.CircuitName, out var circuitId))
                    {
                        newRace.CircuitId = circuitId;
                    }

                    context.Races.Add(newRace);
                }

                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Error: race data is null or empty");
            }
        }


        public async Task SeedRaceDataNew(DataContext context, ErgastService ergastService)
        {
            var season = "2020"; // You can change this season as needed.

            var rRaces = await ergastService.GetRacesAsync(season);

            foreach (var rRace in rRaces.MRData.RaceTable.Races)
            {
                // Create or update the corresponding Race entity
                var race = await context.Races.FirstOrDefaultAsync(r => r.RaceId == int.Parse(rRace.Round));

                if (race == null)
                {
                    race = new Race
                    {
                        RaceId = int.Parse(rRace.Round),
                        raceName = rRace.RaceName,
                        Date = rRace.Date,
                        Time = rRace.Time,
                        SeasonId = int.Parse(season), // Assuming SeasonId is an int
                        CircuitId = rRace.Circuit.CircuitId
                        // You need to set other properties as needed
                    };
                    context.Races.Add(race);
                }
                else
                {
                    // Update the existing entity
                    race.raceName = rRace.RaceName;
                    race.Date = rRace.Date;
                    race.Time = rRace.Time;
                    race.CircuitId = rRace.Circuit.CircuitId;
                    // Update other properties if needed
                }
            }

            await context.SaveChangesAsync();
        }




        private async Task SeedSeasonData(DataContext context, ErgastService ergastService)
        {
            for (int year = 1950; year <= 2023; year++)
            {
                var newSeason = new Season
                {
                    SeasonId = year
                };

                context.Seasons.Add(newSeason);
            }

            await context.SaveChangesAsync();
        }

        private async Task SeedCircuitData(DataContext context, ErgastService ergastService)
        {
            var circuits = await ergastService.GetCircuitsAsync("2020");

            if (circuits != null && circuits.MRData != null && circuits.MRData.CircuitTable.Circuits != null)
            {
                foreach (var circuit in circuits.MRData.CircuitTable.Circuits)
                {
                    var newCircuit = new Circuit
                    {
                        CircuitId = circuit.CircuitId,
                        CircuitName = circuit.CircuitName
                    };

                    context.Circuits.Add(newCircuit);
                }

                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Error: drivers object is null");
            }
        }
    }

}
