using Common.Abstract;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository.ModelMapping
{
    class DataModelMapper
    {
        public static UpdateDocument GetAlbumAsBson(IAlbum album)
        {
            var writeAlbum = new UpdateDocument()
               {
                   { "Artist", album.ArtistName },
                   { "Album", album.Title },
                   { "Year", album.Year },
                   // { "BitRate", album.GetAverageBitRateFromTracks() },
                   { "Tracks", GetAlbumTracksAsBson(album) }
               };
            return writeAlbum;
        }

        public static BsonArray GetAlbumTracksAsBson(IAlbum album)
        {
            var tracks = new BsonArray();
            foreach (IMp3Metadata mp3 in album.Tracks)
            {
                var dbTrack = GetMp3AsBson(mp3);
                tracks.Add(dbTrack);
            }

            return tracks;
        }

        public static BsonDocument GetMp3AsBson(IMp3Metadata mp3)
        {
            return new BsonDocument()
                {
                   { "Track", mp3.Track },
                   { "Title", mp3.Title },
                   { "BitRate", mp3.BitRate },
                  
                };
        }
    }
}
