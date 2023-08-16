using JsonToDbTest.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonToDbTest.Models
{
    public class Result
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int numberId { get; set; }
        public int position { get; set; }
        public string positionText { get; set; }
        public int points { get; set; }
        public int grid { get; set; }
        public int laps { get; set; }
        public string status { get; set; }
        public string fastestLap { get; set; }

        [ForeignKey("ConstructorId")]
        public string ConstructorId { get; set; }
        public Constructor Constructor { get; set; }

        [ForeignKey("DriverId")]
        public string DriverId { get; set; }
        public Driver Driver { get; set; }

        [ForeignKey("RaceId")]
        public int RaceId { get; set; }
        public Race Race { get; set; }

        public async Task EnsureConstructorExistsAsync(DataContext context)
        {
            // Try to find an existing constructor entity with the same id
            var existingConstructor = await context.Constructors.FindAsync(ConstructorId);

            if (existingConstructor == null)
            {
                // If the constructor doesn't exist, create a new one and add it to the context
                existingConstructor = new Constructor { ConstructorId = ConstructorId };
                await context.Constructors.AddAsync(existingConstructor);
            }

            // Set the Constructor property of the Result entity to the existing constructor
            Constructor = existingConstructor;
        }

    }
}
