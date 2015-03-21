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
        private int _albumCount;
 
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

        public int AlbumCount
        {
            get { return _albumCount; }
        }

        public IMusicCollection Add(IArtist artist)
        {
            var updateList = new List<IArtist>();
            updateList.AddRange(this._artistList);

            if (!this.ContainsArtist(artist))
            {
                 updateList.Add(artist);
            }

            return new MusicCollection()
            {
                _artistList =  updateList,
                _albumCount = this._albumCount 
                                + artist.NumberOfAlbums
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
                var artist = new Artist(album.ArtistName).Add(album);
                return this.Add(artist);
            }
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
        
        private IMusicCollection AddAlbumToArtist(IAlbum album)
        {
            var collection = new MusicCollection()
            {
                _artistList = this._artistList,
                _albumCount = this._albumCount + 1
            };

            collection._artistList
                .Where(f => f.Name == album.ArtistName)
                .FirstOrDefault()
                .Add(album);

            return collection;
        }

    }
}
