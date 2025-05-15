using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
 
public static class OpenAiservice
{
    static readonly string apiKey = "clé api";
    static readonly HttpClient client = new HttpClient();
 
    public static async Task Envoyer(string role, string message)
    {
        var contenu = new
        {
            model = "gpt-4o-mini",
            messages = new[]
            {
                new { role = "system", content = role },
                new { role = "user", content = message }
            }
        };
 
        var json = JsonSerializer.Serialize(contenu);
        var requete = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
        requete.Headers.Add("Authorization", "Bearer " + apiKey);
        requete.Content = new StringContent(json, Encoding.UTF8, "application/json");
 
        var reponse = await client.SendAsync(requete);
        var texte = await reponse.Content.ReadAsStringAsync();
 
        if (reponse.IsSuccessStatusCode)
        {
            using var doc = JsonDocument.Parse(texte);
            var reponseTexte = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
            Console.WriteLine(reponseTexte);
        }
        else
        {
            Console.WriteLine("Erreur : " + texte);
        }
    }
 
    public static Task Corriger(string texte)
    {
        return Envoyer("Tu corriges des textes sans changer leur sens.", "Corrige : " + texte);
    }
 
    public static Task Traduire(string texte, string langue)
    {
        return Envoyer("Tu es un traducteur.", "Traduis en " + langue + " : " + texte);
    }
 
    public static Task GenererHtml(string description)
    {
        return Envoyer("Tu génères du HTML.", "Génère une page HTML pour : " + description);
    }
}
 
 
 
 
 
 
