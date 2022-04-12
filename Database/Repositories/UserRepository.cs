using Dapper;
using Database.DB;
using Models;
using Models.DTO_s.POST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class UserRepository
    {
        private readonly DbHandler _db;
        private readonly RepositoryUoW _repository;

        public UserRepository(DbHandler db, RepositoryUoW repository)
        {
            _db = db;
            _repository = repository;
        }

        public async Task<LoginResult> CreateUser(PostLogin login)
        {
            LoginResult loginResult = new LoginResult();
            using(var conn = _db.GetConnection())
            {
                if (!(await CheckIfLoginExistes(login.Username)))
                {
                    string sql = $@"INSERT INTO USUARIOS(NOME, SENHA, EMAIL) VALUES('{login.Username}','{login.Password}','{login.Email}')";
                    await conn.ExecuteAsync(sql);
                    loginResult = await  _repository.AuthRepository.Login(new Login { Username = login.Username, Password= login.Password});
                }
                else
                {
                    loginResult = new LoginResult
                    {
                        Id = null,
                        Username = login.Username,
                        Status = "Login já existe no banco de dados, favor passar um novo login!"
                    };
                }
                return loginResult;
            }
        }

        public async Task<bool> CheckIfLoginExistes(string login)
        {
            string sql = $"SELECT NOME FROM USUARIOS WHERE NOME = '{login}'";
            using (var conn = _db.GetConnection())
            {
                string userExists = await conn.QueryFirstOrDefaultAsync<string>(sql);
                if (string.IsNullOrEmpty(userExists)) return false;
                else return true;
            }
        }
    }
}
