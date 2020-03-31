using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service.Entities;

namespace ZSZ.Service.Configs
{
    class TutorConfig: EntityTypeConfiguration<TutorEntity>
    {
        public TutorConfig()
        {
            ToTable("T_Tutors");
            Property(p => p.Name).IsRequired().HasMaxLength(20);
          
        }
    }
}
