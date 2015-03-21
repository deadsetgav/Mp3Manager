using Common.Abstract;
using Formatting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.ITracks
{
    class SetAlbumArtist : ITrackFormatter
    {
        IAlbum _album;
        ITrackFormatter _decoratedFormatter;

        public SetAlbumArtist(IAlbum album)
        {
            _album = album;
            _decoratedFormatter = new EmptyTrackFormatter();
        }

        public SetAlbumArtist(IAlbum album, ITrackFormatter formatter)
        {
            _album = album;
            _decoratedFormatter = formatter;
        }
      
        public void Format(IMp3Metadata mp3)
        {
            mp3.AlbumArtist = _album.ArtistName;

            _decoratedFormatter.Format(mp3);
        }
    }
}
