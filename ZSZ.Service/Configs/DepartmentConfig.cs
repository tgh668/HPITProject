using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service;
using ZSZ.Service.Entities;

namespace ZSZ.DAL.ModelConfig
{
    class DepartmentConfig : EntityTypeConfiguration<DepartmentEntity>
    {
        public DepartmentConfig()
        {
            ToTable("T_Departments");
            Property(e => e.Name).IsRequired().HasMaxLength(20);
        }
    }
}
