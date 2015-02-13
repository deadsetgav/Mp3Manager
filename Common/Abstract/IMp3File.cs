using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Abstract
{
    public interface IMp3File
    {
        string FullFilePath { get; }

        void Save();
        void CopyTo(string filepath);
        void MoveTo(string filepath);
    }
}
