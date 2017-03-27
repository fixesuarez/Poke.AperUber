namespace Poke.AperUber.Services
{
    public interface IAccountService
    {
        void SaveCredentials( string userName, string password );
        void DeleteCredentials();
        string UserName { get; }
        string Password { get; }
    }
}
