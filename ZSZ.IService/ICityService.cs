using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.DTO;

namespace ZSZ.IService
{
    public interface ICityService : IServiceSupport
    {
        //返回所有城市信息的方法
        CityDTO[] GetAll();
    }
}
