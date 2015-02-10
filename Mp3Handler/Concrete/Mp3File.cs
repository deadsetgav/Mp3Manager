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
        private string _albumArtist;

        public Mp3File(string fullFilePath)
        {
            this._fullFilePath = fullFilePath;
            this._albumArtist = "Ride";
        }

        public string FullFilePath
        {
            get { return _fullFilePath; }
        }

        public string AlbumArtist
        {
            get { return _albumArtist; }
        }
    }
}
