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
    public class PremissionService : IPremissionService
    {
        public PermissionDTO[] GetAll()
        {
            using (ZSZContext zsz = new ZSZContext())
            {
                BaseService<PermissionEntity> db = new BaseService<PermissionEntity>(zsz);
                return db.GetAll().AsNoTracking().ToList().Select(m => ToDTO(m)).ToArray();
            }
        }

        private PermissionDTO ToDTO(PermissionEntity p)
        {
            PermissionDTO dto = new PermissionDTO();
            dto.CreateDateTime = p.CreateDateTime;
            dto.Description = p.Description;
            dto.Id = p.Id;
            dto.Name = p.Name;
            return dto;
        }
    }
}
