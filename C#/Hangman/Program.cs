namespace Hangman
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("=== Hangman ===");

            List<string> words;

            try
            {
                words = LoadWords(@"../../../Words.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load words: {ex.Message}");
                return;
            }

            string word = words[Random.Shared.Next(words.Count)];

            var guessedLetters = new HashSet<char>();
            int attemptsLeft = 6;

            while (attemptsLeft > 0)
            {
                Console.WriteLine("\nWord: " + GetMaskedWord(word, guessedLetters));
                Console.WriteLine($"Attempts left: {attemptsLeft}");
                Console.WriteLine("Guessed letters: " + string.Join(", ", guessedLetters));

                Console.Write("Enter a letter (or type 'exit'): ");
                string? input = Console.ReadLine()?.ToLower().Trim();

                if (input == "exit")
                {
                    Console.WriteLine("Game ended.");
                    return;
                }

                try
                {
                    char guess = ValidateInput(input);

                    if (guessedLetters.Contains(guess))
                    {
                        Console.WriteLine("You already guessed that letter.");
                        continue;
                    }

                    guessedLetters.Add(guess);

                    if (!word.Contains(guess))
                    {
                        attemptsLeft--;
                        Console.WriteLine("Wrong guess!");
                    }
                    else
                    {
                        Console.WriteLine("Correct!");
                    }

                    if (IsWordGuessed(word, guessedLetters))
                    {
                        Console.WriteLine($"\nYou win! The word was: {word}");
                        return;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Input error: {ex.Message}");
                }
            }

            Console.WriteLine($"\nGame over! The word was: {word}");
        }

        private static List<string> LoadWords(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Word file not found.");

            var words = File.ReadAllLines(filePath)
                            .Select(w => w.Trim().ToLower())
                            .Where(w => !string.IsNullOrWhiteSpace(w))
                            .ToList();

            if (words.Count == 0)
                throw new Exception("Word list is empty.");

            return words;
        }

        private static char ValidateInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new FormatException("Input cannot be empty.");

            if (input.Length != 1 || !char.IsLetter(input[0]))
                throw new FormatException("Please enter a single letter.");

            return input[0];
        }

        private static string GetMaskedWord(string word, HashSet<char> guessedLetters)
        {
            return string.Join(" ", word.Select(c => guessedLetters.Contains(c) ? c : '_'));
        }

        private static bool IsWordGuessed(string word, HashSet<char> guessedLetters) => word.All(c => guessedLetters.Contains(c));
    }
}