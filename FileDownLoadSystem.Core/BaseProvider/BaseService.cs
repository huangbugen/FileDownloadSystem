using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileDownloadSystem.Entity;
using FileDownLoadSystem.Core.Enums;

namespace FileDownLoadSystem.Core.BaseProvider
{
    public class BaseService<TModel, TRepository> where TModel : BaseModel where TRepository : IRepository<TModel>
    {
        protected readonly TRepository _repository;
        public BaseService(TRepository repository)
        {
            this._repository = repository;
        }

        public TModel FindFirst(Expression<Func<TModel, bool>> predicate,
            Expression<Func<TModel, Dictionary<object, QueryOrderBy>>> orderBy = null)
        {
            return _repository.
        }
    }
}