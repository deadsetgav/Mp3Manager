using Common.Abstract;
using FileRepository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileRepository.Concrete
{
    class Mp3FileWriter : IMp3Writer
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
