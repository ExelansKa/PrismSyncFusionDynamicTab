using PrismTabApp.Services.Interfaces;

namespace PrismTabApp.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
