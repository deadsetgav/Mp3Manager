using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRepository.Abstract
{
    interface ICollectionHandler
    {
        IArtistCollection ReadCollection(string directoryPath);
    }
}
