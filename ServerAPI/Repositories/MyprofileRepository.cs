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
            // Erstat med din faktiske MongoDB-forbindelsesstreng
            var mongoUri = "mongodb+srv://noahrdam:3ppAuGCEF0ee9b6k@webshopdb.a704cgt.mongodb.net/";
            //var mongoUri = "mongodb://localhost:27017";

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
             // Navnet på din database
             var dbName = "Genbrug";
            // Navnet på din samling i databasen, hvor annoncerne vil blive opbevaret
            var collectionName = "Advertisement";


            // Hent samlingen fra databasen
            collection = client.GetDatabase(dbName).GetCollection<Advertisement>(collectionName);
        }



        // Opretter en ny annonce og gemmer den i databasen
        public void CreateAdvertisement(Advertisement advertisement)
        {
           advertisement.Id = ObjectId.GenerateNewId();
            collection.InsertOne(advertisement);   
        }

        //Sletter en annonce fra databasen baseret på dens Id
        public void DeleteById(int advertisementId)
        {
            var deleteResult = collection.DeleteOne(
            Builders<Advertisement>.Filter.Eq(r => r.AdvertisementId, advertisementId));
        
        }
       
        
        // Opdaterer en eksisterende annonce i databasen
        public void UpdateAdvertisement(Advertisement ad)
        {
            // Erstat den eksisterende annonce med den nye annonce i samlingen
            collection.ReplaceOne(existingAd => existingAd.Id == ad.Id, ad);
        }



        // Tilføj metoden for at hente alle annoncer for en given bruger

        public List<Advertisement> GetAdvertisementsByUserName(string username)
        {
            // Assuming 'Advertisement' collection has an embedded 'User' object with a 'Username' field
            //var filter = Builders<Advertisement>.Filter.Eq("Username", username);
            var advertisements = collection.Find(ad => ad.User.Username.Equals(username, StringComparison.OrdinalIgnoreCase)).ToList();
            return advertisements;
        }
    }
}