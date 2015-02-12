using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class ErrorRetrievingMp3Exception : ApplicationException
    {
        public ErrorRetrievingMp3Exception(string filename, Exception ex)
            :base(string.Format("Could not retrieve {0}",filename), ex)
        {
           
        }
    }
}
