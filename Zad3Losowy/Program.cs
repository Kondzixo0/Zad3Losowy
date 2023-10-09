using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Linq;

namespace GenerateCSVUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = @"C:\test\";
            string fileName = $"users-{DateTime.Now:yyyyMMddHHmmss}.csv";
            string filePath = Path.Combine(outputPath, fileName);

            // Tworzenie pliku CSV
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // Nagłówki kolumn
                writer.WriteLine("LP,Imię,Nazwisko,Rok urodzenia");

                // Generator danych dla 100 użytkowników
                Random random = new Random();
                for (int i = 1; i <= 100; i++)
                {
                    string imie = WylosujImie(random);
                    string nazwisko = WylosujNazwisko(random);
                    int rokUrodzenia = random.Next(1990, 2001);

                    // Zapis danych do pliku CSV
                    writer.WriteLine($"{i},{imie},{nazwisko},{rokUrodzenia}");
                }
            }

            Console.WriteLine($"Plik CSV został wygenerowany i zapisany w: {filePath}");
        }

        // Tablice z dostępnymi imionami i nazwiskami
        static string[] imiona = { "Kasia", "Basia", "Zosia", "Ania" };
        static string[] nazwiska = { "Nowak", "Kowalska" };

        // Funkcja losująca imię
        static string WylosujImie(Random random)
        {
            return imiona[random.Next(imiona.Length)];
        }

        // Funkcja losująca nazwisko
        static string WylosujNazwisko(Random random)
        {
            return nazwiska[random.Next(nazwiska.Length)];
        }
    }
}
