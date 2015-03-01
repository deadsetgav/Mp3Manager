using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class MusicCollection : IMusicCollection
    {
        private List<IArtist> _artistList;

        public MusicCollection()
        {
            this._artistList = new List<IArtist>();
        }

        #region IArtistCollection

        public IEnumerable<IArtist> Artists
        {
            get { return _artistList.ToArray(); }
        }

        public int ArtistCount
        {
            get { return _artistList.Count; }
        }

        public IMusicCollection Add(IArtist artist)
        {
            var updateList = new List<IArtist>();
            updateList.AddRange(_artistList);

            if (!this.ContainsArtist(artist))
            {
                 updateList.Add(artist);
            }

            return new MusicCollection()
            {
                _artistList =  updateList
            };
        }

        public IMusicCollection Add(IAlbum album)
        {
            if (this.ContainsArtist(album.ArtistName))
            {
                return AddAlbumToArtist(album);
            }
            else
            {
                var artist = new Artist(album.ArtistName);
                return this.Add(artist);
            }
        }

        private IMusicCollection AddAlbumToArtist(IAlbum album)
        {
            _artistList
                .Where(f => f.Name == album.ArtistName)
                .FirstOrDefault()
                .Add(album);

            return this;
        }

        public bool ContainsArtist(IArtist artist)
        {
            return _artistList.Contains(artist);
        }

        public bool ContainsArtist(string artistName)
        {
            return ContainsArtist(new Artist(artistName));
        } 

        #endregion
    }
}
