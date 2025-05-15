using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("1 - Corriger un texte");
        Console.WriteLine("2 - Traduire un texte");
        Console.WriteLine("3 - Générer du HTML");

        string choix = Console.ReadLine();

        if (choix == "1")
        {
            Console.WriteLine("Texte à corriger :");
            string texte = Console.ReadLine();
            await OpenAiservice.Corriger(texte);
        }
        else if (choix == "2")
        {
            Console.WriteLine("Entrez le texte à traduire :");
            string texte = Console.ReadLine();

            Console.WriteLine("Choisissez la langue de traduction :");
            Console.WriteLine("1 - Anglais UK");
            Console.WriteLine("2 - Anglais US");
            Console.WriteLine("3 - Allemand");
            Console.WriteLine("4 - Espagnol");

            string langue = "";

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    langue = "anglais britannique";
                    break;
                case "2":
                    langue = "anglais américain";
                    break;
                case "3":
                    langue = "allemand";
                    break;
                case "4":
                    langue = "espagnol";
                    break;
                default:
                    Console.WriteLine("Langue non disponible");
                    return;
            }

            await OpenAiservice.Traduire(texte, langue);
        }
        else if (choix == "3")
        {
            Console.WriteLine("Description de la page HTML :");
            string description = Console.ReadLine();
            await OpenAiservice.GenererHtml(description);
        }
        else
        {
            Console.WriteLine("Choix invalide.");
        }
    }
}
