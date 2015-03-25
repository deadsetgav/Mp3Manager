using Common.Abstract;
using MongoDB.Driver;
using MongoRepository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{
    class DataAccess : IDataAccess
    {

        private MongoClient _client;
        private MongoServer _server;
        private MongoDatabase _db;
        private string _collectionName;

        public DataAccess(string collectionName)
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("Mp3Manager");
            _collectionName = collectionName;
        }

        public void Save(IAlbum album)
        {
            throw new NotImplementedException();
        }

        public IAlbum Get(string artist, string albumTitle)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string artist, string albumTitle)
        {
            throw new NotImplementedException();
        }
    }
}
