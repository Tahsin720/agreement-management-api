using ams.Models;

namespace ams.DataAccess.Repository.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<HttpResponseModel> GetAll();
        Task<HttpResponseModel> GetById(int id);
        Task<HttpResponseModel> Create(TEntity entity);
        Task<HttpResponseModel> Update(TEntity entity);
        Task<HttpResponseModel> Delete(int id);
    }
}
