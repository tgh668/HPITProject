using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service.Entities
{
    /// <summary>
    /// 招聘信息明细表
    /// </summary>
    public class EmployMentsEntity : BaseEntity
    {
        /// <summary>
        /// 邀约人
        /// </summary>
        public long AdminUserId { get; set; }
        public virtual AdminUserEntity AdminUser { get; set; }
        /// <summary>
        /// 星期几
        /// </summary>
        public int Week { get; set; }
        /// <summary>
        /// 周数
        /// </summary>
        public int Weeks { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 应聘者
        /// </summary>
        public long CandidateId { get; set; }
        public virtual CandidateEntity Candidate { get; set; }

     
        public string Gender { get; set; }
        public int Age { get; set; }
        public string TelPhone { get; set; }
        public long EducationId { get; set; }
        public virtual IdNameEntity Education { get; set; }
        /// <summary>
        /// 岗位id
        /// </summary>
        public long GWID { get; set; }
        public virtual IdNameEntity GW { get; set; }
        public string MSGW { get; set; }
        public string GTQK { get; set; }
        /// <summary>
        /// 电话沟通结果
        /// </summary>
        public long TelGtId { get; set; }
        public virtual IdNameEntity TelGt { get; set; }
        /// <summary>
        /// 面试日期
        /// </summary>
        public DateTime InterViewDate { get; set; }
        /// <summary>
        /// 初次预约面试时间
        /// </summary>
        public DateTime FirstMSTime { get; set; }
        /// <summary>
        /// 一面上门状态
        /// </summary>
        public long FirstSmId { get; set; }
        public virtual IdNameEntity FirstSm { get; set; }
        /// <summary>
        /// 一面面试官
        /// </summary>
        public long FirstInterviewId { get; set; }
        public virtual AdminUserEntity FirstInterview { get; set; }
        /// <summary>
        /// 一面结果
        /// </summary>
        public long FirstResultId { get; set; }
        public virtual IdNameEntity FirstResult { get; set; }
        /// <summary>
        /// 一面备注
        /// </summary>
        public long FirstBZId { get; set; }
        public virtual IdNameEntity FirstBZ { get; set; }

        public DateTime SecondInterViewDate { get; set; }
        public DateTime SecondMSTime { get; set; }
        /// <summary>
        /// 2面上门状态
        /// </summary>
        public long SecondSmId { get; set; }
        public virtual IdNameEntity SecondSm { get; set; }
        /// <summary>
        /// 二面面试官
        /// </summary>
        public long SecondInterviewId { get; set; }
        public virtual AdminUserEntity SecondInterview { get; set; }
        /// <summary>
        /// 二面结果
        /// </summary>
        public long SecondResultId { get; set; }
        public virtual IdNameEntity SecondResult { get; set; }

        /// <summary>
        /// 2面备注
        /// </summary>
        public long SecondBZId { get; set; }
        public virtual IdNameEntity SecondBZ { get; set; }
        public DateTime BDRQ { get; set; }
        public DateTime BDSJ { get; set; }

        public long SGZTID { get; set; }
        public virtual IdNameEntity SGZT { get; set; }

        /// <summary>
        /// 导师
        /// </summary>
        public long TutorId { get; set; }
        public virtual TutorEntity Tutor { get; set; }
        public bool IsLY { get; set; }
        /// <summary>
        /// 报道部门
        /// </summary>
        public long DepartmentId { get; set; }
        public virtual DepartmentEntity Department { get; set; }
        /// <summary>
        /// 真实报道时间
        /// </summary>
        public DateTime TrueBdDate { get; set; }
        public long SGJGID { get; set; }
        public virtual IdNameEntity SGJG { get; set; }
        public string JLPath { get; set; }
        public long ResumeSourceId { get; set; }
        public virtual ResumeSourceEntity ResumeSource { get; set; }

    }
}
