using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.UnitTests.TestObjects
{
    class TestTrack : IMp3Metadata
    {
        public string Album { get; set; }
        public string AlbumArtist { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Track { get; set; }
        public string Year { get; set; }
        public int BitRate { get; set; }
    }
}
