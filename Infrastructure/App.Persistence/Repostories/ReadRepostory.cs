using App.Application.Repostories;
using App.Domain.Common;
using App.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Repostories
{
    public class ReadRepostory<T> : IReadRepostory<T> where T : class, IBaseEntity,new()
    {
        private readonly MyDbContext _context;
        public ReadRepostory(MyDbContext context)
        {
            _context = context;
        }
        private DbSet<T> Table { get => _context.Set<T>(); }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, bool enableTracking = false)
        {
            IQueryable<T> querable = Table;
            if (!enableTracking)
                querable = querable.AsNoTracking();
            if (include is not null)
                querable = include(querable);
            if (predicate is not null)
                querable = querable.Where(predicate);
            if (orderby is not null)
                return await orderby(querable).ToListAsync();

            return await querable.ToListAsync();
        }

        public async Task<List<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> querable = Table;
            if (!enableTracking)
                querable = querable.AsNoTracking();
            if (include is not null)
                querable = include(querable);
            if (predicate is not null)
                querable = querable.Where(predicate);
            if (orderby is not null)
                return await orderby(querable).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();

            return await querable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> querable = Table;
            if (!enableTracking)
                querable = querable.AsNoTracking();
            if (include is not null)
                querable = include(querable);
            /*if (predicate is not null)
                querable = querable.Where(predicate);*/
           
            return await querable.FirstOrDefaultAsync(predicate);
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if (predicate is not null) Table.Where(predicate);
            return await Table.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate,bool enableTracking=false)
        { 
            if (!enableTracking)
                Table.AsNoTracking();
            return Table.Where(predicate);
        }

      

        

        
    }
}
