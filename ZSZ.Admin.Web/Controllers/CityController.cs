using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.IService;
using ZSZ.Service;

namespace ZSZ.Admin.Web.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        public ICityService CityService { get; set; } //声明一个接口对象
        public ActionResult Index()
        {
            //调用cityService里面的GetAll方法
            //CityService = new CitySerivce(); //让IOC容器AutoFac帮你创建数据
            var list = CityService.GetAll();
            return Content(list.Length.ToString());//返回字符串

        }
    }
}