using MvvmHelpers;
using System.Collections.Generic;
using System.Linq;

namespace Poke.AperUber.Models
{
    public class Order : ObservableObject
    {
        ObservableRangeCollection<ProductQuantity> _productsQuantity;
        bool _isEmpty = true;

        public Order()
        {
            ObservableRangeCollection<Product> allProducts = new ObservableRangeCollection<Product>( App.DatabaseManager.ProductGateway.GetAllProducts() );

            _productsQuantity = new ObservableRangeCollection<ProductQuantity>();
            foreach( Product product in allProducts )
            {
                _productsQuantity.Add( new ProductQuantity( product, 0 ) );
            }
        }

        #region Properties
        public ObservableRangeCollection<ProductQuantity> ProductsQuantity
        {
            get { return _productsQuantity; }
            set { SetProperty( ref _productsQuantity, value ); }
        }
        public bool IsEmpty
        {
            get
            {
                return _isEmpty;
            }
            set { SetProperty( ref _isEmpty, value, "IsEmpty" ); }
        }
        #endregion
    }
}
