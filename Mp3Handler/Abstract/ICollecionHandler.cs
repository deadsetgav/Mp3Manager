using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionHandler.Abstract
{
    public interface ICollectionHandler
    {
        IMp3 Get(string mp3file);
    }
}
