using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.IService;

namespace ZSZ.Admin.Web.Controllers
{
    public class RoleController : Controller
    {
        public IRoleService RoleService { get; set; }
        // GET: Role
        public ActionResult Index()
        {
            var list = RoleService.GetAll();
            return View(list);
        }
    }
}