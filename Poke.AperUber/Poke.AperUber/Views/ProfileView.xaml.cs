using Poke.AperUber.Services;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poke.AperUber.Views
{
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class ProfileView : ContentPage
    {
        static readonly Regex emailRegex = new Regex( @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" );

        public ProfileView()
        {
            InitializeComponent();
            createAccountButton.Clicked += ( s, e ) =>
            {
                DependencyService.Get<IAccountService>().SaveCredentials( Email.Text, Password.Text );
            };
            Email.Unfocused += ( s, e ) =>
            {
                Entry userNameEntry = (Entry) s;
                if( !emailRegex.IsMatch( userNameEntry.Text ) )
                    userNameErrorMessage.IsVisible = true;
                else
                    userNameErrorMessage.IsVisible = false;
            };
        }
    }
}
