using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class DirectoryDoesntExistException : ApplicationException
    {
        public DirectoryDoesntExistException(string path)
            :base(string.Format("{0} doesn't exist",path))
        {
           
        }
    }
}
