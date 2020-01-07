using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.DTO;
using ZSZ.IService;

namespace ZSZ.Service
{
    public class CitySerivce : ICityService
    {
        public CityDTO[] GetAll()
        {
            using (ZSZContext db = new ZSZContext())
            {
               
                //如何使用BaseService里面的方法
                BaseService<CityEntity> cityService = new BaseService<CityEntity>(db);
                return cityService.GetAll().ToList().Select(m => ToDTO(m)).ToArray();
                //Select就是筛选出一个新的模型  这个地方一定得加ToList()，不然sql语句不会执行（因为是延迟加载，用到的时候才执行）
            }
        }

        public CityDTO ToDTO(CityEntity city)
        {
            CityDTO cdto = new CityDTO();
            cdto.Id = city.Id;
            cdto.Name = city.Name;
            cdto.CreateDateTime = city.CreateDateTime;
            return cdto;
        }
    }
}
