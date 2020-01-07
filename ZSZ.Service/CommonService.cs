using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service
{
    public class CommonService<T> where T : BaseEntity
    {
        public ZSZContext zsz { get; set; }
        public CommonService(ZSZContext zszModel)
        {
            this.zsz = zszModel;
        }

        /// <summary>
        /// 获取所有数据的通用方法
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return zsz.Set<T>().Where(m => m.IsDeleted == false);
        }
        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <returns></returns>
        public long GetTotalCount()
        {
            return GetAll().LongCount();
        }

        /// <summary>
        /// 根据Id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetByID(long id)
        {
            return GetAll().Where(m => m.Id == id).FirstOrDefault();
        }

        public bool MarkDeletd(long id)
        {
            var p = GetByID(id);
            p.IsDeleted = true;
            int r = zsz.SaveChanges();
            if (r > 0)
            {

                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="startIndex">开始索引位置</param>
        /// <param name="count">每页显示的条数</param>
        /// <returns></returns>
        public IQueryable<T> GetPageList(int startIndex,int count)
        {
            //分页前面必须加排序规则
            return GetAll().OrderBy(m => m.CreateDateTime).Skip(startIndex).Take(count);
        }
    }
}
