using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZSZ.Admin.Web.Models
{
    public class LoginModel
    {
        [Required]
        [Phone]
        public string Name { get; set; }
        [Required]
        public string Pwd { get; set; }
        [Required]
        //[StringLength(4, MinimumLength = 4)]
        public string VerCode{ get; set; }
    }
}