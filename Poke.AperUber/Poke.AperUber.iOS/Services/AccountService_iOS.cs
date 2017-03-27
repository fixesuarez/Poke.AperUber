using Poke.AperUber.iOS.Services;
using Poke.AperUber.Services;
using System.Linq;
using Xamarin.Auth;
using Xamarin.Forms;

[assembly: Dependency( typeof( AccountService_iOS ) )]
namespace Poke.AperUber.iOS.Services
{
    public class AccountService_iOS : IAccountService
    {
        public void SaveCredentials( string userName, string password )
        {
            if( !string.IsNullOrWhiteSpace( userName ) && !string.IsNullOrWhiteSpace( password ) )
            {
                Account account = new Account
                {
                    Username = userName
                };
                account.Properties.Add( "Password", password );
                AccountStore.Create().Save( account, App.AppName );
            }
        }

        public string UserName
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService( App.AppName ).FirstOrDefault();
                return ( account != null ) ? account.Username : null;
            }
        }

        public string Password
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService( App.AppName ).FirstOrDefault();
                return ( account != null ) ? account.Properties["Password"] : null;
            }
        }

        public void DeleteCredentials()
        {
            var account = AccountStore.Create().FindAccountsForService( App.AppName ).FirstOrDefault();
            if( account != null )
            {
                AccountStore.Create().Delete( account, App.AppName );
            }
        }
    }
}
