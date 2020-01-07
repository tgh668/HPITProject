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
    public class RoleService : IRoleService
    {
        public RoleDTO[] GetAll()
        {
            using (ZSZContext db = new ZSZContext())
            {
                BaseService<RoleEntity> roles = new BaseService<RoleEntity>(db);
                return roles.GetAll().AsNoTracking().ToList().Select(m => ToDTO(m)).ToArray();
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
