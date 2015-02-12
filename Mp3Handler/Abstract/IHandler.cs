using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3Handler.Abstract
{
    public interface IHandler
    {
        IMp3 Get(string mp3file);
    }
}
