using App.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces.Repostories
{
    public interface IWriteRepostory<T> where T : class, IBaseEntity, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task<T> UpdateAsync(T entity);
        Task HardDeleteAsync(T entity);
    }
}
