using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileDownloadSystem.Entity;
using FileDownLoadSystem.Core.EfDbContext;
using FileDownLoadSystem.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace FileDownLoadSystem.Core.BaseProvider
{
    public class BaseRepository<TModel> where TModel : BaseModel
    {
        private readonly FileDownloadSystemDbContext _defaultDbContext;
        public FileDownloadSystemDbContext DbContext => _defaultDbContext;
        private DbSet<TModel> DbSet => _defaultDbContext.Set<TModel>();

        public BaseRepository(FileDownloadSystemDbContext dbContext)
        {
            this._defaultDbContext = dbContext;
        }

        public virtual TModel FindFirst(
            Expression<Func<TModel, bool>> predicate,
            Expression<Func<TModel, Dictionary<object, QueryOrderBy>>> orderBy = null
        )
        {
            return
        }

        public IQueryable<TModel> FindAsIQueryable(
            Expression<Func<TModel, bool>> predicate,
            Expression<Func<TModel, Dictionary<object, QueryOrderBy>>> orderBy = null
        )
        {
            if (orderBy != null)
            {
                return DbSet.Where(predicate).
            }
        }
    }
}