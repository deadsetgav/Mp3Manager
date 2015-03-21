using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UnitTests.TestObjects
{
    class TestAlbum : IAlbum
    {
        public string Title {get;set;}
        public string ArtistName { get; set; }
     
        public IEnumerable<IMp3Metadata> Tracks
        {
            get { throw new NotImplementedException(); }
        }
    }

}
