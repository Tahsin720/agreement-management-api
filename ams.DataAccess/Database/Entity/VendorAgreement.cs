using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ams.DataAccess.Database.Entity
{
    [Table("inventory_procure_vendor_agreement")]
    public class VendorAgreement
    {
        [Key]
        public int vc_id { get; set; }
        public int vendor_id { get; set; }
        public int? bl_code { get; set; }
        public string? document_code { get; set; }
        public DateTime? start { get; set; }
        public string? duration { get; set; }
        public DateTime? expiry_date { get; set; }
        public string? status { get; set; }
        public bool is_renewed { get; set; }
        public int create_by { get; set; }
        public int verify_by { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? signed_date { get; set; }
        public DateTime? verify_date { get; set; }
        public string? AgreementFile { get; set; }
    }
}
