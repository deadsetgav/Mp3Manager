using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Mp3Handler.Abstract;

namespace Mp3Handler.Concrete
{
    internal class FileWriter : IWriter
    {
        public void CopyTo(IMp3File file, string destFilename)
        {
            File.Copy(file.FullFilePath, destFilename);
        }

        public void MoveTo(IMp3File file, string destFilename)
        {
            File.Move(file.FullFilePath, destFilename);
        }
    }
}
