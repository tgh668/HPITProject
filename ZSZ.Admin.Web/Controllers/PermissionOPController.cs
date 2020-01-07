using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.Admin.Web.Models;
using ZSZ.Common;
using ZSZ.IService;

namespace ZSZ.Admin.Web.Controllers
{
    public class PermissionOPController : Controller
    {
        // GET: PermissionOP
        public IPremissionService PerService { get; set; }
        public ActionResult Index()
        {
            //加载所有的权限信息
            var list = PerService.GetAll();
            return View(list);
        }

        public ActionResult PLDelete(long[] selectIDs)
        {
            //循环遍历数组，删除里面的每一项即可
            for (int i = 0; i < selectIDs.Length; i++)
            {
                PerService.DelePernmission(selectIDs[i]);
            }
            return Json(new AjaxResult() { Status = "ok" });
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(PermissionAdd model)
        {
            if (ModelState.IsValid)
            {
                //说明校验通过
                //组织数据，调用服务层的方法，往数据库保存数据
                var id = PerService.AddPermission(model.PermissionName, model.PermissionDes);
                //AJAX请求必须返回json数据
                //AjaxResult r = new AjaxResult();
                return Json(new AjaxResult() { Status = "ok" });
            }

            else
            {
                return Json(new AjaxResult() { Status = "no" });
            }
        }

        public ActionResult DelePermission(long id)
        {
            bool b = PerService.DelePernmission(id);
            return Json(new AjaxResult() { Status = b ? "ok" : "no" });
        }

        [HttpGet]
        public ActionResult EditPermission(long id)
        {
            //根据id获取权限，展示在页面
            var perModel = PerService.Getpermission(id);
            return View(perModel);
        }

        [HttpPost]
        public ActionResult EditPermission(EditPermission model)
        {
            if (ModelState.IsValid)
            {
                PerService.UpdatepPermission(model.Id, model.PermissionName, model.PermissionDes);
                return Json(new AjaxResult() { Status = "ok" });
            }
            else
            {
                return Json(new AjaxResult() { Status = "no" });
            }
        }
    }
}