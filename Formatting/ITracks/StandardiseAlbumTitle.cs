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
    class StandardiseAlbumTitle : TrackFormatDecorator
    {
        IAlbum _album;

        public StandardiseAlbumTitle(IAlbum album)
        {
            _album = album;
        }

        public override void Format(IMp3Metadata mp3)
        {
            base.Format(mp3);

            if (string.IsNullOrEmpty(mp3.Album) ||
                StringHelper.StringsCloselyMatch_IgnoreCaseAndNonAlphaNumeric(mp3.Album, _album.Title))
            {
                mp3.Album = _album.Title;
            }
            else
            {
                throw new TrackFormatException();
            }
            
        }
    }
}
