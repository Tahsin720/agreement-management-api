using ams.DataAccess.Database;
using ams.DataAccess.Database.Entity;
using ams.DataAccess.Repository.Generic;
using ams.Models;
using Microsoft.EntityFrameworkCore;

namespace ams.DataAccess.Repository.VendorInfo
{
    public class VendorInfoRepository : GenericRepository<VendorInformation>, IVendorInfoRepository
    {
        AmsDbContext _db;
        public VendorInfoRepository(AmsDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<HttpResponseModel> GetAllIds()
        {
            var result = await _db.VendorInformations.AsNoTracking().Select(x => x.vendor_id).ToListAsync();
            return new HttpResponseModel(result);
        }
    }
}
