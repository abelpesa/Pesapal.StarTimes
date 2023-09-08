using Microsoft.EntityFrameworkCore;
using StarTimes.DAL.Database;
using StarTimes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StarTimes.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        DbSet<T> _dbSet;
        private StarTimesContext _context;

        public GenericRepository(DbContextOptions<StarTimesContext> options)
        {
            _context = new StarTimesContext(options);
            _dbSet = _context.Set<T>();
        
        }

        public async Task<IQueryable<T>> AdvancedSearchFilter(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> results = (IQueryable<T>)await _dbSet.Where(expression).FirstOrDefaultAsync();
            return results;
        }

        public async Task<T> AdvancedSearchFilterAsync(string objInclude, Expression<Func<T, bool>> expression)
        {
            T results = await _dbSet.Where(expression).Include(objInclude).FirstOrDefaultAsync();
            return results;
        }

        public async Task<T> AdvancedSearchFilterAsync(Expression<Func<T, bool>> expression)
        {
            T results = await _dbSet.Where(expression).FirstOrDefaultAsync();
            return results;
        }


        public async Task<T> Create(T obj)
        {
            if (obj != null)
            {
                await _dbSet.AddAsync(obj);
                await Save();
                return obj;
            }

            return null;
        }

        public async Task<List<T>> GetAll(string objInclude, Expression<Func<T, bool>> expression)
        {
            return objInclude == null || string.IsNullOrEmpty(objInclude) ? await _dbSet.Where(expression).ToListAsync() : await _dbSet.Where(expression).Include(objInclude).ToListAsync();
        }

        public async Task<List<T>> GetAll(string objInclude)
        {
            return objInclude == null || string.IsNullOrEmpty(objInclude) ? await _dbSet.ToListAsync() : await _dbSet.Include(objInclude).ToListAsync();
        }
        public async Task<List<T>> GetAllData(string sqlQuery)
        {
            List<T> objList = await _dbSet.FromSqlRaw(sqlQuery).ToListAsync();
            return objList;

        }

        public T GetById(int obj)
        {
            return _dbSet.Find(obj);
        }

        public async Task<bool> Save()
        {

            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<T> Update(T obj)
        {
            if (obj != null)
            {
                _dbSet.Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;
                await Save();
                return obj;
            }

            return null;
        }




    }
}
