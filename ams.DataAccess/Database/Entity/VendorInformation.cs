using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ams.DataAccess.Database.Entity
{
    [Table("inventory_procure_vendor_information")]
    public class VendorInformation
    {
        [Key]
        public int vendor_id { get; set; }

        public int vndr_user_id { get; set; }

        public string? vndr_official_name { get; set; }

        public string? vndr_add_house { get; set; }

        public int? vndr_add_road { get; set; }

        public int vndr_add_area { get; set; }

        public int vndr_add_post { get; set; }

        public int vndr_add_thana { get; set; }

        public int vndr_add_dist { get; set; }

        public int vndr_add_div { get; set; }

        public int vndr_add_country { get; set; }

        public string? vndr_add_key_contact { get; set; }

        public int? vndr_add_key_contact_pos { get; set; }

        public DateTime? vndr_enlisted_date { get; set; }

        public DateTime? vndr_registered_date { get; set; }

        public int? vndr_org_type { get; set; }

        public DateTime? vndr_create_date { get; set; }

        public DateTime? vndr_approve_date { get; set; }

        public DateTime? vndr_last_modify_date { get; set; }

        public int vndr_create_by { get; set; }
        public int vndr_approve_by { get; set; }
        public int? vndr_last_modify_by { get; set; }
    }
}
