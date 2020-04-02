using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.Admin.Web.Models;
using ZSZ.Common;
using ZSZ.DTO;
using ZSZ.IService;

namespace ZSZ.Admin.Web.Controllers
{
    public class AdminUserController : Controller
    {
        // GET: AdminUser
        public IAdminUserService AdminUserService { get; set; }
        public IRoleService RoleService { get; set; }
        public ActionResult List(int pageIndex = 1)
        {
            var admins = AdminUserService.GetAllAdmin(3, (pageIndex - 1) * 3);
            var totals = AdminUserService.GetTotalCount();
            ViewBag.pageIndex = pageIndex;
            ViewBag.total = totals;
            return View(admins);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            //获取所有的角色
            var roles = RoleService.GetAllRoles();
            return View(roles);
        }

        [HttpPost]
        public ActionResult AddAdmin(AddAdminModel model)
        {
            if (ModelState.IsValid)
            {
                //1服务端也也要校验手机是否被真正的注册过
                AdminUserDTO userModel = AdminUserService.IsExitTelePhone(model.PhoneNum);
                if (userModel == null)
                {
                    long adminUserID = AdminUserService.AddAdminUser(model.Name, model.PhoneNum, model.Pwd);//添加用户,注意此处的cityId，总部为null
                    RoleService.AddRoleIds(adminUserID, model.RoleIds);//添加用户角色的对应关系，此处应该启用事物
                    return Json(new AjaxResult() { Status = "ok" });
                }
                else
                {
                    return Json(new AjaxResult() { Status = "exists" });
                }

            }
            else
            {
                string errorMsg = CommonHelper.GetValidMsg(ModelState);//验证出错时候具体的错误信息
                return Json(new AjaxResult() { Status = "no", ErrorMsg = errorMsg });
            }
        }

        public ActionResult CheckPhoneExist(string phone, long? adminID)
        {
            if (!string.IsNullOrEmpty(phone))
            {
                AdminUserDTO userModel = AdminUserService.IsExitTelePhone(phone);
                bool isOK = false;
                //如果没有给adminID，则说明是“插入”，只要检查是不是存在这个手机号
                if (adminID == null)
                {
                    isOK = (userModel == null);
                }
                else//如果有userId，则说明是修改，则要把自己排除在外
                {
                    isOK = (userModel == null || userModel.Id == adminID);
                }
                return Json(new AjaxResult { Status = isOK ? "ok" : "exists" });
            }
            else
            {
                return Json(new AjaxResult() { Status = "no" });

            }
        }

    }
}