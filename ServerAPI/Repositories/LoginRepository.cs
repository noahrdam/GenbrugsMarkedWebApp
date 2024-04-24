using MongoDB.Bson;
using MongoDB.Driver;
using Core.Model;
using ServerAPI.Repositories.Interfaces;


namespace ServerAPI.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private IMongoClient client;
        private IMongoCollection<User> collection;

        public LoginRepository()
        {
            var mongoUri = "mongodb://localhost:27017";
            //var mongoUri = "mongodb+srv://noahrdam:3ppAuGCEF0ee9b6k@webshopdb.a704cgt.mongodb.net/";

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
            var collectionName = "User";

            collection = client.GetDatabase(dbName)
               .GetCollection<User>(collectionName);

        }

        public void CreateAccount(User user)
        {
            var filter = Builders<User>.Filter.Eq("Email", user.Email);
            if (collection.Find(filter).Any())
            {
                throw new Exception("This email is already used to create an account");
            }
            else
            {
                user.Id = ObjectId.GenerateNewId(); 
                collection.InsertOne(user);
            }
        }

        public bool VerifyLogin(string username, string password)
        {
            var filter = Builders<User>.Filter.Eq("Username", username) & Builders<User>.Filter.Eq("Password", password);
            var user = collection.Find(filter).SingleOrDefault();

            return user != null;
        }

        public User GetUser(string username)
        {
            var filter = Builders<User>.Filter.Eq("Username", username);
            return collection.Find(filter).SingleOrDefault();
        }
    }
}