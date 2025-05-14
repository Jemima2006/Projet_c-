using System;
using System.Threading.Tasks;
using OpenAI_API;

class Program
{
    static async Task Main()
    {
        var api = new OpenAIAPI("TA_CLE_API"); 
        string resultat = await openAiService.CorrigerTexteAsync(texte);
        Console.WriteLine("Texte corrigé :" + resultat);


        Console.WriteLine("Bonjour :) Que voulez-vous faire ?");
        Console.WriteLine("1 - Corriger un texte");
        Console.WriteLine("2 - Traduire un texte");
        Console.WriteLine("3 - Générer un fichier HTML");

        int choix = int.Parse(Console.ReadLine());

        if (choix == 1)
        {
            Console.WriteLine("Entrez le texte à corriger :");
            string texte = Console.ReadLine();
            await CorrigerTexte(api, texte);
            Console.WriteLine(" Texte corrigé");
        }
        else if (choix == 2)
        {
            Console.WriteLine("Entrez le texte à traduire :");
            string texte = Console.ReadLine();

            Console.WriteLine("Choisissez la langue de traduction :");
            Console.WriteLine("1 - Anglais UK");
            Console.WriteLine("2 - Anglais US");
            Console.WriteLine("3 - Allemand");
            Console.WriteLine("4 - Espagnol");

            int langueChoix = int.Parse(Console.ReadLine());

            switch (langue)
            {
                case 1:
                    langue = "anglais britannique";
                    break;
                case 2:
                    langue = "anglais américain";
                    break;
                case 3:
                    langue = "allemand";
                    break;
                case 4:
                    langue = "espagnol";
                    break;
                default:
                    Console.WriteLine("Langue non disponible");
                    return;
            }
            Console.WriteLine($"Traduction en {langue}")
            await TraduireTexte(api, texte, langue);
        }
        else if (choix == 3)
        {
            Console.WriteLine("Décris ton fichier HTML :");
            string monfichier = Console.ReadLine();
            await GenererHTML(api, monfichier);
            Console.WriteLine("Fichier HTML generer !");
        }
        else
        {
            Console.WriteLine("Choix invalide.");
        }
    }

} 