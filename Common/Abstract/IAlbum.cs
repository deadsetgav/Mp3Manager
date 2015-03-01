using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Abstract
{
    public interface IAlbum
    {
        string Title { get; }
        string ArtistName { get; }
        IEnumerable<IMp3Metadata> Tracks { get; }
    }
}
