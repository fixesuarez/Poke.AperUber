using MvvmHelpers;
using Poke.AperUber.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace Poke.AperUber.DAL
{
    public class FoodCategoryGateway
    {
        SQLiteConnection _connection;

        public FoodCategoryGateway( SQLiteConnection connection )
        {
            _connection = connection;
        }

        public void InitiateCategories()
        {
            List<FoodCategory> categories = new List<FoodCategory>()
            {
                new FoodCategory { Name = "Saucissons", Cover = "saucisson.jpg" },
                new FoodCategory { Name = "Rillettes", Cover = "rillettes.jpg" },
                new FoodCategory { Name = "Pâtés", Cover = "pate.jpg" }
            };
            _connection.InsertAll( categories );
        }

        public ObservableRangeCollection<FoodCategory> GetAllCategories()
        {
            return new ObservableRangeCollection<FoodCategory>( _connection.Table<FoodCategory>().ToList() );
        }
    }
}
