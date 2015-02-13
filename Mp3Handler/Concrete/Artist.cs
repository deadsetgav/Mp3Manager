using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionHandler.Concrete
{
    class Artist : IArtist
    {
        private string _name;

        public Artist(string artistName)
        {
            this._name = artistName;    
        }

        public string Name 
        {
            get { return _name;  } 
        }

    }
}
