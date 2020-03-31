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
    class EmployMentsConfig : EntityTypeConfiguration<EmployMentsEntity>
    {
        public EmployMentsConfig()
        {
            ToTable("T_EmployMents");
            this.HasRequired(e => e.AdminUser).WithMany().HasForeignKey(e => e.AdminUserId).WillCascadeOnDelete(false);
            Property(e => e.Name).IsRequired().HasMaxLength(20);
            this.HasRequired(e => e.Candidate).WithMany().HasForeignKey(e => e.CandidateId).WillCascadeOnDelete(false);
            Property(e => e.Gender).IsRequired().HasMaxLength(10);
            Property(e => e.TelPhone).IsRequired().HasMaxLength(20).IsUnicode(false);
            this.HasRequired(e => e.Education).WithMany().HasForeignKey(e => e.EducationId).WillCascadeOnDelete(false);
            this.HasRequired(e => e.GW).WithMany().HasForeignKey(e => e.GWID).WillCascadeOnDelete(false);
            Property(e => e.MSGW).IsRequired().HasMaxLength(30);
            Property(e => e.GTQK).IsOptional().HasMaxLength(400);
            this.HasRequired(e => e.TelGt).WithMany().HasForeignKey(e => e.TelGtId).WillCascadeOnDelete(false);
            this.HasRequired(e => e.FirstSm).WithMany().HasForeignKey(e => e.FirstSmId).WillCascadeOnDelete(false);
            this.HasRequired(e => e.FirstInterview).WithMany().HasForeignKey(e => e.FirstInterviewId).WillCascadeOnDelete(false);
            this.HasRequired(e => e.FirstResult).WithMany().HasForeignKey(e => e.FirstResultId).WillCascadeOnDelete(false);
            this.HasRequired(e => e.FirstBZ).WithMany().HasForeignKey(e => e.FirstBZId).WillCascadeOnDelete(false);
            
            this.HasRequired(e => e.SecondSm).WithMany().HasForeignKey(e => e.SecondSmId).WillCascadeOnDelete(false);
            this.HasRequired(e => e.SecondInterview).WithMany().HasForeignKey(e => e.SecondInterviewId).WillCascadeOnDelete(false);
            this.HasRequired(e => e.SecondResult).WithMany().HasForeignKey(e => e.SecondResultId).WillCascadeOnDelete(false);
            this.HasRequired(e => e.SecondBZ).WithMany().HasForeignKey(e => e.SecondBZId).WillCascadeOnDelete(false);

            Property(e => e.BDRQ).IsOptional();
            Property(e => e.BDSJ).IsOptional();
            this.HasRequired(e => e.SGZT).WithMany().HasForeignKey(e => e.SGZTID).WillCascadeOnDelete(false);
            this.HasRequired(e => e.Tutor).WithMany().HasForeignKey(e => e.TutorId).WillCascadeOnDelete(false);
            this.HasRequired(e => e.Department).WithMany().HasForeignKey(e => e.DepartmentId).WillCascadeOnDelete(false);
            Property(e => e.TrueBdDate).IsOptional();

            this.HasRequired(e => e.SGJG).WithMany().HasForeignKey(e => e.SGJGID).WillCascadeOnDelete(false);
            Property(e => e.JLPath).IsRequired().HasMaxLength(60);
            this.HasRequired(e => e.ResumeSource).WithMany().HasForeignKey(e => e.ResumeSourceId).WillCascadeOnDelete(false);
        }
    }
}
