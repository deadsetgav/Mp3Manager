using Common.Abstract;
using Mp3Handler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3Handler
{
    public class Handler
    {
        public IMp3 Get(string fullFilePath)
        {
            return new Mp3File(fullFilePath);
        }
    }
}
