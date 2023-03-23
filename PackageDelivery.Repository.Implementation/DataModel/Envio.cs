//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PackageDelivery.Repository.Implementation.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Envio
    {
        public long Id { get; set; }
        public System.DateTime FechaEnvio { get; set; }
        public int Precio { get; set; }
        public long Id_DireccionDestino { get; set; }
        public long Id_Paquete { get; set; }
        public long Id_EstadoEnvio { get; set; }
        public long Id_Remitente { get; set; }
        public long Id_TipoTransporte { get; set; }
    
        public virtual Direccion Direccion { get; set; }
        public virtual EstadoEnvio EstadoEnvio { get; set; }
        public virtual Paquete Paquete { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual TipoTransporte TipoTransporte { get; set; }
    }
}
