using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.Abstract
{
    abstract class TrackFormatDecorator : ITrackFormatter
    {
        protected ITrackFormatter _formatter;

        public TrackFormatDecorator()
        {
            _formatter = new EmptyTrackFormatter();
        }

        public abstract void Format(IMp3Metadata track);


        public TrackFormatDecorator Add(ITrackFormatter formatter)
        {
            _formatter = formatter;
            return this;
        }

        private class EmptyTrackFormatter : ITrackFormatter
        {
            public void Format(IMp3Metadata track)
            {
            }
        }
    }
}
