using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.Abstract
{
    class EmptyTrackFormatter : ITrackFormatter
    {
        public void Format(IMp3Metadata track)
        {
        }
    }
    
}
