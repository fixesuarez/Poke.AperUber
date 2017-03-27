using Poke.AperUber.Models;
using SQLite;

namespace Poke.AperUber.DAL
{
    public class DatabaseManager
    {
        private SQLiteConnection _connection;
        public FoodCategoryGateway FoodCategoryGateway;
        public ProductGateway ProductGateway;

        public DatabaseManager( string dbPath )
        {
            _connection = new SQLiteConnection( dbPath );
            _connection.DropTable<Product>();
            _connection.DropTable<FoodCategory>();
            _connection.CreateTable<FoodCategory>();
            _connection.CreateTable<Product>();
            FoodCategoryGateway = new FoodCategoryGateway( _connection );
            ProductGateway = new ProductGateway( _connection );
        }
    }
}
