namespace PackageDelivery.Repository.Contracts.DbModels.Parameters
{
    public class VehicleDbModel
    {
        public long Id { get; set; }
        public string Plate { get; set; }
        public long IdTransportType { get; set; } 
    }
}
