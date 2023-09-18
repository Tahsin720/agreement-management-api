using ams.DataAccess.Database;
using ams.Models;
using Microsoft.EntityFrameworkCore;

namespace ams.DataAccess.Repository.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AmsDbContext _dbContext;
        public DbSet<TEntity> Table
        {
            get
            {
                return _dbContext.Set<TEntity>();
            }
        }
        public GenericRepository(AmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<HttpResponseModel> GetAll()
        {
            var data = await Table.AsNoTracking().ToListAsync();
            return new HttpResponseModel(data);
        }
        public virtual async Task<HttpResponseModel> GetById(int id)
        {
            var data = await Table.FindAsync(id);
            if (data == null)
                return new HttpResponseModel(data, false, "Data not found.");

            return new HttpResponseModel(data);

        }
        public async Task<HttpResponseModel> Create(TEntity entity)
        {
            try
            {
                await Table.AddAsync(entity);
                if (await _dbContext.SaveChangesAsync() > 0)
                    return new HttpResponseModel(entity, true);

                return new HttpResponseModel(entity, false, "Save Failed!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<HttpResponseModel> Update(TEntity entity)
        {
            try
            {
                Table.Update(entity);
                if (await _dbContext.SaveChangesAsync() > 0)
                    return new HttpResponseModel(entity);
                return new HttpResponseModel(null, false, "Update failed.");
            }
            catch (Exception ex)
            {
                return new HttpResponseModel(null, false, ex.Message);
            }
        }
        public async Task<HttpResponseModel> Delete(int id)
        {
            var data = await Table.FindAsync(id);
            if (data == null)
                return new HttpResponseModel(data, false, "Data not found");
            Table.Remove(data);
            if (await _dbContext.SaveChangesAsync() > 0)
                return new HttpResponseModel(null);
            return new HttpResponseModel(null, false, "Delete failed");
        }
    }
}
