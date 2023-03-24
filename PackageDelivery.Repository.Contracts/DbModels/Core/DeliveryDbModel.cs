﻿using System;

namespace PackageDelivery.Repository.Contracts.DbModels.Core
{
    public class DeliveryDbModel
    {
        public long Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Price { get; set; }
        public long Id_DestinationAddress { get; set; }
        public long Id_Package { get; set; }
        public long Id_DeliveryStatus { get; set; }
        public long Id_Sender { get; set; }
        public long Id_TransportType { get; set; }
    }
}
