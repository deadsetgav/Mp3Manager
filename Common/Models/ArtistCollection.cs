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

        public void Add(IArtist artist)
        {
            if (!this.ContainsArtist(artist))
            {
                this._artistList.Add(artist);
            }
        }
       
        #endregion

        private bool ContainsArtist(IArtist artist)
        {
            return _artistList.Contains(artist);
        }
    }
}
