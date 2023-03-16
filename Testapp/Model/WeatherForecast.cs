using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testapp.Model
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        
        public double TemperatureC { get; set; }
        [NotMapped]
        public double TemperatureF => Math.Round(32 + (TemperatureC / 0.5556),1);
        
        public double WindSpeed { get; set; }
        public string? Summary { get; set; }
    }
}