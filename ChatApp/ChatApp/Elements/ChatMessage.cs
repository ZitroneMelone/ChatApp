using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Elements
{
    internal class ChatMessage
    {


        public String User { get; set; }
        public String Message {  get; set; }

        public ChatMessage(string user, string message)
        {
            User = user;
            Message = message;
            Console.WriteLine(message);
        }
    }
}
