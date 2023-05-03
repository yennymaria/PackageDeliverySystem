using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class DeliveryModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Fecha del Envío")]
        public DateTime DeliveryDate { get; set; }
        [Required]
        [DisplayName("Precio")]
        public int Price { get; set; }

        [DisplayName("Dirección de Destino")]
        public long Id_DestinationAddress { get; set; }
        [DisplayName("Paquete")]
        public long Id_Package { get; set; }
        [DisplayName("Estado del Envío")]
        public long Id_DeliveryStatus { get; set; }
        [DisplayName("Remitente")]
        public long Id_Sender { get; set; }
        [DisplayName("Tipo de Transporte")]
        public long Id_TransportType { get; set; }
    }
}