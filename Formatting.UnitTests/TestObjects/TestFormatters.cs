using Common.Abstract;
using Formatting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.UnitTests.TestObjects
{
    class TestFormatOne: TrackFormatDecorator
    {
        public override void Format(IMp3Metadata mp3)
        {    
            _decoratedFormatter.Format(mp3);
            mp3.Title = string.Format("{0} - {1}", mp3.Title, "Format-1");

        }
    }

    class TestFormatTwo : TrackFormatDecorator
    {
        public override void Format(IMp3Metadata mp3)
        {
            _decoratedFormatter.Format(mp3);
            mp3.Title = string.Format("{0} - {1}", mp3.Title, "Format-2");

        }
    }

    class TestFormatThree : TrackFormatDecorator
    {
        public override void Format(IMp3Metadata mp3)
        {
            _decoratedFormatter.Format(mp3);
            mp3.Title = string.Format("{0} - {1}", mp3.Title, "Format-3");

        }
    }
}
