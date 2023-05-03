﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class OfficeModel
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
        [Required]
        [DisplayName("Teléfono")]
        public string CellPhone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [DisplayName("Ciudad")]
        public long Id_City { get; set; }
    }
}