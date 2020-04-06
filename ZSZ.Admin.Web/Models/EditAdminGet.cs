using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZSZ.DTO;

namespace ZSZ.Admin.Web.Models
{
    public class EditAdminGet
    {
        public AdminUserDTO AdminDTO { get; set; }
        public RoleDTO[] RoleDTO { get; set; }
        public long[] HasRoleIds { get; set; }
    }
}