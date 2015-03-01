using Common.Abstract;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRepository.Handlers
{
    class MusicDirectoryReader
    {
        private string[] _musicFileSearchPattern = { "*.mp3", "*.wma", "*.flac" };
        private string[] _albumArtSearchPattern = { "*.jpg", "*.bmp", "*.png", "*.jpeg" };

        private DirectoryInfo _dir;

        internal MusicDirectoryReader(string path)
        {
            if (Directory.Exists(path))
            {
                _dir = new DirectoryInfo(path);  
            }
            else
            {
                throw new DirectoryDoesntExistException(path);
            }
               
        }

        internal bool ContainsMusicFiles()
        {
            return ContainsFiles(_musicFileSearchPattern);
        }

        internal bool ContainsAlbumArt()
        {
            return ContainsFiles(_albumArtSearchPattern);
        }
        
        internal bool HasSubFolders()
        {
            return (_dir.GetDirectories().Count() > 0);
        }

        internal List<MusicDirectoryReader> GetSubFolders()
        {
            var list = new List<MusicDirectoryReader>();

            if (this.HasSubFolders())
            {
                var dirInfos = _dir.GetDirectories();
                foreach (var dir in dirInfos)
                {
                    list.Add(new MusicDirectoryReader(dir.FullName));
                }
            }
            return list;
        }

        internal List<FileInfo> GetMusicFiles()
        {
            return GetFiles(_musicFileSearchPattern);
        }
        
        internal List<FileInfo> GetAlbumArtFiles()
        {
            return GetFiles(_albumArtSearchPattern);
        }

        private List<FileInfo> GetFiles(string[] searchPattern)
        {
            var fileList = new List<FileInfo>();
            foreach (var pattern in searchPattern)
            {
                fileList.AddRange(_dir.GetFiles(pattern, SearchOption.TopDirectoryOnly));
            }
            return fileList;
        }

        private bool ContainsFiles(string[] extensions)
        {
            foreach (string pattern in extensions)
            {
                if (_dir.GetFiles(pattern, SearchOption.TopDirectoryOnly).Count() > 0)
                {
                    return true;
                }
            }
            return false;
        }
        
       
    }

    


}
