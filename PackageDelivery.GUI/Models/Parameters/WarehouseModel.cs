using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class WarehouseModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Dirección")]
        public string Direction { get; set; }
        [Required]
        [DisplayName("Código")]
        public string Code { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [DisplayName("Ciudad")]
        public long Id_City { get; set; }
    }
}