using System;
using System.Collections.Specialized;
using MvvmHelpers;
using Poke.AperUber.Models;

namespace Poke.AperUber.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        //public Order _currentOrder;
        ObservableRangeCollection<ProductQuantity> _currentOrder;
        bool _isEmpty;

        public OrderViewModel( ObservableRangeCollection<ProductQuantity> currentOrder )
        {
            _currentOrder = currentOrder;
            _currentOrder.CollectionChanged += OnCollectionChanged;
            _isEmpty = ( _currentOrder.Count == 0 );
            Title = "Panier";
        }

        private void OnCollectionChanged( object sender, NotifyCollectionChangedEventArgs e )
        {
            if( _currentOrder.Count == 0 )
                IsEmpty = true;
            else
                IsEmpty = false;
        }

        public ObservableRangeCollection<ProductQuantity> CurrentOrder
        {
            get { return _currentOrder; }
            set { SetProperty( ref _currentOrder, value, "CurrentOrder" ); }
        }
        public bool IsEmpty
        {
            get { return _isEmpty; }
            set { SetProperty( ref _isEmpty, value, "IsEmpty" ); }
        }
    }    
}
