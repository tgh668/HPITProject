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
    class InterViewerConfig : EntityTypeConfiguration<InterViewerEntity>
    {
        public InterViewerConfig()
        {
            ToTable("T_InterViewer");      
            Property(h => h.Name).IsRequired().HasMaxLength(30);
           
        }
    }
}
