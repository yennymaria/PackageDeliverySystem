

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class PackageModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Peso")]
        public int Weight { get; set; }
        [Required]
        [DisplayName("Profundo")]
        public int Depth { get; set; }
        [Required]
        [DisplayName("Ancho")]
        public int Width { get; set; }
        [Required]
        [DisplayName("Alto")]
        public int Height { get; set; }
        [DisplayName("Oficina")]
        public long Id_Office { get; set; }
        public string OfficeName { get; set; }
        public IEnumerable<OfficeModel> OfficeList { get; set; }
    }
}