using Poke.AperUber.Models;
using Poke.AperUber.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poke.AperUber.Views
{
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class ProductListView : ContentPage
    {
        ProductListViewModel _productListViewModel;

        public ProductListView( FoodCategories category )
        {
            InitializeComponent();
            BindingContext = _productListViewModel = new ProductListViewModel( category );

            listProducts.ItemsSource = _productListViewModel.Products;
            listProducts.ItemSelected += ( sender, e ) =>
            {
                ( (ListView) sender ).SelectedItem = null;
            };
        }

        public void OnQuantityChanged( object sender, EventArgs args )
        {
            Button buttonSender = (Button) sender;
            CommandParameter p = new CommandParameter
            {
                Operation = buttonSender.Text,
                NameProductToChange = buttonSender.ClassId
            };

            _productListViewModel.ChangeProductQuantity.Execute( p );
        }
        public class CommandParameter
        {
            public string Operation { get; set; }
            public string NameProductToChange { get; set; }
        }

        protected override void OnDisappearing()
        {
            Navigation.PopModalAsync();
        }
    }
}
