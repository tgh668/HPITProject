using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZSZ.Service;
using ZSZ.Service.Entities;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            log4net.Config.XmlConfigurator.Configure();//初始化log4net
            //测试Ef的配置是否准确
            using (ZSZContext zsz=new ZSZContext())
            {
                TutorEntity city = new TutorEntity();
                city.Name = "田果";
                zsz.Tutors.Add(city);
                zsz.SaveChanges();
            }

            //BaseEntity e = new HouseEntity();//里氏转换原则

            //BaseEntity e = new AdminLogEntity();

            //BaseService<HouseEntity> aa=new BaseService<HouseEntity>()

        }
    }
}
