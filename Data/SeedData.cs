using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JsonToDbTest.Data;
using JsonToDbTest.Models;
using JsonToDbTest.RootTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

namespace JsonToDbTest
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var httpClient = new HttpClient();
            var ergastService = new ErgastService(httpClient) { BaseUrl = "http://ergast.com/api/f1" };

            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("Default");

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(connectionString);

           using (var context = serviceProvider.GetRequiredService<DataContext>())
            {
                try
                {
                    /*var drivers = await ergastService.GetDriversAsync("2020");

                    if (drivers != null && drivers.MRData != null && drivers.MRData.DriverTable.Drivers != null) // && drivers.MRData.ConstructorTable != null)
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
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }*/


                    // Null insert in table
                    /* var circuits = await ergastService.GetCircuitsAsync("2020");

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


                 catch (Exception ex)
                 {
                     Console.WriteLine("Error: " + ex.Message);
                 }*/


                    /*    var constructors = await ergastService.GetConstructorsAsync("2020");

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
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }*/

                    /*var seasons = await ergastService.GetSeasonsAsync();
                    Console.WriteLine(seasons);

                    if (seasons != null && seasons.MRData != null && seasons.MRData.SeasonTable.Seasons != null)
                    {
                        foreach (var season in seasons.MRData.SeasonTable.Seasons)
                        {
                            var newSeason = new Season
                            {
                                RaceId = race.RaceId,
                                raceName = race.raceName,
                                Date = race.Date,
                                Time = race.Time,
                                //SeasonId = int.Parse("2020"),
                            };

                            context.Seasons.Add(newSeason);
                        }

                        await context.SaveChangesAsync();
                    }


                    else
                    {
                        Console.WriteLine("Error: drivers object is null");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }*/                
                var year = "2020";
                var races = await ergastService.GetRacesAsync(year);
                
                // Retrieve existing circuits and create a dictionary to map names to IDs
                var circuitNameToIdMap = await context.Circuits.ToDictionaryAsync(c => c.CircuitName, c => c.CircuitId);

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
        }
    }
}
}
