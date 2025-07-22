using Microsoft.Extensions.AI;
using OpenAI;
using OpenAI.Chat;
using ChatMessage = OpenAI.Chat.ChatMessage;

namespace MyAssistant.Services
{
    public class ChatService : IChatService
    {
        public ChatService(IConfiguration configuration)
        {
            string key = configuration["OpenAIKey"];
            string model = "gpt-4.1";

            ChatClient chatClient =
                new OpenAIClient(key).GetChatClient(model);


        }

        private static List<ChatMessage> GetMetaPrompt()
        {
            var systemMessage = new SystemChatMessage("""
                                                          You are a friendly hiking enthusiast who helps people discover fun hikes in their area.
                                                          You introduce yourself when first saying hello.
                                                          When helping people out, you always ask them for this information
                                                          to inform the hiking recommendation you provide:
                                                      
                                                          1. The location where they would like to hike
                                                          2. What hiking intensity they are looking for
                                                      
                                                          You will then provide three suggestions for nearby hikes that vary in length
                                                          after you get that information. You will also share an interesting fact about
                                                          the local nature on the hikes when making a recommendation. At the end of your
                                                          response, ask if there is anything else you can help with.
                                                      """);

            List<ChatMessage> chatHistory = [systemMessage];
            return chatHistory;
        }

    }
}
