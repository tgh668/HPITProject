using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Web.Common
{
    /// <summary>
    /// 分页的类
    /// </summary>
    public class Pageing
    {
        /// <summary>
        /// 每一页数据的条数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总数据条数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 显示出来的页码的最多个数
        /// </summary>
        public int MaxPagerCount { get; set; }

        /// <summary>
        /// 当前页的页码（从1开始算起始页）
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 链接的格式，约定其中页码用{pn}占位符
        /// </summary>
        public string UrlPattern { get; set; }

        /// <summary>
        /// 当前页的页码的样式名字
        /// </summary>
        public string CurrentPageClassName { get; set; }

        public string GetPagerHtml()
        {
            StringBuilder html = new StringBuilder();
            html.Append("<div  class='layui-box layui-laypage layui-laypage-default'>");

            //ToDO：加上上一页、下一页、首页、末页、页面跳转等。


            //总页数
            int pageCount = (int)Math.Ceiling(TotalCount * 1.0 / PageSize);
            //显示出来的页码的起始页码
            int startPageIndex = Math.Max(1, PageIndex - MaxPagerCount / 2);
            //显示出来的页码的结束页码
            int endPageIndex = Math.Min(pageCount, startPageIndex + MaxPagerCount);
            for (int i = startPageIndex; i <= endPageIndex; i++)
            {

                //是当前页
                if (i == PageIndex)
                {
                    html.Append("<span class='layui-laypage-curr'><em class='layui-laypage-em'></em><em>")
                        .Append(i).Append("</em></span>");

                }
                else
                {
                    string href = UrlPattern.Replace("{pn}", i.ToString());
                    html.Append("<a href='").Append(href).Append("'>")
                        .Append(i).Append("</a>");
                }
            }          

            html.Append("</div>");
            return html.ToString();
        }
    }
}
