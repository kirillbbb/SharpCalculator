using System;
using Calculator;
namespace StringCalc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new StringCalculatorExpression();
            Console.WriteLine("Консольный калькулятор");
            Console.WriteLine("Для выхода из приложения введите 'exit' .");
            Console.WriteLine("---------------------------");
            while (true)
            {
                Console.Write("Введите выражение: ");
                var input = Console.ReadLine();
                if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                    break;
                try
                {
                    var result = calculator.Calculate(input);
                    Console.WriteLine($"Результат: {result}");
                    Console.WriteLine("---------------------------");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("---------------------------");
                }
                Console.WriteLine();
            }
           
        }
    }
}