using Poke.AperUber.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poke.AperUber.Views
{
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class CategoriesView : ContentPage
    {
        public CategoriesView()
        {
            InitializeComponent();
            listFoodCategories.ItemsSource = App.DatabaseManager.FoodCategoryGateway.GetAllCategories();

            //NControl.Controls.ActionButton b = new NControl.Controls.ActionButton();
            //b.ButtonColor = Color.Red;
            //b.BackgroundColor = Color.Yellow;
            //b.HorizontalOptions = LayoutOptions.End;
            //b.HeightRequest = 20;
            //b.WidthRequest = 20;
            //b.

            //fullContent.Children.Add( b );
        }
        void OnTapGestureRecognizerTapped( object sender, EventArgs args )
        {
            var layoutSender = (StackLayout) sender;
            if( layoutSender.ClassId == "Saucissons" )
            {
                NavigationPage page = new NavigationPage( new ProductListView( FoodCategories.SAUCISSONS ) );
                Application.Current.MainPage.Navigation.PushModalAsync( page, true );
            }
            else if( layoutSender.ClassId == "Pâtés" )
            {
                NavigationPage page = new NavigationPage( new ProductListView( FoodCategories.PATE ) );
                Application.Current.MainPage.Navigation.PushModalAsync( page, true );
            }
            else if( layoutSender.ClassId == "Rillettes" )
            {
                NavigationPage page = new NavigationPage( new ProductListView( FoodCategories.RILLETTES ) );
                Application.Current.MainPage.Navigation.PushModalAsync( page, true );
            }
        }
    }
}
