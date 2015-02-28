using Common.Abstract;
using Common.Models;
using FileRepository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRepository.Handlers
{
    class CollectionHandler : ICollectionHandler
    {
        public IArtistCollection ReadCollection(string directoryPath)
        {

            var directory = new MusicDirectory(directoryPath);



            return new ArtistCollection()
                        .Add(new Artist("test1"))
                        .Add(new Artist("test2"))
                        .Add(new Artist("test3"));
        }


    }

   
}
