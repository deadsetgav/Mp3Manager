using Common.Abstract;
using Common.Exceptions;
using MusicCollectionHandler.Abstract;
using MusicCollectionHandler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionHandler
{
    public class CollectionHandler : ICollectionHandler
    {
        private IMp3Writer _writer;

        public CollectionHandler()
        {
            _writer = new Mp3FileWriter();
        }
        public CollectionHandler(IMp3Writer writer)
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

        public IArtistCollection ReadCollection(string directoryPath)
        {
            throw new NotImplementedException();
        }
    }
}
