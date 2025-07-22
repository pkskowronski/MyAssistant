using Application.Abstractions;
using Microsoft.Extensions.Configuration;
using OpenAI;
using OpenAI.Chat;
using ChatMessage = OpenAI.Chat.ChatMessage;

namespace Application.Services
{
    public class ChatService : IChatService
    {
        private readonly ChatClient _chatClient;
        public ChatService(IConfiguration configuration)
        {
            string key = configuration["OpenAIKey"];
            string model = "gpt-4.1";

            _chatClient =
                new OpenAIClient(key).GetChatClient(model);
        }

        public List<ChatMessage> CreateChatHistory(string metaPrompt)
        {
            var systemMessage = new SystemChatMessage(metaPrompt);
            List<ChatMessage> chatHistory = [systemMessage];
            return chatHistory;
        }

        public async Task<string> GetChatCompletionAsync(List<ChatMessage> chatHistory)
        {
            var chatCompletion = await _chatClient.CompleteChatAsync(chatHistory);
            return ReturnTextFromChatCompletion(chatCompletion.Value);
        }

        public static string ReturnTextFromChatCompletion(ChatCompletion chatCompletion)
        {
            return chatCompletion.Content.Count > 0 ? chatCompletion.Content[0].Text : string.Empty;
        }

    }
}
