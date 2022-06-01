namespace HDD.Web.ViewModels
{
    public class VehicleInfoViewModel
    {
        public int VehicleId { get; set; }
        public string? Vin { get; set; }
        public string? Plate { get; set; }
        public string? Email { get; set; }
        public short? Year { get; set; }
        public string? Enginemfg { get; set; }
        public short? Enginemodelyear { get; set; }
        public short? Gvwr { get; set; }
        public string? Enginedisplacement { get; set; }
        public string? Enginefamilymember { get; set; }

        public string? SubmissionStatus { get; set; }

    }
}
