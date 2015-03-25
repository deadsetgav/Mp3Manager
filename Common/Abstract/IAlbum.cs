using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Abstract
{
    public interface IAlbum : ISave
    {
        string Title { get; }
        string ArtistName { get; }
        string Year { get; }
        IEnumerable<IMp3Metadata> Tracks { get; }
    }
}
