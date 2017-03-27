using MvvmHelpers;
using Poke.AperUber.DAL;
using Poke.AperUber.Models;
using Poke.AperUber.ViewModels;

using Xamarin.Forms;

namespace Poke.AperUber
{
    public partial class App : Application
    {
        public static readonly string AppName = "AperUber";
        public static DatabaseManager DatabaseManager { get; private set; }
        public static ObservableRangeCollection<ProductQuantity> Order;

        public App( string dbPath )
        {
            InitializeComponent();

            DatabaseManager = new DatabaseManager( dbPath );
            DatabaseManager.FoodCategoryGateway.InitiateCategories();
            DatabaseManager.ProductGateway.InitiateProducts();

            Order = new ObservableRangeCollection<ProductQuantity>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
