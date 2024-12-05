using App.Application.Interfaces.Repostories;
using App.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IReadRepostory<T> GetReadRepostory<T>() where T : class,IBaseEntity,new();
        IWriteRepostory<T> GetWriteRepostory<T>() where T : class, IBaseEntity, new();
        Task<int> SaveAsync();
        int Save();
    }
}
