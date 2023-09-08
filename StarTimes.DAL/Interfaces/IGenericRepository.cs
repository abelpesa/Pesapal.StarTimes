using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StarTimes.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int obj);
        Task<List<T>> GetAll(string objInclude, Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll(string objInclude);
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task<IQueryable<T>> AdvancedSearchFilter(Expression<Func<T, bool>> expression);
        Task<T> AdvancedSearchFilterAsync(string objInclude, Expression<Func<T, bool>> expression);
        Task<bool> Save();
    }
}
