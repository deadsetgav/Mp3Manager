using Common.Abstract;
using Common.Models;
using FileRepository.Abstract;
using FileRepository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRepository.Handlers
{
    class CollectionHandler : ICollectionHandler
    {
        IMp3Handler _mp3Handler;
        ArtistCollection _collection;

        public CollectionHandler()
        {
            _mp3Handler = new Mp3Handler();
        }

        internal CollectionHandler(IMp3Handler Handler)
        {
            _mp3Handler = Handler;
        }

        public IArtistCollection ReadCollection(string directoryPath)
        {
            _collection = new ArtistCollection();

            var directory = new MusicDirectory(directoryPath);


            return new ArtistCollection()
                        .Add(new Artist("test1"))
                        .Add(new Artist("test2"))
                        .Add(new Artist("test3"));
        }

        private void ReadDirectory(MusicDirectory directory)
        {
            if (directory.ContainsMusicFiles())
            {
              
            }
        }

    }

   
}
