using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ams.DataAccess.Database.Entity
{
    [Table("inventory_procure_vendor_agreement_renew")]
    public class VendorAgreementRenewal
    {
        [Key]
        public int id { get; set; }
        public int inventory_procure_vendor_agreement_id { get; set; }
        public int renew_number { get; set; }
        public DateTime renewal_date { get; set; }
        public int create_by { get; set; }
        public int approve_by { get; set; }
        public int last_modify_by { get; set; }
        public DateTime create_date { get; set; }
        public DateTime approve_date { get; set; }
        public DateTime last_modify_date { get; set; }
    }
}
