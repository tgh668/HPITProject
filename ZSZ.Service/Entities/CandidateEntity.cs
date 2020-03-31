using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service.Entities
{
    /// <summary>
    /// 应聘者表
    /// </summary>
    public class CandidateEntity:BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string TelPhone { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string Education { get; set; }  
        /// <summary>
        /// 面试岗位
        /// </summary>
        public string MSGW { get; set; }

    }
}
