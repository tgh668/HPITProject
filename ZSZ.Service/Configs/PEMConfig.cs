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
    class PEMConfig : EntityTypeConfiguration<PEMEntity>
    {
        public PEMConfig()
        {
            ToTable("T_PEMS");
           
            this.HasRequired(e => e.InterViewPM).WithMany().HasForeignKey(e => e.InterViewPMId).WillCascadeOnDelete(false);
            this.HasRequired(e => e.ZPPM).WithMany().HasForeignKey(e => e.ZPPMId).WillCascadeOnDelete(false);
            this.HasRequired(e => e.Education).WithMany().HasForeignKey(e => e.EducationId).WillCascadeOnDelete(false);
            Property(e => e.Name).IsRequired().HasMaxLength(20);
            Property(e => e.Gender).IsRequired().HasMaxLength(20);
            Property(e => e.Age).IsOptional();
            Property(e => e.MSGW).IsRequired().HasMaxLength(20);
            this.HasRequired(e => e.IntendAbility).WithMany().HasForeignKey(e => e.IntendAbilityId).WillCascadeOnDelete(false);
            Property(e => e.IntendExplain).IsOptional().HasMaxLength(300);
            this.HasRequired(e => e.PersonAbility).WithMany().HasForeignKey(e => e.PersonAbilityId).WillCascadeOnDelete(false);
            this.HasRequired(e => e.AnaLyzeAbility).WithMany().HasForeignKey(e => e.AnaLyzeAbilityId).WillCascadeOnDelete(false);
            this.HasRequired(e => e.ExpressAbility).WithMany().HasForeignKey(e => e.ExpressAbilityID).WillCascadeOnDelete(false);

            Property(e => e.ExpressExplain).IsOptional().HasMaxLength(300);
            this.HasRequired(e => e.UnderStandAbility).WithMany().HasForeignKey(e => e.UnderStandAbilityId).WillCascadeOnDelete(false);
            Property(e => e.UnderStandExplain).IsOptional().HasMaxLength(300);
            this.HasRequired(e => e.ManagerAbility).WithMany().HasForeignKey(e => e.ManagerAbilityId).WillCascadeOnDelete(false);
            Property(e => e.ManagerExplain).IsOptional().HasMaxLength(300);
            this.HasRequired(e => e.ResponsibilityAbility).WithMany().HasForeignKey(e => e.ResponsibilityAbilityId).WillCascadeOnDelete(false);
            Property(e => e.ResponsibilityExplain).IsOptional().HasMaxLength(300);

            this.HasRequired(e => e.KSXAbility).WithMany().HasForeignKey(e => e.KSXAbilityId).WillCascadeOnDelete(false);
            Property(e => e.KSXAbilityExplain).IsOptional().HasMaxLength(300);

            this.HasRequired(e => e.QHLAbility).WithMany().HasForeignKey(e => e.QHLAbilityId).WillCascadeOnDelete(false);
            Property(e => e.OtherAbilityZB).IsOptional().HasMaxLength(300);

            this.HasRequired(e => e.OtherAbility).WithMany().HasForeignKey(e => e.OtherAbilityId).WillCascadeOnDelete(false);

            this.HasRequired(e => e.Result).WithMany().HasForeignKey(e => e.ResultId).WillCascadeOnDelete(false);
            Property(e => e.ResultExplain).IsOptional().HasMaxLength(300);
            Property(e => e.TrainPeople).IsRequired().HasMaxLength(20);
            this.HasRequired(e => e.Candidate).WithMany().HasForeignKey(e => e.CandidateId).WillCascadeOnDelete(false);

        }
    }
}
