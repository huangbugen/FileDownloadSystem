using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileDownloadSystem.Entity
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}