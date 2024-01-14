using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ChatGPT
    {
        public string prompt { get; set; }
    }
    public class CustomerRequestModel
    {
        public string Message { get; set; }
    }
    public class ChatGptResponseModel
    {
        public List<string> response { get; set; }
        public bool Success { get; set; }
    }
}
