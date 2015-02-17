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
        private List<IArtist> _artistList;

        public ArtistCollection()
        {
            this._artistList = new List<IArtist>();
        }

        #region IArtistCollection

        public IEnumerable<IArtist> Artists
        {
            get { return _artistList.ToArray(); }
        }

        public int Count
        {
            get { return _artistList.Count; }
        }

        public IArtistCollection Add(IArtist artist)
        {
            var updateList = new List<IArtist>();
            updateList.AddRange(_artistList);

            if (!this.ContainsArtist(artist))
            {
                 updateList.Add(artist);
            }

            return new ArtistCollection()
            {
                _artistList =  updateList
            };
        }
       
        #endregion

        private bool ContainsArtist(IArtist artist)
        {
            return _artistList.Contains(artist);
        }
    }
}
