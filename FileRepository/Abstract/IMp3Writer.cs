﻿using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRepository.Abstract
{
    interface IMp3Writer
    {
        void CopyTo(IMp3File file, string destFilename);
        void MoveTo(IMp3File file, string destFilename);
    }
}
