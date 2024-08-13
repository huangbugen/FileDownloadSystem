using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileDownloadSystem.Entity.FileInfo
{
    public class Files : BaseModel
    {
        public int FileTypeId { get; set; }
        public string FileName { get; set; }
        public string? FileIconUrl { get; set; }
        public DateTime PublishDate { get; set; }
        public long ClickTimes { get; set; }
        public long DownloadTimes { get; set; }
        public string? Notification { get; set; }

        [ForeignKey("FilesId")]
        public List<FilePackages> FilePackages { get; set; }
    }
}