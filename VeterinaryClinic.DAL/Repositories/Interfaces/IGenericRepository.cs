using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetCompleteEntityAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteByIdAsync(int id);
        Task DeleteAsync(TEntity entity);
        //Filters
        IQueryable<TEntity> FindAll();
        Task<IQueryable<TEntity>> FindByCondotion(Expression<Func<TEntity,bool>> expression);

    }
}
