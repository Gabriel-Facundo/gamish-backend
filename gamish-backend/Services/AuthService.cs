using Database.Repositories;
using Models;
using System.Threading.Tasks;

namespace gamish_backend.Services
{
    public class AuthService
    {
        private readonly AuthRepository _auth;

        public AuthService(AuthRepository auth)
        {
            _auth = auth;
        }

        public async Task<string> Login(Login login)
        {
            bool validLogin = await _auth.Login(login);
            if (validLogin)
            {
                return "Logado!";
            }
            else
            {
                return "Não logado!";
            }
        }
    }
}
