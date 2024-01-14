using BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Models;
using OpenAI_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class BotAPIService : IBotAPIService
    {
        private readonly IConfiguration _configuration;
        public BotAPIService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<string>> GenerateContent(ChatGPT generateRequestModel)
        {
            var apiKey = _configuration.GetSection("AppSettings:CHATGPTKEY").Value;
            var apiModel = _configuration.GetSection("AppSettings:Model").Value;
            List<string> rq = new List<string>();
            string rs = "";
            OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));
            var completionRequest = new OpenAI_API.Completions.CompletionRequest()
            {
                Prompt = generateRequestModel.prompt,
                Model = apiModel,
                Temperature = 0.5,
                MaxTokens = 100,
                TopP = 1.0,
                FrequencyPenalty = 0.0,
                PresencePenalty = 0.0,
            };
            var result = await api.Completions.CreateCompletionAsync(completionRequest);
            foreach(var choice in result.Completions)
            {
                rs = choice.Text;
                rq.Add(choice.Text);
            }
            return rq;
        }
    }
}
