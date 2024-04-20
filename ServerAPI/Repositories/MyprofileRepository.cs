using MongoDB.Bson;
using MongoDB.Driver;
using Core.Model;
using ServerAPI.Repositories.Interfaces;


namespace ServerAPI.Repositories
{
    public class MyprofileRepository : IMyprofileRepository
    {
        private IMongoClient client;
        private IMongoCollection<Advertisement> collection;

        public MyprofileRepository()
        {

            var mongoUri = "mongodb+srv://noahrdam:3ppAuGCEF0ee9b6k@webshopdb.a704cgt.mongodb.net/?retryWrites=true&w=majority&appName=webshopDB";



            try
            {
                client = new MongoClient(mongoUri);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem connecting to your " +
                    "Atlas cluster. Check that the URI includes a valid " +
                    "username and password, and that your IP address is " +
                    $"in the Access List. Message: {e.Message}");
                Console.WriteLine(e);
                Console.WriteLine();
                return;
            }

            // Provide the name of the database and collection you want to use.
            // If they don't already exist, the driver and Atlas will create them
            // automatically when you first write data.
            var dbName = "webshopDB";
            var collectionName = "advertisements";

            collection = client.GetDatabase(dbName)
               .GetCollection<Advertisement>(collectionName);

        }

        public void CreateAdvertisement()
        {

        }

        public void DeleteAdvertisement()
        {

        }

        public void EditAdvertisement()
        {

        }

    }
}