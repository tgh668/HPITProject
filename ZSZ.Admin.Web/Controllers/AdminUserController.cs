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
            string keyWords = Request["keyWords"] == null ? "" : Request["keyWords"].ToString();
            var admins = AdminUserService.GetAllAdmin(8, (pageIndex - 1) * 8,keyWords);
            var totals = AdminUserService.GetTotalCount(keyWords);
            ViewBag.pageIndex = pageIndex;
            ViewBag.total = totals;
            ViewBag.pageSize = 8;
            ViewBag.keywords = keyWords;
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
                    long adminUserID = AdminUserService.AddAdminUser(model.Name, model.PhoneNum, model.Pwd);
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

        [HttpGet]
        public ActionResult EditAdmin(long id)
        {
            //1:根据用户id获取用户信息
            var adminModel = AdminUserService.GetAdminInfo(id);
            if (adminModel == null)
            {
                //不要忘了第二个参数的(object) 
                //如果视图在当前文件夹下没有找到，则去Shared下去找
                //一个Error视图，大家共用
                return View("Error", (object)"指定的用户不存在");
            }
            //3:获取所有的角色信息，并选中当前的角色
            var roles = RoleService.GetAllRoles();//获取所有的角色信息
            var rolesHave = RoleService.GetByAdminUserId(id);//用户拥有的角色信息
            EditAdminGet edit = new EditAdminGet { AdminDTO = adminModel, HasRoleIds = rolesHave.Select(m => m.Id).ToArray(), RoleDTO = roles };
            return View(edit);
        }
        [HttpPost]
        public ActionResult EditAdmin(EditAdminPost editModel)
        {
            //更新用户表
            //更新用户角色表
            if (ModelState.IsValid)
            {
                //如果密码什么都没写，则不更新密码，否则就更新密码
                //注意此处的细节，前端如果密码都没填写，那么可以向后端发请求（留空不修改密码），如果前端的密码和确认密码不一致，那么就不能往后端发请求，前端注意这个细节！
                AdminUserService.UpdateAdminUser(editModel.Id, editModel.Name, editModel.PhoneNum, editModel.Pwd);
                //更新用户角色关系表...
                RoleService.UpdateRoleIds(editModel.Id, editModel.RoleIds);
                return Json(new AjaxResult() { Status = "ok" });
            }
            else
            {
                string errorMsg = CommonHelper.GetValidMsg(ModelState);//验证具体的错误信息
                return Json(new AjaxResult() { Status = "no", ErrorMsg = errorMsg });
            }

        }

        public ActionResult DeleAdmin(long id)
        {
            long? userId = LoginHelper.GetUserId(HttpContext);//获取session
            if (id == userId.Value)
            {
                return Json(new AjaxResult() { Status = "warn" });
            }
            bool b = AdminUserService.DeleteAdmin(id);
            if (b)
            {
                return Json(new AjaxResult() { Status = "ok" });
            }
            else
            {
                return Json(new AjaxResult() { Status = "no" });
            }

        }

        public ActionResult BatchDele(long[] selectRoleIDs)
        {
            long? userId = LoginHelper.GetUserId(HttpContext);//获取当前登录的用户，他不能自己删除自己
            if (selectRoleIDs.Contains(userId.Value))
            {
                return Json(new AjaxResult() { Status = "warn" });
            }
            if (selectRoleIDs != null)
            {
                for (int i = 0; i < selectRoleIDs.Length; i++)
                {
                    AdminUserService.DeleteAdmin(selectRoleIDs[i]);
                }

                return Json(new AjaxResult() { Status = "ok" });
            }
            else
            {
                return Json(new AjaxResult() { Status = "no" });
            }

        }
    }
}