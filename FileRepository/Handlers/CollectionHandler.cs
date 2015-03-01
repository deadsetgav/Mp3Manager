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
        IMp3Reader _mp3Handler;
        MusicCollection _collection;

        public CollectionHandler()
        {
            _mp3Handler = new Mp3Handler();
        }

        internal CollectionHandler(IMp3Reader Handler)
        {
            _mp3Handler = Handler;
        }

        public IMusicCollection ReadCollection(string directoryPath)
        {
            _collection = new MusicCollection();

            var directory = new MusicDirectoryReader(directoryPath);


            return new MusicCollection()
                        .Add(new Artist("test1"))
                        .Add(new Artist("test2"))
                        .Add(new Artist("test3"));
        }

        private void GetAlbumsFromDirectory(MusicDirectoryReader directory)
        {
            if (directory.ContainsMusicFiles())
            {
                var album = new Album(directory, this._mp3Handler);
                
                
            }
        }

    }

   
}
