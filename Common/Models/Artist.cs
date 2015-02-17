using Common.Abstract;
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

        public Artist(string artistName)
        {
            this._name = artistName;
        }

        public string Name
        {
            get { return _name; }
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
