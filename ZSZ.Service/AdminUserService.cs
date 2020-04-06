using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Common;
using ZSZ.DTO;
using ZSZ.IService;

namespace ZSZ.Service
{
    public class AdminUserService : IAdminUserService
    {
        public long AddAdminUser(string name, string phoneNum, string password)
        {
            AdminUserEntity adminEf = new AdminUserEntity();
            adminEf.Name = name;
            adminEf.PhoneNum = phoneNum;
            string salt = CommonHelper.CreateVerifyCode(5);//盐
            adminEf.PasswordSalt = salt;
            //Md5(盐+用户密码)
            string pwdHash = CommonHelper.CalcMD5(password + salt);//处理后的密码
            adminEf.PasswordHash = pwdHash;
            using (ZSZContext context = new ZSZContext())
            {
                context.AdminUsers.Add(adminEf);
                context.SaveChanges();
                return adminEf.Id;
            }
        }

        public bool CheckLogin(string phoneNum, string password)
        {
            using (ZSZContext zsx = new ZSZContext())
            {
                BaseService<AdminUserEntity> bs = new BaseService<AdminUserEntity>(zsx);
                var admin = bs.GetAll().SingleOrDefault(m => m.PhoneNum == phoneNum);
                if (admin == null)
                {
                    return false;
                }
                var salt = admin.PasswordSalt;
                var pwd = CommonHelper.CalcMD5(password + salt);//md5(盐+密码)
                return admin.PasswordHash == pwd;
            }
        }

        public bool DeleteAdmin(long id)
        {
            using (ZSZContext context = new ZSZContext())
            {
                BaseService<AdminUserEntity> adbs = new BaseService<AdminUserEntity>(context);
                return adbs.MarkDeleted(id);
            }
        }

        public AdminUserDTO GetAdminByPhone(string phone)
        {
            using (ZSZContext zsz = new ZSZContext())
            {
                BaseService<AdminUserEntity> bsAdmin = new BaseService<AdminUserEntity>(zsz);
                //bsAdmin.GetAll().AsNoTracking().Where(m => m.PhoneNum == phone).ToList().Select(m => ToDTO(m));
                var users = bsAdmin.GetAll().AsNoTracking().Where(m => m.PhoneNum == phone);
                int count = users.Count();
                if (count <= 0)
                {
                    return null;
                }
                else if (count == 1)
                {
                    return ToDTO(users.Single());
                }
                else
                {
                    throw new ApplicationException("找到多个手机号为" + phone + "的管理员");
                }


            }
        }

        public AdminUserDTO GetAdminInfo(long adminId)
        {
            using (ZSZContext context = new ZSZContext())
            {
                BaseService<AdminUserEntity> adbs = new BaseService<AdminUserEntity>(context);
                var admin = adbs.GetById(adminId);
                if (admin == null)
                {
                    return null;
                }
                return ToDTO(admin);


            }
        }

        public AdminUserDTO[] GetAllAdmin(int pageSize, int currentIndex, string keyWords)
        {
            using (ZSZContext context = new ZSZContext())
            {
                BaseService<AdminUserEntity> adbs = new BaseService<AdminUserEntity>(context);
                var items = adbs.GetAll();
                if (!string.IsNullOrEmpty(keyWords))
                {
                    items = items.Where(e => e.Name.Contains(keyWords) || e.PhoneNum.Contains(keyWords));
                }

                return items.AsNoTracking().OrderByDescending(m => m.CreateDateTime).Skip(currentIndex).Take(pageSize).ToList().Select(u => ToDTO(u)).ToArray();


            }
        }

        public AdminUserDTO GetById(long id)
        {
            using (ZSZContext ctx = new ZSZContext())
            {
                BaseService<AdminUserEntity> bs
                    = new BaseService<AdminUserEntity>(ctx);
                //这里不能用bs.GetById(id);因为无法Include、AsNoTracking()等
                var user = bs.GetAll()
                    .AsNoTracking().SingleOrDefault(u => u.Id == id);
                //.AsNoTracking().Where(u=>u.Id==id).SingleOrDefault();
                //var user = bs.GetById(id); 用include就不能用GetById
                if (user == null)
                {
                    return null;
                }
                return ToDTO(user);
            }
        }

        public long GetTotalCount(string keyWords)
        {
            using (ZSZContext zsz = new ZSZContext())
            {
                BaseService<AdminUserEntity> bsAdmin = new BaseService<AdminUserEntity>(zsz);
                if (!string.IsNullOrEmpty(keyWords))
                {
                    var list = bsAdmin.GetAll().Where(e => e.Name.Contains(keyWords) || e.PhoneNum.Contains(keyWords));
                    return list.LongCount();
                }
                return bsAdmin.GetTotalCount();
            }
        }

        public bool HasPermission(long adminUserId, string permissionName)
        {
            //using (ZSZContext zsz = new ZSZContext())
            //{
            //    BaseService<AdminUserEntity> bsAdmin = new BaseService<AdminUserEntity>(zsz);
            //    var admin = bsAdmin.GetById(adminUserId);
            //    if (admin == null)
            //    {
            //        throw new Exception("没有id为" + adminUserId + "的用户");
            //    }
            //    var permissions = admin.Roles.Select(m=>m.Permissions).ToList();

            //}


            using (ZSZContext ctx = new ZSZContext())
            {
                BaseService<AdminUserEntity> bs
                    = new BaseService<AdminUserEntity>(ctx);
                var user = bs.GetAll().Include(u => u.Roles)
                    .AsNoTracking().SingleOrDefault(u => u.Id == adminUserId);
                //var user = bs.GetById(adminUserId);
                if (user == null)
                {
                    throw new ArgumentException("找不到id=" + adminUserId + "的用户");
                }
                //每个Role都有一个Permissions属性
                //Roles.SelectMany(r => r.Permissions)就是遍历Roles的每一个Role
                //然后把每个Role的Permissions放到一个集合中
                //IEnumerable<PermissionEntity>
                return user.Roles.SelectMany(r => r.Permissions)
                    .Any(p => p.Name == permissionName);
            }
        }

        public AdminUserDTO IsExitTelePhone(string telPhone)
        {

            using (ZSZContext ctx = new ZSZContext())
            {
                BaseService<AdminUserEntity> bs
                    = new BaseService<AdminUserEntity>(ctx);
                var users = bs.GetAll()
                    .AsNoTracking().Where(u => u.PhoneNum == telPhone);
                int count = users.Count();
                if (count <= 0)
                {
                    return null;
                }
                else if (count == 1)
                {
                    return ToDTO(users.Single());
                }
                else
                {
                    throw new ApplicationException("找到多个手机号为" + telPhone + "的管理员");
                }
            }
        }

        public void UpdateAdminUser(long id, string name, string phoneNum, string password)
        {
            using (ZSZContext ct = new ZSZContext())
            {
                BaseService<AdminUserEntity> bs = new BaseService<AdminUserEntity>(ct);
                //先查询出来，再做更新
                var admin = bs.GetById(id);
                if (admin == null)
                {
                    throw new Exception("不存在id为" + id + "的管理员");
                }
                admin.Name = name;
                admin.PhoneNum = phoneNum;
                if (!string.IsNullOrEmpty(password))
                {
                    admin.PasswordHash = CommonHelper.CalcMD5(password + admin.PasswordSalt);
                }

                ct.SaveChanges();
            }
        }

        private AdminUserDTO ToDTO(AdminUserEntity user)
        {
            AdminUserDTO dto = new AdminUserDTO();
            dto.CreateDateTime = user.CreateDateTime;
            dto.Id = user.Id;
            dto.Name = user.Name;
            dto.PhoneNum = user.PhoneNum;
            return dto;
        }
    }
}

