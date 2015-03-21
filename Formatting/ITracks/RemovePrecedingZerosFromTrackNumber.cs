using Common.Abstract;
using Formatting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.ITracks
{
    class RemovePrecedingZerosFromTrackNumber : TrackFormatDecorator
    {
        public override void Format(IMp3Metadata mp3)
        {
            if (mp3.Track.StartsWith("0"))
            {
                mp3.Track = mp3.Track.TrimStart('0');
            }

            _formatter.Format(mp3);
        }
    }
}
