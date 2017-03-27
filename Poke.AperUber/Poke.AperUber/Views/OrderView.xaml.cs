using Poke.AperUber.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poke.AperUber.Views
{
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class OrderView : ContentPage
    {
        OrderViewModel _orderViewModel;

        public OrderView()
        {
            InitializeComponent();

            _orderViewModel = new OrderViewModel( App.Order );
            BindingContext = _orderViewModel;
            OrderedItems.ItemsSource = _orderViewModel.CurrentOrder;
        }
    }
}
