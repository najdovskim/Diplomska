using System;
using System.Net.Http;
using System.Threading.Tasks;
using JsonToDbTest.Models;
using JsonToDbTest.RootTable;
using Newtonsoft.Json;

public class ErgastService
{
    private readonly HttpClient _httpClient;
    private string _baseUrl;

    public ErgastService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public string BaseUrl
    {
        get => _baseUrl;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Base URL cannot be null or empty.", nameof(value));
            }

            _baseUrl = value.TrimEnd('/');
        }
    }

    public async Task<DriverRoot> GetDriversAsync(string season)
    {
        if (string.IsNullOrWhiteSpace(season))
        {
            throw new ArgumentException("Season cannot be null or empty.", nameof(season));
        }

        var response = await _httpClient.GetAsync($"http://ergast.com/api/f1/{season}/drivers.json");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<DriverRoot>(content);
    }
    public async Task<CircuitRoot> GetCircuitsAsync(string season)
    {
        if (string.IsNullOrWhiteSpace(season))
        {
            throw new ArgumentException("Season cannot be null or empty.", nameof(season));
        }

        var response = await _httpClient.GetAsync($"http://ergast.com/api/f1/{season}/circuits.json");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<CircuitRoot>(content);
    }
    public async Task<ConstructorRoot> GetConstructorsAsync(string season)
    {
        if (string.IsNullOrWhiteSpace(season))
        {
            throw new ArgumentException("Season cannot be null or empty.", nameof(season));
        }

        var response = await _httpClient.GetAsync($"http://ergast.com/api/f1/{season}/constructors.json");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ConstructorRoot>(content);
    }

    public async Task<RaceRoot> GetRacesAsync(string season)
    {
        if (string.IsNullOrWhiteSpace(season))
        {
            throw new ArgumentException("Season cannot be null or empty.", nameof(season));
        }

        var response = await _httpClient.GetAsync($"http://ergast.com/api/f1/{season}/races.json");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<RaceRoot>(content);
    }
    public async Task<SeasonRoot> GetSeasonsAsync()
    {
        var response = await _httpClient.GetAsync($"http://ergast.com/api/f1/seasons.json");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<SeasonRoot>(content);
    }
    /*  public async Task<DriverStandingRoot> GetDriverStandings(string season)
      {
          if (string.IsNullOrWhiteSpace(season))
          {
              throw new ArgumentException("Season cannot be null or empty.", nameof(season));
          }
          var response = await _httpClient.GetAsync($"http://ergast.com/api/f1/{season}/1/driverStandings");
          response.EnsureSuccessStatusCode();
          var content = await response.Content.ReadAsStringAsync();
          return JsonConvert.DeserializeObject<DriverStandingRoot>(content);
      }*/

    /* private async Task<DriverStandingRoot> GetDriverStandingsAsync(string season, int raceNumber)
     {
         try
         {
             var response = await _httpClient.GetAsync($"http://ergast.com/api/f1/{season}/{raceNumber}/driverStandings");
             response.EnsureSuccessStatusCode();
             var content = await response.Content.ReadAsStringAsync();
             return JsonConvert.DeserializeObject<DriverStandingRoot>(content);
         }
         catch (Exception ex)
         {
             Console.WriteLine($"Error fetching data for race {raceNumber}: {ex.Message}");
             return null;
         }
     }*/

    public async Task<DriverStandingRoot> GetDriverStandings(string season, int round)
    {
        if (string.IsNullOrWhiteSpace(season))
        {
            throw new ArgumentException("Season cannot be null or empty.", nameof(season));
        }

        var response = await _httpClient.GetAsync($"http://ergast.com/api/f1/{season}/{round}/driverStandings.json");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<DriverStandingRoot>(content);
    }
 
}