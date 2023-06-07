using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Common.ExtentionMethod
{
   public static class Pagination
    {
        public static IQueryable<TSource> ToPage<TSource>(this IQueryable<TSource> sources,int page,int pageSize,out int totalRow)
        {
            totalRow = sources.Count();
            return sources.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
