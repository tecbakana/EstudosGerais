using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string connectionUri = "mongodb+srv://marciovozes:su1974k1@cluster0.rzxvvtp.mongodb.net/?retryWrites=true&w=majority&appName=AtlasApp";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            // Set the ServerApi field of the settings object to Stable API version 1
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            var client = new MongoClient(settings);
            // Send a ping to confirm a successful connection
            try
            {
                var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}