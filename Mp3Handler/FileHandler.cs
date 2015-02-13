using Common.Abstract;
using Common.Exceptions;
using Mp3Handler.Abstract;
using Mp3Handler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3Handler
{
    public class FileHandler
    {
        private IWriter _writer;

        public FileHandler()
        {
            _writer = new FileWriter();
        }
        public FileHandler(IWriter writer)
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
