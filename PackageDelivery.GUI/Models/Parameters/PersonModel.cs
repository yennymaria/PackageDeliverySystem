
namespace PackageDelivery.GUI.Contracts.DTO
{
    public class PersonModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string OtherNames { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string IdentificationNumber { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public int Id_DocumentType { get; set; }
    }
}
