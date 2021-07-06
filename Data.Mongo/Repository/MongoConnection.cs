using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mongo.Repository
{
  public static class MongoConnection
    {

        public static MongoClient client;
        public static IMongoDatabase db;

        public static IMongoDatabase Connection()
        {
            try
            {
                client = new MongoClient("mongodb://192.168.80.48:27017");
                db = client.GetDatabase("MongoExamDb");
                return db;
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
