using Common.Abstract;
using Common.Exceptions;
using Common.Helpers;
using Formatting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.ITracks
{
    class StandardiseArtist : TrackFormatDecorator
    {
        IAlbum _album;

        public StandardiseArtist(IAlbum album)
        {
            _album = album;
        }

        public override void Format(IMp3Metadata mp3)
        {
            base.Format(mp3);

            if (string.IsNullOrEmpty(mp3.Artist) ||
                StringHelper.StringsCloselyMatch_IgnoreCaseAndNonAlphaNumeric(mp3.Artist, _album.ArtistName))
            {
                mp3.Artist = _album.ArtistName;
            }
            else
            {
                throw new TrackFormatException();
            }
            
        }
    }
}
