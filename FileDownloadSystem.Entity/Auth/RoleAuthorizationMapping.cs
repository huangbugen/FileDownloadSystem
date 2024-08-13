using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDownloadSystem.Entity.Auth
{
    public class RoleAuthorizationMapping : BaseModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int AuthorizationId { get; set; }
    }
}