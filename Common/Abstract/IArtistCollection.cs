using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Abstract
{
    public interface IMusicCollection
    {
        IEnumerable<IArtist> Artists { get; }
        int ArtistCount { get; }
        
        IMusicCollection Add(IArtist artist);
        IMusicCollection Add(IAlbum album);

        bool ContainsArtist(IArtist artist);
        bool ContainsArtist(string artistName);
    }
}
