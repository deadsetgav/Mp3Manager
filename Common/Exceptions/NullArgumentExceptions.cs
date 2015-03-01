using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class ArtistNameNullException : ArgumentNullException
    {
        public ArtistNameNullException()
            : base("Artist name must be populated")
        {

        }
    }

    public class AlbumTitleNullException : ArgumentNullException
    {
        public AlbumTitleNullException()
            :base("Album title must be populated")
        {

        }
    }
}
