using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBotAPIService
    {
        Task<List<string>> GenerateContent(ChatGPT generateRequestModel);
    }
}
