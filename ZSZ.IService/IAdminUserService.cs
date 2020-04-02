using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.DTO;

namespace ZSZ.IService
{
    public interface IAdminUserService : IServiceSupport
    {
     
        /// <summary>
        /// 获取所有的管理员信息
        /// </summary>
        /// <returns></returns>
        AdminUserDTO[] GetAllAdmin(int pageSize, int currentIndex);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        bool DeleteAdmin(long id);
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNum"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="cityId">如果为null 说明为总部</param>
        /// <returns></returns>
        long AddAdminUser(String name, String phoneNum, String password);

        /// <summary>
        /// 校验电话号码是否已被注册
        /// </summary>
        /// <param name="telPhone"></param>
        /// <returns></returns>
        AdminUserDTO IsExitTelePhone(string telPhone);

        /// <summary>
        /// 根据用户id获取信息
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        AdminUserDTO GetAdminInfo(long adminId);
        /// <summary>
        /// 更新管理员信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phoneNum"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="cityId"></param>
        void UpdateAdminUser(long id, string name, string phoneNum, String password, string email, long? cityId);
        /// <summary>
        /// 检验用户是否登录成功
        /// </summary>
        /// <param name="phoneNum"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool CheckLogin(String phoneNum, String password);
        /// <summary>
        /// 根据电话号码获取登录用户信息
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        AdminUserDTO GetAdminByPhone(string phone);

        /// <summary>
        /// 判断某个用户是否含有某个权限， 判断adminUserId这个用户是否有permissionName这个权限项（举个例子） //HasPermission(3,"User.Add")
        /// </summary>
        /// <param name="adminUserId"></param>
        /// <param name="permissionName">权限名字</param>
        /// <returns></returns>
        bool HasPermission(long adminUserId, String permissionName);

        //根据id获取DTO
        AdminUserDTO GetById(long id);

        long GetTotalCount();
    }
}
