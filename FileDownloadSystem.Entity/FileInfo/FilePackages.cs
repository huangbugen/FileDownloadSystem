using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDownloadSystem.Entity.FileInfo
{
    public class FilePackages : BaseModel
    {
        public int FilesId { get; set; }
        public string PackageUrl { get; set; }
        public string PackageName { get; set; }
        public DateTime PublishTime { get; set; }
    }
}