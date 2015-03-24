using Common.Abstract;
using Common.Exceptions;
using FileRepository.Abstract;
using FileRepository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRepository.Handlers
{
    class Mp3Handler : IMp3Reader, IMp3Writer
    {
        private IMp3Writer _writer;

        public Mp3Handler()
        {
            _writer = new Mp3FileWriter();
        }

        public Mp3Handler(IMp3Writer writer)
        {
            _writer = writer;
        }

        public IMp3 Get(string fullFilePath)
        {
            try
            {
                return new Mp3File(fullFilePath, _writer);
            }
            catch (Exception ex)
            {
                throw new ErrorRetrievingMp3Exception(fullFilePath, ex);
            }
        }

        public void CopyTo(IMp3File file, string destFilename)
        {
            _writer.CopyTo(file, destFilename);
        }

        public void MoveTo(IMp3File file, string destFilename)
        {
            _writer.MoveTo(file,destFilename);
        }
    }
}
