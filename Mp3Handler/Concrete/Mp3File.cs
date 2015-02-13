using Common.Abstract;
using MusicCollectionHandler.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionHandler.Concrete
{
    internal class Mp3File : IMp3
    {
        private string _fullFilePath;
        private IMp3Writer _writer;
        private TagLib.File _tagLib;

        public Mp3File(string fullFilePath, IMp3Writer writer)
        {
            this._fullFilePath = fullFilePath;
            this._writer = writer;
            this._tagLib = TagLib.File.Create(fullFilePath);
        }

        public string FullFilePath
        {
            get { return _fullFilePath; }
        }

        #region Read & Write Tags

        public string Album
        {
            get 
            {
                return NullGuard(_tagLib.Tag.Album); 
            }
            set 
            {
                _tagLib.Tag.Album = value; 
            }
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

        public string Artist
        {
            get 
            { 
                return NullGuard(_tagLib.Tag.FirstPerformer); 
            }
            set 
            { 
                _tagLib.Tag.Performers = new string[] { value }; 
            }
        }
        
        public string Title
        {
            get 
            { 
                return NullGuard(_tagLib.Tag.Title); 
            }
            set 
            { 
                _tagLib.Tag.Title = value; 
            }
        }

        public string Track
        {
            get 
            { 
                return NullGuard(_tagLib.Tag.Track.ToString()); 
            }
            set 
            { 
                _tagLib.Tag.Track = Convert.ToUInt16(value); 
            }
        }

        public string Year
        {
            get 
            { 
                return NullGuard(_tagLib.Tag.Year.ToString()); 
            }
            set 
            { 
                _tagLib.Tag.Year = Convert.ToUInt16(value); 
            }
        }

        public int BitRate
        {
            get 
            { 
                return _tagLib.Properties.AudioBitrate; 
            }
        }

        #endregion

        #region Private Helper Methods
        private string NullGuard(string value)
        {
            if (value == null)
                return string.Empty;
            else
                return value;
        }
        #endregion

        #region Saving

        public void Save()
        {
            this._tagLib.Save();
        }

        public void CopyTo(string filepath)
        {
            _writer.CopyTo(this, filepath);
        }

        public void MoveTo(string filepath)
        {
            _writer.MoveTo(this, filepath);
        }

        #endregion
    }
}
