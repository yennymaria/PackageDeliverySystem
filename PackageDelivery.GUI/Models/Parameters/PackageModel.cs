

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class PackageModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Peso")]
        public string Weight { get; set; }
        [Required]
        [DisplayName("Profundo")]
        public string Depth { get; set; }
        [Required]
        [DisplayName("Ancho")]
        public string Width { get; set; }
        [Required]
        [DisplayName("Alto")]
        public string Height { get; set; }
        [DisplayName("Oficina")]
        public long Id_Office { get; set; }
    }
}