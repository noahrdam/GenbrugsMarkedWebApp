using Core.Model;

namespace ServerAPI.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        public void CreateAccount(User user);
        public bool VerifyLogin(string username, string password);
    }
}
