using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDownloadSystem.Entity.Auth
{
    public class Authorization : BaseModel
    {
        public int Id { get; set; }
        public string AuthorizationName { get; set; }
        public bool IsMenu { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
    }
}