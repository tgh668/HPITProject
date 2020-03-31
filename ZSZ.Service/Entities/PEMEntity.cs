using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service.Entities
{
    public class PEMEntity : BaseEntity
    {
        public DateTime InterViewDate { get; set; }
     
        public long InterViewPMId { get; set; }
        public virtual AdminUserEntity InterViewPM { get; set; }
        public long ZPPMId { get; set; }
        public virtual AdminUserEntity ZPPM { get; set; }
        public long EducationId { get; set; }
        public virtual IdNameEntity Education { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string MSGW { get; set; }
        public long IntendAbilityId { get; set; }
        public virtual IdNameEntity IntendAbility { get; set; }
        public string IntendExplain { get; set; }

        public long PersonAbilityId { get; set; }
        public virtual IdNameEntity PersonAbility { get; set; }

        public long AnaLyzeAbilityId { get; set; }
        public virtual IdNameEntity AnaLyzeAbility { get; set; }



        public long ExpressAbilityID { get; set; }
        public virtual IdNameEntity ExpressAbility { get; set; }
        public string ExpressExplain { get; set; }
        public long UnderStandAbilityId { get; set; }
        public virtual IdNameEntity UnderStandAbility { get; set; }
        public string UnderStandExplain { get; set; }
        public long ManagerAbilityId { get; set; }
        public virtual IdNameEntity ManagerAbility { get; set; }
        public string ManagerExplain { get; set; }

        public long ResponsibilityAbilityId { get; set; }
        public virtual IdNameEntity ResponsibilityAbility { get; set; }
        public string ResponsibilityExplain { get; set; }

        public long KSXAbilityId { get; set; }
        public virtual IdNameEntity KSXAbility { get; set; }
        public string KSXAbilityExplain { get; set; }

        public long QHLAbilityId { get; set; }
        public virtual IdNameEntity QHLAbility { get; set; }

        public string OtherAbilityZB { get; set; }
        public long OtherAbilityId { get; set; }
        public virtual IdNameEntity OtherAbility { get; set; }
        public long ResultId { get; set; }
        public virtual IdNameEntity Result { get; set; }
        public string ResultExplain { get; set; }
        public string TrainPeople { get; set; }
        public long CandidateId { get; set; }
        public virtual CandidateEntity Candidate { get; set; }
    }
}
