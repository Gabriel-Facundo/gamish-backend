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

        public async Task<bool> Login(Login login)
        {
            string sql = $"SELECT SENHA FROM USUARIOS WHERE NOME = '{login.UserName}'";
            using(var conn = _db.Connection)
            {
                string password = await conn.QueryFirstOrDefaultAsync<string>(sql);
                if(password == login.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
