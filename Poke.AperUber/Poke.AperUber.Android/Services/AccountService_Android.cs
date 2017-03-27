using Poke.AperUber.Droid.Services;
using Poke.AperUber.Services;
using System.Linq;
using Xamarin.Auth;
using Xamarin.Forms;
using System;

[assembly: Dependency( typeof( AccountService_Android ) )]
namespace Poke.AperUber.Droid.Services
{
    public class AccountService_Android : IAccountService
    {
        public AccountService_Android() {}

        public void SaveCredentials( string userName, string password )
        {
            if( !string.IsNullOrWhiteSpace( userName ) && !string.IsNullOrWhiteSpace( password ) )
            {
                Account account = new Account
                {
                    Username = userName
                };
                account.Properties.Add( "Password", password );
                AccountStore.Create( Forms.Context ).Save( account, App.AppName );
            }
        }
        public void DeleteCredentials()
        {
            var account = AccountStore.Create( Forms.Context ).FindAccountsForService( App.AppName ).FirstOrDefault();
            if( account != null )
            {
                AccountStore.Create( Forms.Context ).Delete( account, App.AppName );
            }
        }

        public string UserName
        {
            get
            {
                var account = AccountStore.Create( Forms.Context ).FindAccountsForService( App.AppName ).FirstOrDefault();
                //var t = AccountStore.Create( Forms.Context ).FindAccountsForService( App.AppName ).FirstOrDefault( p => p.Username == "test" );
                return ( account != null ) ? account.Username : null;
            }
        }
        public string Password
        {
            get
            {
                var account = AccountStore.Create( Forms.Context ).FindAccountsForService( App.AppName ).FirstOrDefault();
                return ( account != null ) ? account.Properties["Password"] : null;
            }
        }
        public bool AreValidIdentifiers( string userName, string password )
        {

        }
    }
}