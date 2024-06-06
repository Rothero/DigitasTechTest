using Dapper;
using System.Data;

namespace DigitasTechTest.Infrastructure.Data
{
    public class AppDbService : IAppDbService
    {
        protected IDbConnection _connection;
        public AppDbService(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }

        public async Task<List<T>> GetAsync<T>(string command, object parms)
        {

            var result = (await _connection.QueryAsync<T>(command, parms)).ToList();
            return result;
        }

        public async Task<T> EditData<T>(string command, object parms)
        {

            var result = await _connection.ExecuteScalarAsync<T>(command, parms);
            return result;
        }

    }
}
