using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Album : IAlbum
    {
        IEnumerable<IMp3Metadata> _tracks;

        public Album(IEnumerable<IMp3Metadata> tracks)
        {
            _tracks = tracks;
        }

        public string Title
        {
            get { return GetMostCommonAlbumTitleFromTracks(); }
        }

        public string ArtistName
        {
            get { return GetMostCommonArtistNameFromTracks(); }
        }

        public string Year
        {
            get { return GetMostCommonYearFromTracks(); }
        }

        public IEnumerable<IMp3Metadata> Tracks
        {
            get { return _tracks.ToArray(); }
        }

        private string GetMostCommonArtistNameFromTracks()
        {
            var artistName = Tracks.Select(f => f.Artist);
            return GetMostCommonString(artistName);
        }

        private string GetMostCommonAlbumTitleFromTracks()
        {
            var albumTitle = Tracks.Select(f => f.Album);
            var title = GetMostCommonString(albumTitle);

            if (title == null)
                return "Unknown Album";
            else
                return title;
        }

        private string GetMostCommonYearFromTracks()
        {
            var year = Tracks.Select(f => f.Year)
                .Where(y => y != null);

            if (year.Count() == 0)
                return string.Empty;
            else
                return GetMostCommonString(year);
        }

        private string GetMostCommonString(IEnumerable<string> searchlist)
        {
            var query = searchlist.GroupBy(item => item).
                    OrderByDescending(g => g.Count()).
                    Select(g => g.Key).First();

            return query;
        }

    }
}
