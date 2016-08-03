using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXKJ.Common
{
    public class ReturnResult
    {
        public bool Result { get; set; } = false;
        public object Tag { get; set; } = null;
        public string Message { get; set; } = string.Empty;
    }
}
