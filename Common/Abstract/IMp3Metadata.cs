using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Abstract
{
    public interface IMp3Metadata
    {
        string Album { get; set; }
        string AlbumArtist { get; set; }
        string Artist { get; set; }
        string Title { get; set; }
        string Track { get; set; }
        string Year { get; set; }
        int BitRate { get; } 
    }
}
