using Common.Abstract;
using Formatting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Formatting.ITracks
{
    class RemoveTrackNumberFromSongTitle : ITrackFormatter
    {
        ITrackFormatter _decoratedFormatter;

        public RemoveTrackNumberFromSongTitle()
        {
            _decoratedFormatter = new EmptyTrackFormatter();
        }

        public RemoveTrackNumberFromSongTitle(ITrackFormatter formatter)
        {
            _decoratedFormatter = formatter;
        }

        public void Format(IMp3Metadata mp3)
        {
            var reg = new Regex("^([0-9]*)(\\s)-(\\s)");
            var match = reg.Match(mp3.Title);
            mp3.Title =  mp3.Title.Remove(match.Index, match.Length);

            _decoratedFormatter.Format(mp3);
        }
    }
}
