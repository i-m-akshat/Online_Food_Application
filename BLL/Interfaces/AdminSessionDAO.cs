using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface AdminSessionDAO
    {
        Task<long> CreateSession(int id);
        Task<bool> EndSession(long id);
    }
}
