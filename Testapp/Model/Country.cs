using System.ComponentModel.DataAnnotations;

namespace Testapp.Model
{
    public class Country
    {
        public string Name { get; set; }
        [Key]
        public string ISO { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
