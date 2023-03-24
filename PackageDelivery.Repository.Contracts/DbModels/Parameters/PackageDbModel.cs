namespace PackageDelivery.Repository.Contracts.DbModels.Parameters
{
    public class PackageDbModel
    {
        public long Id { get; set; }
        public string Weight { get; set; }
        public string Depth { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public long Id_Office { get; set; }
    }
}