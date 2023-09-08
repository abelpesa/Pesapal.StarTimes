using StarTimes.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        GenericRepository<T> Repository<T>() where T : class;

    }
}
