using ams.DataAccess.Database.Entity;
using ams.DataAccess.Repository.Generic;
using ams.Models;

namespace ams.DataAccess.Repository.VendorInfo
{
    public interface IVendorInfoRepository : IGenericRepository<VendorInformation>
    {
        Task<HttpResponseModel> GetAllIds();
    }
}
