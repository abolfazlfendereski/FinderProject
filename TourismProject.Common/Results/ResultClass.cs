
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Common.Results
{
   public class ResultMethods<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public resMethod Res { get; set; }
    }
    public class ResultMethodsWithOutData
    {        
        public string Message { get; set; }
        public resMethod Res { get; set; }
    }
    public enum resMethod
    {
        Success,
        Error,
        Warning,
        Info
    }
}
