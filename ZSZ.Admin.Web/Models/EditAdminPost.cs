using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZSZ.Admin.Web.Models
{
    public class EditAdminPost
    {
        public long Id { get; set; }
        [Required]
        [Phone]
        public string PhoneNum { get; set; }
        [Required]
        public string Name { get; set; }

        public string Pwd { get; set; }

        [Compare(nameof(Pwd))]
        public string PwdCheck { get; set; }
        public long[] RoleIds { get; set; }
    }
}