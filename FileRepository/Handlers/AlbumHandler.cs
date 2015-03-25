using Common.Abstract;
using Common.Models;
using FileRepository.Abstract;
using FileRepository.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRepository.Handlers
{
    class AlbumHandler 
    {

        // TODO : This will need to know how to save albums / tracks and pass itself up to the Album class in common
        private MusicDirectoryReader _directoryReader;
        private IMp3Reader _mp3Reader;
       
        public AlbumHandler(MusicDirectoryReader directoryReader, IMp3Reader mp3Reader)
        {
            _directoryReader = directoryReader;
            _mp3Reader = mp3Reader;
        }

        public IAlbum Populate()
        {
            return new Album(PopulateTracks());
        }
        
        private List<IMp3> PopulateTracks()
        {
            var tracks = new List<IMp3>();
            foreach (var file in _directoryReader.GetMusicFiles())
            {
                tracks.Add(_mp3Reader.Get(file.FullName));
            }
            return tracks;
        }

        

    }
}
