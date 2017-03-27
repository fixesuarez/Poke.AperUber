using MvvmHelpers;
using Poke.AperUber.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace Poke.AperUber.DAL
{
    public class ProductGateway
    {
        SQLiteConnection _connection;

        public ProductGateway( SQLiteConnection connection )
        {
            _connection = connection;
        }

        public void InitiateProducts()
        {
            // Ajout des saucissons
            FoodCategory saucissonFoodCategory = _connection.Get<FoodCategory>( "Saucissons" );
            List<Product> saucissons = new List<Product>
            {
                new Product { Name = "Rosette",      FoodCategoryName = saucissonFoodCategory.Name, Price = 1.5, Image = "rosette.jpg" },
                new Product { Name = "Fuet catalan", FoodCategoryName = saucissonFoodCategory.Name, Price = 2,   Image = "fuetCatalan.jpg" },
                new Product { Name = "Chorizo",      FoodCategoryName = saucissonFoodCategory.Name, Price = 2.5, Image = "chorizo.jpg" }
            };
            _connection.InsertAll( saucissons );

            // Ajout des rillettes
            FoodCategory rillettesFoodCategory = _connection.Get<FoodCategory>( "Rillettes" );
            List<Product> rillettes = new List<Product>
            {
                new Product { Name = "Rillettes de porc",   FoodCategoryName = rillettesFoodCategory.Name, Price = 1.5, Image = "rillettesPorc.jpg" },
                new Product { Name = "Rillettes de poulet", FoodCategoryName = rillettesFoodCategory.Name, Price = 2,   Image = "rillettesPoulet.jpg" },
                new Product { Name = "Rillettes de saumon", FoodCategoryName = rillettesFoodCategory.Name, Price = 2.5, Image = "rillettesSaumon.jpg" }
            };
            _connection.InsertAll( rillettes );

            // Ajout des pâtés
            FoodCategory pateFoodCategory = _connection.Get<FoodCategory>( "Pâtés" );
            List<Product> pates = new List<Product>
            {
                new Product { Name = "Pâté de campagne",    FoodCategoryName = pateFoodCategory.Name, Price = 2,   Image = "pateDeCampagne.jpg" },
                new Product { Name = "Mousse de canard",    FoodCategoryName = pateFoodCategory.Name, Price = 1.5, Image = "mousseDeCanard.jpg" },
                new Product { Name = "Terrine de lapin",    FoodCategoryName = pateFoodCategory.Name, Price = 2.5, Image = "terrineDeLapin.jpg" },
                new Product { Name = "Terrine de sanglier", FoodCategoryName = pateFoodCategory.Name, Price = 3,   Image = "terrineDeSanglier.jpg" },
            };
            _connection.InsertAll( pates );
        }

        public ObservableRangeCollection<Product> GetAllProducts()
        {
            return new ObservableRangeCollection<Product>( _connection.Table<Product>().ToList() );
        }
        public ObservableRangeCollection<Product> GetAllSaucissons()
        {
            return new ObservableRangeCollection<Product>( _connection.Table<Product>().Where( p => p.FoodCategoryName == "Saucissons" ).ToList() );
        }
        public ObservableRangeCollection<Product> GetAllRillettes()
        {
            return new ObservableRangeCollection<Product>( _connection.Table<Product>().Where( p => p.FoodCategoryName == "Rillettes" ).ToList() );
        }
        public ObservableRangeCollection<Product> GetAllPates()
        {
            return new ObservableRangeCollection<Product>( _connection.Table<Product>().Where( p => p.FoodCategoryName == "Pâtés" ).ToList() );
        }
    }
}
