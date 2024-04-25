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

            //var mongoUri = "mongodb+srv://noahrdam:3ppAuGCEF0ee9b6k@webshopdb.a704cgt.mongodb.net/?retryWrites=true&w=majority&appName=webshopDB";
            var mongoUri = "mongodb://localhost:27017";


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
            var dbName = "Genbrugsmarked";
            var collectionName = "Purchases";

            collection = client.GetDatabase(dbName)
               .GetCollection<Purchase>(collectionName);

        }

        public void MakePurchase(Purchase purchase)
        {

            collection.InsertOne(purchase);
        }

        public List<Purchase> GetPurchasesByUsername(string username)
        {
            var purchases = collection.Find(ad => ad.User.Username.Equals(username, StringComparison.OrdinalIgnoreCase)).ToList();
            return purchases;
        }

    }
}