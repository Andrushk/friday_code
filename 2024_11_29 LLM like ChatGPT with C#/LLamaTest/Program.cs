using LLama.Common;
using LLama;

//TODO укажите путь к вашей модели
string modelPath = @"C:\Temp\phi-2.Q4_K_M.gguf";
var parameters = new ModelParams(modelPath)
{
    ContextSize = 4096,
    GpuLayerCount = 5
};
using var model = LLamaWeights.LoadFromFile(parameters);
using var context = model.CreateContext(parameters);
var executor = new InteractiveExecutor(context);
var chatHistory = new ChatHistory();
chatHistory.AddMessage(AuthorRole.System, @"Transcript of a dialog, where the User interacts with an
Assistant named Bob. Bob's role is to be helpful, provide concise answers, and maintain a kind 
tone in all interactions. You may be asked to draft emails or messages, so please ensure that 
your responses are clear, professional, and considerate. Stick strictly to the information 
provided and do not add any additional commentary or details beyond the task at hand. 
When asked to make a list only response with the list no additional information. 
When given specific instructions, such as providing a list or a certain number of items, 
ensure you follow those instructions exactly. Remember, your goal is to assist in the best way 
possible while making communication effective and pleasant.");
chatHistory.AddMessage(AuthorRole.User, "Hello, Bob.");
chatHistory.AddMessage(AuthorRole.Assistant, "Hello. How may I help you today?");


ChatSession session = new(executor, chatHistory);
InferenceParams inferenceParams = new InferenceParams()
{
    MaxTokens = 1024,
    AntiPrompts = new List<string> { "User:" },
};
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("The chat session has started.\nUser: ");
Console.ForegroundColor = ConsoleColor.Green;
string userInput = Console.ReadLine() ?? "";

while (userInput != "exit")
{
    var cancelTokenSource = new CancellationTokenSource();
    var token = cancelTokenSource.Token;

    await foreach (
        var text
        in session.ChatAsync(
            new ChatHistory.Message(AuthorRole.User, userInput),
            inferenceParams, token))
    {
        if (token.IsCancellationRequested) break;

        // Чтобы прервать вывод текста (если ИИ несет) можно нажать F2
        if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.F2)
        {
            cancelTokenSource.Cancel();
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(text);

    }

    if (token.IsCancellationRequested)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Cancelled");
        Console.WriteLine();
    }

    Console.ForegroundColor = ConsoleColor.Green;
    userInput = Console.ReadLine() ?? "";
}