using App.Application.Interfaces.Repostories;
using App.Application.Interfaces.UnitOfWorks;
using App.Persistence.Context;
using App.Persistence.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly MyDbContext _context;
        public UnitOfWork(MyDbContext context)
        {
            _context = context;
        }

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();
        public int Save() => _context.SaveChanges();
        public async Task<int> SaveAsync() =>await _context.SaveChangesAsync();
        IReadRepostory<T> IUnitOfWork.GetReadRepostory<T>() => new ReadRepostory<T>(_context);
        IWriteRepostory<T> IUnitOfWork.GetWriteRepostory<T>() => new WriteRepostory<T>(_context);
       
    }
}
