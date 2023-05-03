using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class CityModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Ciudad")]
        public string Name { get; set; }
    }
}