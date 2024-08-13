using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDownloadSystem.Entity.FileInfo
{
    public class FileWebConfigs : BaseModel
    {
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
    }
}