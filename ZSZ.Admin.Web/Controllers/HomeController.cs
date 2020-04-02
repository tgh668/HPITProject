using CaptchaGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.Admin.Web.Models;
using ZSZ.Common;
using ZSZ.IService;

namespace ZSZ.Admin.Web.Controllers
{

    public class HomeController : Controller
    {
        public IAdminLogin AdminLoginService { get; set; }
        // GET: Home
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetVarCode()
        {
            //利用CaptchaGen验证码组件，用法参照文档，先通过Nuget安装组件 Install-PackAge CaptchaGen
            //1:获取验证码文字
            var VerNum = CommonHelper.CreateVerifyCode(4);
            TempData["code"] = VerNum;//保存到Sesion里面，使用过一次后就自动清除，这就是TempData的用法
            MemoryStream ms = ImageFactory.GenerateImage(VerNum, 40, 100, 12, -1);  //此处不能用using语法 验证码文字 高度；宽度； 字体大小；扭曲程度，数值越大扭曲越厉害
            return File(ms, "image/jpeg");

        }


        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            //1：必须有非空的一个校验
            if (!ModelState.IsValid)
            {
                //说明校验没通过，提示用户XXX为空
                return Json(new AjaxResult() { Status = "error", ErrorMsg = CommonHelper.GetValidMsg(ModelState) });
            }
            //2:校验用户输入的验证码跟model里面的是否一致
            if (TempData["code"].ToString() != model.VerCode)
            {
                return Json(new AjaxResult() { Status = "error", ErrorMsg = "验证码不对" });
            }
            //3:根据用户名和密码做数据库的校验
            bool b = AdminLoginService.CheckLogin(model.Name, model.Pwd);
            if (b)
            {
                return Json(new AjaxResult() { Status = "ok" });
            }
            else
            {
                return Json(new AjaxResult() { Status = "no" });
            }

        }


        public ActionResult MainIndex()
        {
            return View();
        }
    }
}