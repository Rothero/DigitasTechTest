using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitasTechTest.Infrastructure.Data
{
    public interface IAppDbService
    {
        Task<List<T>> GetAsync<T>(string command, object parms);
        Task<T> EditData<T>(string command, object parms);
    }
}
