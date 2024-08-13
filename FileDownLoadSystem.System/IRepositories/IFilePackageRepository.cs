using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileDownloadSystem.Entity.FileInfo;
using FileDownLoadSystem.Core.BaseProvider;
using FileDownLoadSystem.Core.Extensions;

namespace FileDownLoadSystem.System.IRepositories
{
    public interface IFilePackageRepository : IRepository<FilePackages>, IDependency
    {

    }
}