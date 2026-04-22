namespace Calculator
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("=== Simple Calculator ===");

            while (true)
            {
                try
                {
                    Console.WriteLine("\nType 'exit' at any time to quit.\n");

                    double num1 = ReadNumber("Enter first number: ");
                    string operation = ReadOperation("Enter operation (+, -, *, /): ");
                    double num2 = ReadNumber("Enter second number: ");

                    double result = Calculate(num1, num2, operation);

                    Console.WriteLine($"Result: {result}");
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Input error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }

        private static double ReadNumber(string prompt)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.Trim();

            if (input?.ToLower() == "exit")
                throw new OperationCanceledException();

            if (!double.TryParse(input, out double number))
                throw new FormatException("Invalid number entered.");

            return number;
        }

        private static string ReadOperation(string prompt)
        {
            Console.Write(prompt);
            string? op = Console.ReadLine()?.Trim();

            if (op?.ToLower() == "exit")
                throw new OperationCanceledException();

            if (!IsValidOperation(op))
                throw new FormatException("Invalid operation. Use +, -, *, or /.");

            return op!;
        }

        private static bool IsValidOperation(string? op)
        {
            return op is "+" or "-" or "*" or "/";
        }

        private static double Calculate(double num1, double num2, string operation)
        {
            return operation switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "*" => num1 * num2,
                "/" => num2 != 0
                    ? num1 / num2
                    : throw new DivideByZeroException("Cannot divide by zero."),
                _ => throw new InvalidOperationException("Invalid operation.")
            };
        }
    }
}