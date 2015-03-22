using Common.Abstract;
using Formatting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Formatting.ITracks
{
    class AddTrackNumberToSongTitle : TrackFormatDecorator
    {
        public override void Format(IMp3Metadata mp3)
        {
            base.Format(mp3);

            if (!TitleStartsWithTrackNumber(mp3.Title))
            {
                mp3.Title = string.Format("{0} - {1}", mp3.Track, mp3.Title);
            }
        }
        
        protected static bool TitleStartsWithTrackNumber(string title)
        {
            var reg = new Regex("^([0-9]*)(\\s)-(\\s)");
            var match = reg.Match(title);
            return match.Success;
        }
    }
}
