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

        public async Task<LoginCheck> CheckIfLoginExistes(string login)
        {
            LoginCheck loginCheck = new();
            bool LoginExists = await _repository.UserRepository.CheckIfLoginExistes(login);
            if (LoginExists) return loginCheck = new LoginCheck { Message = "Login já existe", Status = "Falha"};
            else return loginCheck = new LoginCheck { Message = "Login não existe", Status = "Ok" };
        }
    }
}
