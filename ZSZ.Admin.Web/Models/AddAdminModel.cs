using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZSZ.Admin.Web.Models
{
    public class AddAdminModel
    {
        [Required]
        [Phone]
        public string PhoneNum { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Pwd { get; set; }
        [Required]
        [Compare(nameof(Pwd))]
        public string PwdCheck { get; set; }
        public long[] RoleIds { get; set; }
    }
}