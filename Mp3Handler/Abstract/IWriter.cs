using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3Handler.Abstract
{
    public interface IWriter
    {
        void CopyTo(IMp3File file, string destFilename);
        void MoveTo(IMp3File file, string destFilename);
    }
}
