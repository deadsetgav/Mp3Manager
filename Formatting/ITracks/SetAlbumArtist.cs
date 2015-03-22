using Common.Abstract;
using Formatting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.ITracks
{
    class SetAlbumArtist : TrackFormatDecorator
    {
        IAlbum _album;

        public SetAlbumArtist(IAlbum album)
        {
            _album = album;
        }

        public override void Format(IMp3Metadata mp3)
        {
            base.Format(mp3);

            mp3.AlbumArtist = _album.ArtistName;
        }
    }  
}
