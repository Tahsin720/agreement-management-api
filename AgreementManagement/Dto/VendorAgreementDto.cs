using System.ComponentModel.DataAnnotations.Schema;

namespace AgreementManagement.Dto
{
    public class VendorAgreementDto
    {
        public int vendor_id { get; set; }
        public int? bl_code { get; set; }
        public string? document_code { get; set; }
        public DateTime? start { get; set; }
        public DateTime? expiry_date { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
    }
}
