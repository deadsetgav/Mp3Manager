using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3Handler.Concrete
{
    internal class Mp3File : IMp3
    {
        private string _fullFilePath;
        private TagLib.File _tagLib;

        public Mp3File(string fullFilePath)
        {
            this._fullFilePath = fullFilePath;
            this._tagLib = TagLib.File.Create(fullFilePath);
        }

        public string FullFilePath
        {
            get { return _fullFilePath; }
        }

        public string AlbumArtist
        {
            get 
            { 
                return NullGuard(_tagLib.Tag.FirstAlbumArtist); 
            }
            set 
            { 
                _tagLib.Tag.AlbumArtists = new string[] { value }; 
            }
        }

        private string NullGuard(string value)
        {
            if (value == null)
                return string.Empty;
            else
                return value;
        }
    }
}
