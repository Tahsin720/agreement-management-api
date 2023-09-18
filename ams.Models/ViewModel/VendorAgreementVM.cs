namespace ams.Models.ViewModel
{
    public class VendorAgreementVM
    {
        public int vendor_id { get; set; }
        public int? bl_code { get; set; }
        public string? document_code { get; set; }
        public DateTime? start { get; set; }
        public string? duration { get; set; }
        public DateTime? expiry_date { get; set; }
        public string? status { get; set; }
        public bool is_renewed { get; set; }
    }
}
