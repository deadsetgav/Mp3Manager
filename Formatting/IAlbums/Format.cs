using Common.Abstract;
using Formatting.ITracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.IAlbums
{
    public class Format
    {

        public static IAlbum ReadyForCollection(IAlbum album)
        {

            var trackFormatters = new StandardiseArtist(album)
                                  .Add(new StandardiseAlbumTitle(album))
                                  .Add(new SetAlbumArtist(album))
                                  .Add(new RemoveTrackNumberFromSongTitle())
                                  .Add(new RemovePrecedingZerosFromTrackNumber());

            foreach (var mp3 in album.Tracks)
            {
                trackFormatters.Format(mp3);
            }

            return album;
        }

    }

}
