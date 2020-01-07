using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.DTO;
using ZSZ.IService;
using System.Data.Entity;

namespace ZSZ.Service
{
    public class PremissionsService : IPremissionService
    {
        public long AddPermission(string name, string des)
        {
            using (ZSZContext DB = new ZSZContext())
            {
                //校验此权限是否已经添加过
                PermissionEntity p = new PermissionEntity();
                p.Description = des;
                p.Name =name;
                DB.Permissions.Add(p);
                DB.SaveChanges();//返回的就是刚才添加的信息的ID
                return p.Id;

            }
        }

        public bool DelePernmission(long id)
        {
            using (ZSZContext context = new ZSZContext())
            {
                BaseService<PermissionEntity> perService = new BaseService<PermissionEntity>(context);
                return perService.MarkDeleted(id);
            }
        }

        public PermissionsDTO[] GetAll()
        {
            //做EF查询和返回数据的操作
            using (ZSZContext context = new ZSZContext())
            {
                BaseService<PermissionEntity> perService = new BaseService<PermissionEntity>(context);
                //perService.GetAll().ToList().Select(m => ToDTO(m)).ToArray();
                return perService.GetAll().AsNoTracking().ToList().Select(m => ToDTO(m)).ToArray();//如果数据仅仅是查询出来展示用的，那么就可以在后面加上AsNoTracking
            }
        }

        public PermissionsDTO Getpermission(long id)
        {
            using (ZSZContext content = new ZSZContext())
            {
                BaseService<PermissionEntity> permissionService = new BaseService<PermissionEntity>(content);
                return ToDTO(permissionService.GetById(id));
            }
        }

        public void UpdatepPermission(long id, string permName, string description)
        {
            using (ZSZContext content = new ZSZContext())
            {
                BaseService<PermissionEntity> permissionService = new BaseService<PermissionEntity>(content);
                var perModel = permissionService.GetById(id);//先查出来
                if (perModel == null)
                {
                    throw new Exception("id不存在");
                }
                else
                {
                    perModel.Name = permName;
                    perModel.Description = description;
                    content.SaveChanges();//在更新
                }


            }
        }

        private PermissionsDTO ToDTO(PermissionEntity p)
        {
            PermissionsDTO dto = new PermissionsDTO();
            dto.CreateDateTime = p.CreateDateTime;
            dto.Description = p.Description;
            dto.Id = p.Id;
            dto.Name = p.Name;
            return dto;
        }
    }
}
