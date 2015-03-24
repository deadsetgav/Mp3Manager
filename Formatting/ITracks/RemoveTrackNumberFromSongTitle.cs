using Common.Abstract;
using Formatting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Formatting.ITracks
{
    class RemoveTrackNumberFromSongTitle : TrackFormatDecorator
    {
        public override void Format(IMp3Metadata mp3)
        { 
            base.Format(mp3);

            var reg = new Regex("^([0-9]*)(\\s)-(\\s)");
            var match = reg.Match(mp3.Title);
            mp3.Title =  mp3.Title.Remove(match.Index, match.Length).Trim();

        }
    }
}
