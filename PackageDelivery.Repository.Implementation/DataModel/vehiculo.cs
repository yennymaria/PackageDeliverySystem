//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PackageDelivery.Repository.Implementation.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class vehiculo
    {
        public long id { get; set; }
        public string placa { get; set; }
        public Nullable<long> idTipoTransporte { get; set; }
    
        public virtual TipoTransporte TipoTransporte { get; set; }
    }
}
