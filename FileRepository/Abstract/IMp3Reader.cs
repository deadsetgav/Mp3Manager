using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRepository.Abstract
{
    interface IMp3Reader
    {
        IMp3 Get(string mp3file);
    }
}
