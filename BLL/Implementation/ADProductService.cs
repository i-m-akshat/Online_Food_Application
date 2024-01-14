using BLL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class ADProductService : IADProductService
    {
        private readonly IBotAPIService _botAPIService;
        public ADProductService(IBotAPIService botAPIService)
        {
            _botAPIService = botAPIService;
        }
        public async Task<ChatGptResponseModel> GenerateAdContent(CustomerRequestModel GenerateRequestModel)
        {
            if (string.IsNullOrEmpty(GenerateRequestModel.Message))
            {
                return new ChatGptResponseModel
                {
                    Success = false,
                    response = null
                };

            }
            var userMessage = new ChatGPT
            {
                prompt = GenerateRequestModel.Message
            };
            var generateRequest = await _botAPIService.GenerateContent(userMessage);
            if (generateRequest.Count == 0)
            {
                return new ChatGptResponseModel
                {
                    Success = false,
                    response = null
                };
            }
            return new ChatGptResponseModel { Success = true, response = generateRequest };
            
        }
    }
}
