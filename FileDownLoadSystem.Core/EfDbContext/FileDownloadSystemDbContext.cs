using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using System.Transactions;
using FileDownloadSystem.Entity;
using FileDownLoadSystem.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;

namespace FileDownLoadSystem.Core.EfDbContext
{
    public class FileDownloadSystemDbContext : DbContext, IDependency
    {
        public FileDownloadSystemDbContext()
        {

        }

        public FileDownloadSystemDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                optionsBuilder.UseMySql("Server=1.94.42.172;database=FileDownloadSystem;uid=root;pwd=1234556", MySqlServerVersion.LatestSupportedServerVersion);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                // 获取应用程序上下文中的编译库
                // DependencyContext依赖Microsoft.Extensions.DependencyModel包
                // Serviceable是否可服务（是否由nuget管理）
                // x.Type == "project"来自项目引用
                // x.Type == "package"来自nuget
                var compilationLibraries = DependencyContext.Default!.CompileLibraries
                .Where(x => !x.Serviceable && x.Type == "project");

                // 遍历过滤后的库
                foreach (var compilation in compilationLibraries)
                {
                    // 加载指定类型
                    AssemblyLoadContext.Default
                    .LoadFromAssemblyName(new AssemblyName(compilation.Name))   //加载每个库的程序集
                    .GetTypes() // 获取程序集中的所有类型
                    // 遍历类型，保留非抽象且基类为BaseModel的类型
                    // TypeInfo提供更多类型信息，x.GetTypeInfo().BaseType != null，如果为null意味着x是object或者接口
                    .Where(x => x.GetTypeInfo().BaseType != null && !x.IsAbstract && x.BaseType == (typeof(BaseModel)))
                    .ToList().ForEach(m =>
                    {
                        // 注册实体模型
                        modelBuilder.Entity(m);
                    });
                }
                base.OnModelCreating(modelBuilder);
            }
            catch (System.Exception)
            {

            }
        }
    }
}