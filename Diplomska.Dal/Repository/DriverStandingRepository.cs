using Diplomska.Dal.Interfaces;
using Diplomska.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Dal.Repository
{
    public class DriverStandingRepository : IDriverStandingRepository
    {
        public readonly DataContext _ctx;

        public DriverStandingRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<DriverStanding>> GetDriverStandingByRound(int seasonId, int round)
        {

            var driverStanding = await _ctx.DriverStandings.Where(d => d.SeasonsId == seasonId && d.Round == round).ToListAsync();
           

            if (driverStanding == null)
                return null;

            return driverStanding;
        }       

       
        public async Task<List<DriverStanding>> GetAllDriverStandings(int seasonId)
        {
            return await _ctx.DriverStandings.ToListAsync();
        }

        public async Task<TransformedData> GetStandingsForDriver(string driverId)
        {           

            var driverstandings = await _ctx.DriverStandings.Where(d => d.DriverId == driverId).ToListAsync();
            List<int> round = new List<int>();
            string driver;
            string team = "";
            

            foreach (var driverstanding in driverstandings)
            {
                int points = int.Parse(driverstanding.Points);
                round.Add(points);
                team = driverstanding.ConstructorId;
            }
            var dto = new TransformedData
            {
                DriverId = driverId,
                ConstructorId = team, // If you have this information
                Round = round // Assign the entire list to the Round property
            };

            return dto;              

        }

        public async Task<List<DriverStanding>> GetStandingsForConstructor(string constructorId)
        {
            var driverStandings = await _ctx.DriverStandings
                .Where(d => d.ConstructorId == constructorId)
                .ToListAsync();

            return driverStandings;

            /*
            List<int> round = new List<int>();           
            string team = constructorId;


               foreach (var driverstanding in driverstandings)
                {
                    int points = int.Parse(driverstanding.Points);
                    round.Add(points);                
                }
                var dto = new TransformedDataForConstructor
                {                
                    ConstructorId = team, // If you have this information
                    Round = round // Assign the entire list to the Round property
                };

                return dto;
    */

        }


        private List<DriverStanding> Exeption()
        {
            throw new NotImplementedException("error");
        }
    }
}
