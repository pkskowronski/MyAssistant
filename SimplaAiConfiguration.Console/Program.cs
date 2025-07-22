// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;
using OpenAI.Chat;
using ChatMessage = OpenAI.Chat.ChatMessage;

Console.WriteLine("Hello, World!");

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string model = "gpt-4.1";
string key = config["OpenAIKey"];

ChatClient chatClient =
    new OpenAIClient(key).GetChatClient(model);

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

while (true)
{
    // Get user prompt and add to chat history
    Console.WriteLine("Your prompt:");
    string? userPrompt = Console.ReadLine();
    chatHistory.Add(new UserChatMessage( userPrompt));

    // Stream the AI response and add to chat history
    Console.WriteLine("AI Response:");
    string response = "";
    //await foreach (ChatResponseUpdate item in
    //               chatClient.CompleteChatAsync(chatHistory))
    //{
    //    Console.Write(item.Text);
    //    response += item.Text;
    //}
    var chatCompletion = await chatClient.CompleteChatAsync(chatHistory);
    Console.Write(chatCompletion.Value.Content[0].Text);
    chatHistory.Add(new AssistantChatMessage(chatCompletion.Value.Content[0].Text));
    Console.WriteLine();
}