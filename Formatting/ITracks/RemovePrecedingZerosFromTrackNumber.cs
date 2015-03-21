﻿using Common.Abstract;
using Formatting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formatting.ITracks
{
    class RemovePrecedingZerosFromTrackNumber : ITrackFormatter
    {
        ITrackFormatter _decoratedFormatter;

        public RemovePrecedingZerosFromTrackNumber()
        {
            _decoratedFormatter = new EmptyTrackFormatter();
        }

        public RemovePrecedingZerosFromTrackNumber(ITrackFormatter formatter)
        {
            _decoratedFormatter = formatter;
        }

        public void Format(IMp3Metadata mp3)
        {
            if (mp3.Track.StartsWith("0"))
            {
                mp3.Track = mp3.Track.TrimStart('0');
            }

            _decoratedFormatter.Format(mp3);
        }
    }
}
