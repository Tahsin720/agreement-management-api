using ams.DataAccess.Database;
using ams.DataAccess.Database.Entity;
using ams.DataAccess.Repository.Generic;

namespace ams.DataAccess.Repository.Agreement
{
    public class AgreementRepository : GenericRepository<VendorAgreement>, IAgreementRepository
    {
        AmsDbContext _db;
        public AgreementRepository(AmsDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
