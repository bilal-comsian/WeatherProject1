using System.Text.Json.Serialization;

namespace Testapp.Model
{
    public class City
    {
        //[JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }
    }
}
