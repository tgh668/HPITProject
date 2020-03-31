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
    class CandidateConfig : EntityTypeConfiguration<CandidateEntity>
    {
        public CandidateConfig()
        {
            ToTable("T_Candidates");
            Property(e => e.Name).IsRequired().HasMaxLength(20);
            Property(e => e.TelPhone).IsRequired().HasMaxLength(20).IsUnicode(false);//varchar
            Property(e => e.Education).IsRequired().HasMaxLength(20);
            Property(e => e.MSGW).IsRequired().HasMaxLength(30);
        }
    }
}
