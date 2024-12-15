using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class StringCalculatorExpression
    {
        public double Calculate(string mathExpression)
            
        {
            var tokens = mathExpression.Split(' ');
            if (tokens.Length != 3)
            {
                throw new InvalidOperationException("Некорректное выражение.");
            }
            var number1 = double.Parse(tokens[0]);
            var number2 = double.Parse(tokens[2]);
            var operation = tokens[1];
            return operation switch
            {
                "+" => number1 + number2,
                "-" => number1 - number2,
                "*" => number1 * number2,
                "/" => number2 != 0 ? number1 / number2 : throw new DivideByZeroException("Деление на ноль."),
                _ => throw new InvalidOperationException($"Неизвестная операция: {operation}")
            };
        }
        public async Task<double> CalculateAsync(string expression)
        {
            return await Task.Run(() => Calculate(expression));
        }
    }
}