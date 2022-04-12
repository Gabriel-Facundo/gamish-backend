using Database.Repositories;

namespace gamish_backend.Services
{
    public class ServiceUoW
    {
        private RepositoryUoW _repository;

        private AuthService _authService;
        private UserService _userService;
        public ServiceUoW(RepositoryUoW repository)
        {
            _repository = repository;
        }

        public AuthService AuthService 
        {
            get { return _authService ??= new AuthService(_repository); }
        }

        public UserService UserService
        {
            get { return _userService ??= new UserService(_repository); }
        }
    }
}
