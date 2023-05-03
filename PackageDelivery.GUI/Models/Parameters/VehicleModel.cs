﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class VehicleModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Placa")]
        public string Plate { get; set; }
        [DisplayName("Tipo de Transporte")]
        public long IdTransportType { get; set; }
    }
}