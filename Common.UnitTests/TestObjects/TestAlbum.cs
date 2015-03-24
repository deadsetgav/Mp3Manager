using Common.Abstract;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UnitTests.TestObjects
{
    class TestAlbum : IAlbum
    {

        private List<IMp3Metadata> _testList;

        public string Title {get;set;}
        public string ArtistName { get; set; }
        public string Year { get; set; }

        public TestAlbum()
        {

        }
        public TestAlbum(List<IMp3Metadata> testTracks)
        {
            this._testList = testTracks;
        }

        public new IEnumerable<IMp3Metadata> Tracks
        {
            get
            {
                return _testList.ToArray();
            }
        }

        public static Album CowboysFromHell()
        {
            var tracks = new List<IMp3Metadata>();
            tracks.Add(new TestTrack { Track = "1", Title = "Cowboys From Hell", Album = "Cowboys From Hell", AlbumArtist = "Pantera", Artist = "Pantera", Year = "1991" });
            tracks.Add(new TestTrack { Track = "2", Title = "Primal Concrete Sledge", Album = "Cowboys From Hell", AlbumArtist = "Pantera", Artist = "Pantera", Year = "1991" });
            tracks.Add(new TestTrack { Track = "3", Title = "Psycho Holiday", Album = "Cowboys From Hell", AlbumArtist = "Pantera", Artist = "Pantera", Year = "1991" });
            tracks.Add(new TestTrack { Track = "4", Title = "Heresy", Album = "Cowboys From Hell", AlbumArtist = "Pantera", Artist = "Pantera", Year = "1991" });
            tracks.Add(new TestTrack { Track = "5", Title = "Cemetery Gates", Album = "Cowboys From Hell", AlbumArtist = "Pantera", Artist = "Pantera", Year = "1991" });
            tracks.Add(new TestTrack { Track = "6", Title = "Domination", Album = "Cowboys From Hell", AlbumArtist = "Pantera", Artist = "Pantera", Year = "1991" });
            tracks.Add(new TestTrack { Track = "7", Title = "Shattered", Album = "Cowboys From Hell", AlbumArtist = "Pantera", Artist = "Pantera", Year = "1991" });
            tracks.Add(new TestTrack { Track = "8", Title = "Clash with Reality", Album = "Cowboys From Hell", AlbumArtist = "Pantera", Artist = "Pantera", Year = "1991" });
            tracks.Add(new TestTrack { Track = "9", Title = "Medicine Man", Album = "Cowboys From Hell", AlbumArtist = "Pantera", Artist = "Pantera", Year = "1991" });
            tracks.Add(new TestTrack { Track = "10", Title = "Message in Blood", Album = "Cowboys From Hell", AlbumArtist = "Pantera", Artist = "Pantera", Year = "1991" });
            tracks.Add(new TestTrack { Track = "11", Title = "The Sleep", Album = "Cowboys From Hell", AlbumArtist = "Pantera", Artist = "Pantera", Year = "1991" });
            tracks.Add(new TestTrack { Track = "12", Title = "The Art Of Shredding", Album = "Cowboys From Hell", AlbumArtist = "Pantera", Artist = "Pantera", Year = "1991" });
            return new Album(tracks);
        }

        public static Album RoadsToJudah()
        {
            var tracks = new List<IMp3Metadata>();
            tracks.Add(new TestTrack { Track = "01", Title = "VIOLENT", Album = "Roads To Judah", Artist = "Deafheaven", AlbumArtist = "", Year = "2011" });
            tracks.Add(new TestTrack { Track = "02", Title = "Languge Games", Album = "Roads To Judah", Artist = "Deafheaven", AlbumArtist = "", Year = "2011" });
            tracks.Add(new TestTrack { Track = "03", Title = "Unrequited", Album = "Roads To Judah", Artist = "DEAFHEAVEN", AlbumArtist = "", Year = "2011" });
            tracks.Add(new TestTrack { Track = "04", Title = "Tunnel Of Trees", Album = "RoadsToJudah", Artist = "Deafheaven", AlbumArtist = "", Year = "2011" });
            return new Album(tracks);
        }

        public static Album AngelDust()
        {
            var albumTrack = new TestAlbumTrack("Angel Dust", "Faith No More", "1992");
            var tracks = new List<IMp3Metadata>();
            tracks.Add(albumTrack.Create("01", "Land Of Sunshine"));
            tracks.Add(albumTrack.Create("02", "Caffeine"));
            tracks.Add(albumTrack.Create("03", "Midlife Crisis"));
            tracks.Add(albumTrack.Create("04", "RV"));
            tracks.Add(albumTrack.Create("05", "Smaller and Smaller", null, "faith no more"));
            tracks.Add(albumTrack.Create("06", "Everything's Ruined"));
            tracks.Add(albumTrack.Create("07", "Malpractice"));
            tracks.Add(albumTrack.Create("08", "Kindergarten"));
            tracks.Add(albumTrack.Create("09", "Be Aggressive", null, "FAITH NO MORE"));
            tracks.Add(albumTrack.Create("10", "A Small Victory"));
            tracks.Add(albumTrack.Create("11", "Crack Hitler", null, "FaithNoMore"));
            tracks.Add(albumTrack.Create("12", "Jizzlobber"));
            tracks.Add(albumTrack.Create("13", "Midnight Cowboy"));
            tracks.Add(albumTrack.Create("14", "Easy"));
            return new Album(tracks);
        }

        public static Album Sap()
        {
            var tracks = new List<IMp3Metadata>();
            tracks.Add(new TestTrack { Track = "1", Title = "Brother", Album = "Sap", Year = "1994" });
            tracks.Add(new TestTrack { Track = "02", Title = "Got Me Wrong", Artist = "Alice In Chains" });
            tracks.Add(new TestTrack { Track = "3", Title = "Right Turn", Album = "Sap" });
            tracks.Add(new TestTrack { Track = "4", Title = "I Am Inside" });
            tracks.Add(new TestTrack { Track = "5", Title = "Love Story" });
            return new Album(tracks);
        }

        public static Album Babyteeth()
        {
            var tracks = new List<IMp3Metadata>();
            tracks.Add(new TestTrack { Track = "1", Title = "Meat Abstract", Album = "BabyTeeth", Artist = "Therapy?" });
            tracks.Add(new TestTrack { Track = "02", Title = "Skyward", Artist = "Therapy?" });
            tracks.Add(new TestTrack { Track = "3", Title = "Punishment Kiss", Album = "BabyTeeth", Artist = "Therapy?" });
            tracks.Add(new TestTrack { Track = "4", Title = "Animal Bones", Album = "BabyTeeth", Artist = "Therapy?" });
            tracks.Add(new TestTrack { Track = "5", Title = "Loser Cop", Album = "BabyTeeth", Artist = "Therapy?" });
            tracks.Add(new TestTrack { Track = "6", Title = "Innocent X", Album = "BabyTeeth", Artist = "Therapy?" });
            tracks.Add(new TestTrack { Track = "7", Title = "Dancin' With Manson", Album = "BabyTeeth", Artist = "Therapy?" });
            return new Album(tracks);
        }
    }

    class TestAlbumTrack
    {
        string _album;
        string _artist;
        string _year;

        public TestAlbumTrack(string album, string artist, string year)
        {
            _album = album;
            _artist = artist;
            _year = year;
        }

        public TestTrack Create(string track, string title, string album = null, string artist = null, string year = null)
        {
            return new TestTrack
            {
                Track = track,
                Title = title,
                Album = NullSafe(album, _album),
                Artist = NullSafe(artist, _artist),
                AlbumArtist = NullSafe(artist, _artist),
                Year = NullSafe(year, _year)
            };
        }
        private string NullSafe(string value, string defaultTo)
        {
            if (value == null)
                return defaultTo;
            else
                return value;
        }
    }


}
