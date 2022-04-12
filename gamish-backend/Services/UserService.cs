using Database.Repositories;
using Models;
using Models.DTO_s.POST;
using System.Threading.Tasks;

namespace gamish_backend.Services
{
    public class UserService
    {
        private readonly RepositoryUoW _repository;
        public UserService(RepositoryUoW repository)
        {
            _repository = repository;
        }

        public async Task<LoginResult> CreateLogin(PostLogin login)
        {
            LoginResult loginResult = await _repository.UserRepository.CreateUser(login);
            return loginResult;
        }

        public async Task<string> CheckIfLoginExistes(string login)
        {
            bool LoginExists = await _repository.UserRepository.CheckIfLoginExistes(login);
            if (LoginExists) return "Login já existe";
            else return "Login não existe";
        }
    }
}
