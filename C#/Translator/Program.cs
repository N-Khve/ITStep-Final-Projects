using System.Text;

namespace Translator
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Translator App ===");

            while (true)
            {
                try
                {
                    string fileName = SelectLanguagePair();

                    if (!File.Exists(fileName))
                    {
                        Console.WriteLine("Dictionary file not found.");
                    }

                    var dictionary = LoadDictionary(fileName);

                    Console.Write("Enter a word or short phrase: ");
                    string input = Console.ReadLine()?.Trim().ToLower();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Invalid input.");
                        continue;
                    }

                    if (dictionary.ContainsKey(input))
                    {
                        Console.WriteLine($"Translation: {dictionary[input]}");
                    }
                    else
                    {
                        Console.WriteLine("Translation not found.");
                        Console.Write("Do you want to add it? (y/n): ");
                        string choice = Console.ReadLine()?.ToLower();

                        if (choice == "y")
                        {
                            Console.Write("Enter translation: ");
                            string translation = Console.ReadLine()?.Trim();

                            if (string.IsNullOrWhiteSpace(translation))
                            {
                                Console.WriteLine("Invalid translation.");
                                continue;
                            }

                            dictionary[input] = translation;
                            SaveDictionary(fileName, dictionary);

                            Console.WriteLine("Translation added!");
                        }
                    }

                    Console.Write("\nContinue? (y/n): ");
                    if (Console.ReadLine()?.ToLower() != "y")
                        break;
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"File error: {ex.Message}");
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine($"Access denied: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Input error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }

        private static string SelectLanguagePair()
        {
            Console.WriteLine("\nSelect language pair:");
            Console.WriteLine("1. English → Russian");
            Console.WriteLine("2. English → Spanish");
            Console.WriteLine("3. Russian → English");
            Console.WriteLine("4. Russian → Spanish");
            Console.WriteLine("5. Spanish → English");
            Console.WriteLine("6. Spanish → Russian");

            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            return choice switch
            {
                "1" => @"../../../En-Ru.txt",
                "2" => @"../../../En-Es.txt",
                "3" => @"../../../Ru-En.txt",
                "4" => @"../../../Ru-Es.txt",
                "5" => @"../../../Es-En.txt",
                "6" => @"../../../Es-Ru.txt",
                _ => throw new ArgumentException("Invalid language pair selection.")
            };
        }

        private static Dictionary<string, string> LoadDictionary(string fileName)
        {
            var dict = new Dictionary<string, string>();

            try
            {
                foreach (var line in File.ReadAllLines(fileName))
                {
                    if (string.IsNullOrWhiteSpace(line) || !line.Contains("="))
                        continue;

                    var parts = line.Split('=');

                    if (parts.Length < 2)
                        continue;

                    dict[parts[0].Trim().ToLower()] = parts[1].Trim();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Dictionary file not found during loading.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return dict;
        }

        private static void SaveDictionary(string fileName, Dictionary<string, string> dict)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var pair in dict)
                    {
                        writer.WriteLine($"{pair.Key}={pair.Value}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied while saving: {ex.Message}");
            }
        }
    }
}