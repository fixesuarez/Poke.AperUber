using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Poke.AperUber.Droid
{
    [Activity( Label = "Poke.AperUber", Icon = "@drawable/icon", Theme = "@style/AperUberTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate( Bundle bundle )
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            

            base.OnCreate( bundle );

            string dbPath = FileAccessHelper.GetLocalFilePath( "AperUber.db3" );

            global::Xamarin.Forms.Forms.Init( this, bundle );
            LoadApplication( new App( dbPath ) );
        }
    }
}

