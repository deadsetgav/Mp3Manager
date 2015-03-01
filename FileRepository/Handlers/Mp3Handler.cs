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
    class Mp3Handler : IMp3Reader
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
    }
}
