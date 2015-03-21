using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.Abstract
{
    interface IAlbumFormatter
    {
        void Format(IAlbum album);
    }
}
