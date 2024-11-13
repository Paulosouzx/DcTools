using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace csharpbot;

public class DcTool
{
    public static void Banner()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"                                ██████╗ ██████╗    ████████╗██████╗ ██████╗██╗    ███████╗");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"                                ██╔══████╔════╝    ╚══██╔══██╔═══████╔═══████║    ██╔════╝");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(@"                                ██║  ████║            ██║  ██║   ████║   ████║    ███████╗");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(@"                                ██║  ████║            ██║  ██║   ████║   ████║    ╚════██║");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"                                ██████╔╚██████╗       ██║  ╚██████╔╚██████╔██████████████║");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"                                ╚═════╝ ╚═════╝       ╚═╝   ╚═════╝ ╚═════╝╚══════╚══════╝");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"                                                                                      DcTool - Paulo Jr");
        
        Console.ResetColor();

    }

    public static async Task<string> Menu()
    {
        Console.WriteLine("1- Send a WebHook Message");
        int opt = int.Parse(Console.ReadLine());

        switch (opt)
        {
            case 1:
                 await WebHookMessage();
                 return "Enviado";
            
            default:
                return "Nao existe essa opcao";
        }
    }

    public static async Task WebHookMessage()
    {
        Console.Clear();
        Console.WriteLine("WebHook URL: ");
        string url = Console.ReadLine();
        
        Console.WriteLine("WebHook Message: ");
        string message = Console.ReadLine();

        string json = $"{{\"content\": \"{message}\"}}";

        using (HttpClient client = new HttpClient())
        {
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            client.PostAsync(url, content).Wait();
        }
    }
}