using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ArtistCollection : IArtistCollection
    {
        private List<IArtist> _artists;

        public ArtistCollection()
        {
            this._artists = new List<IArtist>();
        }

        public IEnumerable<IArtist> Artists
        {
            get { return _artists.ToArray(); }
        }

        public void Add(IArtist artist)
        {
            this._artists.Add(artist);
        }
    }
}
