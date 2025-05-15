using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
 
public static class OpenAiservice
{
    private static readonly string apiKey = "";
    private static readonly HttpClient client = new HttpClient();
 
    private static async Task Envoyer(string instruction, string message)
    {
        var data = new
        {
            model = "gpt-4o",
            messages = new[]
            {
                new { role = "system", content = instruction },
                new { role = "user", content = message }
            }
        };
 
        string json = JsonSerializer.Serialize(data);
 
        var requete = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
        requete.Headers.Add("Authorization", "Bearer " + apiKey);
        requete.Content = new StringContent(json, Encoding.UTF8, "application/json");
 
        HttpResponseMessage reponse = await client.SendAsync(requete);
        string texte = await reponse.Content.ReadAsStringAsync();
 
        if (reponse.IsSuccessStatusCode)
        {
            JsonDocument doc = JsonDocument.Parse(texte);
            string contenu = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
            Console.WriteLine("\nRéponse de l'IA :\n");
            Console.WriteLine(contenu);
        }
        else
        {
            Console.WriteLine("\nErreur : " + texte);
        }
    }
 
    public static Task Corriger(string texte)
    {
        return Envoyer("Tu corriges des fautes sans changer le sens.", "Corrige : " + texte);
    }
 
    public static Task Traduire(string texte, string langue)
    {
        return Envoyer("Tu es un traducteur professionnel.", $"Traduis ce texte en {langue} : {texte}");
    }
 
    public static Task GenererHtml(string description)
    {
        return Envoyer("Tu génères une page HTML simple avec CSS intégré.", $"Crée une page HTML sur : {description}");
    }
}
 
 
 
