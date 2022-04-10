using Database.Repositories;
using Models;
using System.Threading.Tasks;

namespace gamish_backend.Services
{
    public class AuthService
    {
        private readonly RepositoryUoW _repository;

        public AuthService(RepositoryUoW repository)
        {
            _repository = repository;
        }

        public async Task<LoginResult> Login(Login login)
        {
            bool validLogin = await _repository.AuthRepository.Login(login);

            LoginResult loginResult = new LoginResult
            {
                Username = login.Username,
                Status = validLogin ? "Login Autorizado" : "Login não autorizado"
            };

            return loginResult;
        }
    }
}
