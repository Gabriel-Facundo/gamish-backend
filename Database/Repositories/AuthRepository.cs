using Dapper;
using Database.DB;
using Models;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class AuthRepository
    {
        private readonly DbHandler _db;

        public AuthRepository(DbHandler db)
        {
            _db = db;
        }

        public async Task<LoginResult> Login(Login login)
        {
            LoginResult result = new();

            string sql = $"SELECT SENHA FROM USUARIOS WHERE NOME = '{login.Username}'";

            using(var conn = _db.Connection)
            {
                long? id = null;
                string password = await conn.QueryFirstOrDefaultAsync<string>(sql);

                if(password == login.Password)
                {
                    sql = $"SELECT ID FROM USUARIOS WHERE NOME = '{login.Username}'";
                    id = await conn.QueryFirstOrDefaultAsync<long>(sql);
                }

                result = new LoginResult
                {
                    Id = id,
                    Username = login.Username,
                    Status = password == login.Password ? "Login Autorizado" : "Login não autorizado"
                };
                return result;
            }
        }
    }
}
