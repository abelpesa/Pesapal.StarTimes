using Microsoft.EntityFrameworkCore;
using StarTimes.DAL.Database;
using StarTimes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private DbContextOptions<StarTimesContext> _options;

        public UnitOfWork(DbContextOptions<StarTimesContext> options)
        {
            _options = options;
        }

        public bool _disposing = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposing)
            {
                if (disposing)
                {
                }
            }
            this._disposing = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public GenericRepository<T> Repository<T>() where T : class
        {
            return new GenericRepository<T>(_options);
        }


    }
}
