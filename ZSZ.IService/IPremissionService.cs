using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.DTO;

namespace ZSZ.IService
{
    public interface IPremissionService : IServiceSupport
    {
        PermissionsDTO[] GetAll();

        /// <summary>
        /// 删除一个权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DelePernmission(long id);


        long AddPermission(string name, string des);

        /// <summary>
        /// 根据id获取权限项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PermissionsDTO Getpermission(long id);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        void UpdatepPermission(long id, string permName,
            string description);
    }
}
