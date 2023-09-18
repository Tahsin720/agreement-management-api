using ams.DataAccess.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace ams.DataAccess.Database
{
    public class AmsDbContext : DbContext
    {
        public AmsDbContext(DbContextOptions<AmsDbContext> options) : base(options)
        {

        }
        public virtual DbSet<VendorAgreement> VendorAgreements { get; set; }
        public virtual DbSet<VendorAgreementRenewal> VendorAgreementRenewals { get; set; }
        public virtual DbSet<VendorInformation> VendorInformations { get; set; }
    }
}
