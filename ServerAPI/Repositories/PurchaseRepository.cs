using MongoDB.Bson;
using MongoDB.Driver;
using Core.Model;
using ServerAPI.Repositories.Interfaces;


namespace ServerAPI.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private IMongoClient client;
        private IMongoCollection<Purchase> collection;

        public PurchaseRepository()
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
            var dbName = "Genbrug";
            var collectionName = "Purchases";

            collection = client.GetDatabase(dbName)
               .GetCollection<Purchase>(collectionName);

        }

        public void MakePurchase(Purchase purchase)
        {
            collection.InsertOne(purchase);
        }

        public List<Purchase> GetAllPurchases()
        {
            return collection.Find(_ => true).ToList();
        }

        public async Task<List<Purchase>> GetPurchasesByUsername(string username)
        {
            var filter = Builders<Purchase>.Filter.Eq(p => p.User.Username, username);
            return await collection.Find(filter).ToListAsync();
        }

    }
}