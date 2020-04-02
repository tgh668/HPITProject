using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.DTO;

namespace ZSZ.IService
{
    public interface IRoleService : IServiceSupport
    {
        RoleDTO[] GetAllRoles();
        /// <summary>
        ///  添加用户给他分配角色信息
        /// </summary>
        /// <param name="adminUserId"></param>
        /// <param name="roleIds"></param>
        void AddRoleIds(long adminUserId, long[] roleIds);
    }
}
