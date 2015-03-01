using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Abstract
{
    public interface IArtist
    {
        string Name { get; }
        IEnumerable<IAlbum> Albums { get; }
        IArtist Add(IAlbum album);
    }
}
