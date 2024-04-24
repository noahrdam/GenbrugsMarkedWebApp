using MongoDB.Bson;
using MongoDB.Driver;
using Core.Model;
using ServerAPI.Repositories.Interfaces;


namespace ServerAPI.Repositories
{
    public class AdsRepository : IAdsRepository
    {
        private IMongoClient client;
        private IMongoCollection<Advertisement> collection;

        public AdsRepository()
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
            var collectionName = "Advertisement";

            collection = client.GetDatabase(dbName)
               .GetCollection<Advertisement>(collectionName);

        }
        public List<Advertisement> GetAllAdvertisements()
        {
            return collection.Find(Builders<Advertisement>.Filter.Empty).ToList();
        }

        public List<Advertisement> GetAllByCategory(string category)
        {
            var filter = Builders<Advertisement>.Filter.Eq(ad => ad.Category, category);
            return collection.Find(filter).ToList();
        }

        public List<Advertisement> GetAdvertisementsByPrice(double minPrice, double maxPrice)
        {
            var filter = Builders<Advertisement>.Filter.Where(ad => ad.Price >= minPrice && ad.Price <= maxPrice);
            return collection.Find(filter).ToList();
        }

        public List<Advertisement> GetAdvertisementsByStatus(string status)
        {
            var filter = Builders<Advertisement>.Filter.Eq(ad => ad.Status, status);
            return collection.Find(filter).ToList();
        }

        public List<Advertisement> GetAdvertisementsByDetails(string searchKeyword)
        {
            var filter = Builders<Advertisement>.Filter.Or(
                Builders<Advertisement>.Filter.Regex(ad => ad.Name, new BsonRegularExpression(searchKeyword, "i")),
                Builders<Advertisement>.Filter.Regex(ad => ad.Description, new BsonRegularExpression(searchKeyword, "i"))
            );
            return collection.Find(filter).ToList();
        }

        public async Task<List<Advertisement>> GetAdvertisementsSortedByDate()
        {
            return await collection.Find(Builders<Advertisement>.Filter.Empty)
                                   .Sort(Builders<Advertisement>.Sort.Descending(ad => ad.Date))
                                   .ToListAsync();
        }

        public void CreateAdvertisement2(Advertisement advertisement)
        {
            collection.InsertOne(advertisement);
        }
    }
}