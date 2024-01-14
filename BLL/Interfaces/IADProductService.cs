using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BLL.Interfaces
{
    public interface IADProductService
    {
        Task<ChatGptResponseModel> GenerateAdContent(CustomerRequestModel GenerateRequestModel);
    }
}
