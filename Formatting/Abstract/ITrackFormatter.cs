using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.Abstract
{
    interface ITrackFormatter
    {
        void Format(IMp3Metadata track);
    }
}
