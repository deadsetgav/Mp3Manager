using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.Abstract
{
    class TrackFormatDecorator : ITrackFormatter
    {
        protected ITrackFormatter _decoratedFormatter;

        public TrackFormatDecorator()
        {
            _decoratedFormatter = new EmptyTrackFormatter();
        }

        public virtual void Format(IMp3Metadata mp3)
        {
        }

        public TrackFormatDecorator Add(TrackFormatDecorator formatter)
        {
            formatter._decoratedFormatter = this;
            return formatter;   
        }

        private class EmptyTrackFormatter : ITrackFormatter
        {
            public void Format(IMp3Metadata track)
            {
            }
            public ITrackFormatter Add(TrackFormatDecorator formatter)
            {
                return this;
            }
        }
    }
}
