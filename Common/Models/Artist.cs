using Common.Abstract;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Artist : IArtist
    {
        private string _name;
        private List<IAlbum> _albums;

        public Artist(string artistName)
        {
            if (string.IsNullOrEmpty(artistName))
                throw new ArtistNameNullException();
            
            this._name = artistName;
            this._albums = new List<IAlbum>();
        }

        public string Name
        {
            get { return _name; }
        }

        public IEnumerable<IAlbum> Albums 
        {
            get { return _albums.ToArray(); }
        }

        public int NumberOfAlbums
        {
            get { return _albums.Count(); }
        }

        public IArtist Add(IAlbum album)
        {
            _albums.Add(album);
            return this;
        }


        #region Comparer
        
        public override bool Equals (object obj)
        {
            if (obj == null || GetType() != obj.GetType()) 
            {
                return false;
            }

            return SearchFriendly(this._name)
                .Equals(SearchFriendly((obj as IArtist).Name));
        }

        public override int GetHashCode()
        {
            return this._name.GetHashCode();
        }

        #endregion

        #region Private Helpers
        
        private string SearchFriendly(string term)
        {
            return term.ToLower().Trim();
        }
        
        #endregion


    }
}
