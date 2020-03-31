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
    class ResumeSourceConfig : EntityTypeConfiguration<ResumeSourceEntity>
    {
        public ResumeSourceConfig()
        {
            ToTable("T_ResumeSource");
            Property(p => p.Source).IsRequired().HasMaxLength(30);
        }
    }
}
