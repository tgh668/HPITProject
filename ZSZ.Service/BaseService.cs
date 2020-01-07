using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service
{
    public class BaseService<T> where T : BaseEntity  //泛型约束  T就只能传递BaseEntity类型或者BaseEntity的子类
    {
        private ZSZContext zsz;
        public BaseService(ZSZContext zsz)
        {
            this.zsz = zsz;
        }

        /// <summary>
        /// 获取所有没有软删除的数据(?)
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return zsz.Set<T>().Where(e => e.IsDeleted == false); //此处为延迟加载，只用遍历结果集时候才执行sql语句，例如toList或者ToArray操作时候
        }



        /// <summary>
        /// 获取总数据条数
        /// </summary>
        /// <returns></returns>
        public long GetTotalCount()
        {
            return GetAll().LongCount();
        }



        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IQueryable<T> GetPagedData(int startIndex, int count)
        {
            return GetAll().OrderBy(e => e.CreateDateTime)
                .Skip(startIndex).Take(count);

            //skip就是跳过n调数据，Take就是取n条数据
        }

        /// <summary>
        /// 查找id=id的数据，如果找不到返回null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(long id)
        {
            //return GetAll().FirstOrDefault(T => T.Id == id);
            return GetAll().Where(m => m.Id == id).FirstOrDefault();
        }

        public bool MarkDeleted(long id)
        {
            var data = GetById(id);
            data.IsDeleted = true;
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

    }
}
