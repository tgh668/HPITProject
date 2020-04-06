using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.DTO;
using ZSZ.IService;

namespace ZSZ.Service
{
    public class RoleService : IRoleService
    {
        public long Add(string name)
        {
            using (ZSZContext context = new ZSZContext())
            {
                RoleEntity r = new RoleEntity() { Name = name };
                context.Roles.Add(r);
                context.SaveChanges();
                return r.Id;
            }
        }

        public void AddRoleIds(long adminUserId, long[] roleIds)
        {
            //1:通过adminUSerID获取管理员信息
            using (ZSZContext context = new ZSZContext())
            {
                BaseService<AdminUserEntity> adminService = new BaseService<AdminUserEntity>(context);
                var adminModel = adminService.GetById(adminUserId);
                if (adminModel == null)
                {
                    throw new Exception("该用户不存在！！");
                }
                //2:添加对应的角色信息
                BaseService<RoleEntity> roleService = new BaseService<RoleEntity>(context);
                var roles = roleService.GetAll().Where(m => roleIds.Contains(m.Id)).ToArray();//获取选中的角色信息
                for (int i = 0; i < roles.Length; i++)
                {
                    adminModel.Roles.Add(roles[i]);
                }
                context.SaveChanges();
            }

        }

        public bool DeleRole(long id)
        {
            using (ZSZContext context = new ZSZContext())
            {
                BaseService<RoleEntity> roleService = new BaseService<RoleEntity>(context);
                return roleService.MarkDeleted(id);
            }
        }

        public RoleDTO[] GetAllRoles()
        {
            using (ZSZContext context = new ZSZContext())
            {
                BaseService<RoleEntity> roleService = new BaseService<RoleEntity>(context);
                return roleService.GetAll().AsNoTracking().ToList().Select(m => ToDTO(m)).ToArray();
            }
        }

        public RoleDTO[] GetByAdminUserId(long adminUserId)
        {
            using (ZSZContext context = new ZSZContext())
            {
                BaseService<AdminUserEntity> bs = new BaseService<AdminUserEntity>(context);
                var admin = bs.GetById(adminUserId);
                if (admin == null)
                {
                    throw new Exception("不存在id为" + adminUserId + "的用户");
                }
                return admin.Roles.Select(m => ToDTO(m)).ToArray();
            }
        }

        public RoleDTO GetById(long id)
        {
            using (ZSZContext context = new ZSZContext())
            {
                BaseService<RoleEntity> roleService = new BaseService<RoleEntity>(context);
                return ToDTO(roleService.GetById(id));
            }
        }

        public void UpdateRoleIds(long adminUserId, long[] roleIds)
        {
            using (ZSZContext context = new ZSZContext())
            {
                BaseService<AdminUserEntity> adminService = new BaseService<AdminUserEntity>(context);
                var adminModel = adminService.GetById(adminUserId);
                if (adminModel == null)
                {
                    throw new Exception("该用户不存在！！");
                }
                //删除用户原来的角色
                adminModel.Roles.Clear();
                //2:添加对应的角色信息
                BaseService<RoleEntity> roleService = new BaseService<RoleEntity>(context);
                var roles = roleService.GetAll().Where(m => roleIds.Contains(m.Id)).ToArray();//获取选中的角色信息
                for (int i = 0; i < roles.Length; i++)
                {
                    adminModel.Roles.Add(roles[i]);
                }
                context.SaveChanges();
            }
        }

        private RoleDTO ToDTO(RoleEntity en)
        {
            RoleDTO dto = new RoleDTO();
            dto.CreateDateTime = en.CreateDateTime;
            dto.Id = en.Id;
            dto.Name = en.Name;
            return dto;
        }
    }
}
