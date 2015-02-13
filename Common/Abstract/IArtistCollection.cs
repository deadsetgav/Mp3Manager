using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Abstract
{
    public interface IArtistCollection
    {
        IList<IArtist> Artists { get; }
    }
}
