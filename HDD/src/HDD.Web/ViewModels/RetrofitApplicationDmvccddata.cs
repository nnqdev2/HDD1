namespace HDD.Web.ViewModels
{
    public class RetrofitApplicationDmvccddata
    {
        public string? Vin { get; set; }
        public int? EngineYear { get; set; }
        public string? EngineManufacturer { get; set; }
        public string? EngineFamilyNumber { get; set; }
        public string? EngineDisplacement { get; set; }
        public string? ArtFamilyName { get; set; }
        public string? ApplicationDate { get; set; }
        public string? RetrofitType { get; set; }
        public string? RetrofitProvider { get; set; }
        public DateTime? RunDate { get; set; }
        public DateTime? EntryDateTime { get; set; }
        public string? Comments { get; set; }
        public string? Plate { get; set; }
        public int? ModelYear { get; set; }
        public int? Gvw { get; set; }
        public int? RegistrationWeight { get; set; }
        public string? WeightRange { get; set; }
        public string? OwnerName { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? County { get; set; }
        public string? PubliclyOwned { get; set; }
        public string? RegistrationExpiration { get; set; }
        public string? RenewalAgency { get; set; }
        public string? ChangedOwnership { get; set; }
        //public DateTime? RunDate { get; set; }
        //public DateTime? EntryDateTime { get; set; }
        //public List<IFormFile>? Files { get; set; }
        public IList<DocumentAction>? DocumentActions { get; set; }
    }
}
