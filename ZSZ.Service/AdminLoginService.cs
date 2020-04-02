using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Common;
using ZSZ.IService;

namespace ZSZ.Service
{
    public class AdminLoginService : IAdminLogin
    {
        public bool CheckLogin(string tele, string pwd)
        {
            using (ZSZContext db = new ZSZContext())
            {
                BaseService<AdminUserEntity> admin = new BaseService<AdminUserEntity>(db);
                var adminEnty = admin.GetAll().SingleOrDefault(m => m.PhoneNum == tele);
                if (adminEnty == null)
                {
                    return false;
                }
                string salt = adminEnty.PasswordSalt;//密码盐
                                                     //将用户穿过来的密码和盐在一块加密，然后跟数据库的密码做对比，如果一致，就说明登录成功
                var pwdJM = CommonHelper.CalcMD5(pwd + salt);//md5(密码+盐)
                return pwdJM == adminEnty.PasswordHash;
            }
        }
    }
}
