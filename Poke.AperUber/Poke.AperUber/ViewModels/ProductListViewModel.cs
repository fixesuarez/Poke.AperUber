using MvvmHelpers;
using Poke.AperUber.Models;
using Poke.AperUber.Views;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Poke.AperUber.ViewModels
{
    public class ProductListViewModel : BaseViewModel
    {
        ObservableRangeCollection<ProductQuantity> _products;
        Command _changeProductQuantity;

        public ProductListViewModel( FoodCategories category )
        {
            _changeProductQuantity = new Command<ProductListView.CommandParameter>( ChangeQuantity );

            if( category == FoodCategories.SAUCISSONS )
            {
                Title = "Choix des Saucissons";
                IEnumerable<Product> saucissons = App.DatabaseManager.ProductGateway.GetAllSaucissons();
                _products = new ObservableRangeCollection<ProductQuantity>();
                foreach( Product saucisson in saucissons )
                {
                    _products.Add( new ProductQuantity( saucisson, 0 ) );
                }
            }
            else if( category == FoodCategories.RILLETTES )
            {
                Title = "Choix des rillettes";
                IEnumerable<Product> rillettes = App.DatabaseManager.ProductGateway.GetAllRillettes();
                _products = new ObservableRangeCollection<ProductQuantity>();
                foreach( Product rillette in rillettes)
                {
                    _products.Add( new ProductQuantity( rillette, 0 ) );
                }
            }
            else if( category == FoodCategories.PATE )
            {
                Title = "Choix des pâtés";
                IEnumerable<Product> pates = App.DatabaseManager.ProductGateway.GetAllPates();
                _products = new ObservableRangeCollection<ProductQuantity>();
                foreach( Product pate in pates )
                {
                    _products.Add( new ProductQuantity( pate, 0 ) );
                }
            }
        }

        #region Properties
        public ObservableRangeCollection<ProductQuantity> Products
        {
            get { return _products; }
        }
        public Command ChangeProductQuantity
        {
            get { return _changeProductQuantity; }
            private set { SetProperty( ref _changeProductQuantity, value, "ChangeProductQuantity" ); }
        }
        #endregion

        public void ChangeQuantity( ProductListView.CommandParameter productToChange )
        {
            ProductQuantity selectedProduct = Products.Where( p => p.Product.Name == productToChange.NameProductToChange ).First();

            if( productToChange.Operation == "+" )
            {
                if( App.Order.Contains( selectedProduct ) )
                    App.Order.Where( p => p.Product.Name == selectedProduct.Product.Name ).First().Quantity += 1;
                else
                {
                    App.Order.Add( selectedProduct );
                    selectedProduct.Quantity++;
                }
                selectedProduct.SubTotal = selectedProduct.Quantity * selectedProduct.Product.Price;
            }
            else
            {
                if( selectedProduct.Quantity > 0 )
                {
                    selectedProduct.Quantity -= 1;
                    selectedProduct.SubTotal = selectedProduct.Quantity * selectedProduct.Product.Price;
                    if( selectedProduct.Quantity == 0 )
                        App.Order.Remove( selectedProduct );
                }
            }
        }
    }
}
