using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileDownloadSystem.Entity;

namespace FileDownLoadSystem.Core.BaseProvider
{
    public interface IRepository<TModel> where TModel : BaseModel
    {

    }
}