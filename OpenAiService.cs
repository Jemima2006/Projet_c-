using System;
using System.Threading.Tasks;
using OpenAI_API;

class Program
{
    static async Task Main()
    {int choix;
        var api = new OpenAIAPI("1236f90585628a72521ce5a920281891");
                  
    }

    static async Task CorrigerTexte(OpenAIAPI api,string texte)
    {
        var chat = api.Chat.CreateConversation();
        chat.AppendUserInput($"Corrige ce texte sans changer son sens : {texte}");
        var response = await chat.GetResponseFromChatbotAsync();

        Console.WriteLine("Texte corrige : " + response.Text);
    }

    static async Task TraduireTexte(OpenAIAPI api,string phrase,int langue)
    {
        var chat = api.Chat.CreateConversation();
        chat.AppendUserInput($"Traduis ce texte en {langue} : {phrase}");
        var response = await chat.GetResponseFromChatbotAsync();

        Console.WriteLine("Traduction : " + response.Text);
    }

    static async Task GenererHTML(OpenAIAPI api,string monfichier)
    {
        var chat = api.Chat.CreateConversation();
        chat.AppendUserInput($"Genere un fichier html evec css inclus pour le theme : {monfichier}");
        var response = await chat.GetResponseFromChatbotAsync();

        Console.WriteLine("Fichier html :" + response.Text);
    }
}
