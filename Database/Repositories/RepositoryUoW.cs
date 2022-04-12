using Database.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class RepositoryUoW
    {
        private DbHandler _db;

        private AuthRepository _authRepository;
        private UserRepository _userRepository;
        public RepositoryUoW(DbHandler db)
        {
            _db = db;
        }

        public AuthRepository AuthRepository
        {
            get { return _authRepository ??= new AuthRepository(_db); }
        }

        public UserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_db, this); }
        }
    }
}
