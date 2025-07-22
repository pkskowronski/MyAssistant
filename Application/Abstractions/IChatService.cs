using OpenAI.Chat;

namespace Application.Abstractions
{
    public interface IChatService
    {
        List<ChatMessage> CreateChatHistory(string metaPrompt);
        Task<string> GetChatCompletionAsync(List<ChatMessage> chatHistory);
    }
}
