using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository.Abstract
{
    public interface IDataAccess
    {
        void Save(IAlbum album);
        IAlbum Get(string artist, string albumTitle);
        bool Exists(string artist, string albumTitle);
    }
}
