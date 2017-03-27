using MvvmHelpers;

namespace Poke.AperUber.Models
{
    public class ProductQuantity : ObservableObject
    {
        Product _product;
        int _quantity;
        double _subTotal;

        public ProductQuantity( Product product, int quantity )
        {
            _product = product;
            _quantity = quantity;

            _subTotal = 0;
        }

        public Product Product
        {
            get { return _product; }
            set { SetProperty( ref _product, value ); }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { SetProperty( ref _quantity, value ); }
        }
        public double SubTotal
        {
            get { return _subTotal; }
            set { SetProperty( ref _subTotal, value ); }
        }
    }
}
