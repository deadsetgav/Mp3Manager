using Common.Abstract;
using MusicCollectionHandler.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.MusicCollectionHandler.TestObjects
{
    class TestWriter : IMp3Writer
    {
        private bool _copyToCalled = false;
        private bool _moveToCalled = false;
        private string _destFilename = string.Empty;

        public void CopyTo(IMp3File file, string destFilename)
        {
            _destFilename = destFilename;
            _copyToCalled = true;
        }

        public void MoveTo(IMp3File file, string destFilename)
        {
            _destFilename = destFilename;
            _moveToCalled = true;
        }

        public bool CopyToCalled()
        {
            return _copyToCalled;
        }

        public bool MoveToCalled()
        {
            return _moveToCalled;
        }

        public string GetDestinationFileName()
        {
            return _destFilename;
        }
    }
}
