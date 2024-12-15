﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class StringCalculatorExpression
    {
        public double Calculate(string expression)
        {

            var tokens = expression.Split(' ');
            if (tokens.Length == 3)
                {
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


            var postfix = ConvertToPostfix(expression);
            return EvaluatePostfix(postfix);
        }

        public async Task<double> CalculateAsync(string expression)
        {
            return await Task.Run(() => Calculate(expression));
        }
        private List<string> ConvertToPostfix(string expression)
        {
            var output = new List<string>();
            var operators = new Stack<string>();
            var precedence = new Dictionary<string, int>
            {
                { "+", 1 },
                { "-", 1 },
                { "*", 2 },
                { "/", 2 }
            };
            var tokens = Tokenize(expression);
            foreach (var token in tokens)
            {
                if (double.TryParse(token, out _))
                {
                    output.Add(token);
                }
                else if (token == "(")
                {
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Pop();
                }
                else if (precedence.ContainsKey(token))
                {
                    while (operators.Count > 0 && precedence.ContainsKey(operators.Peek()) &&
                           precedence[operators.Peek()] >= precedence[token])
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Push(token);
                }
                else
                {
                    throw new InvalidOperationException($"Неизвестный токен: {token}");
                }
            }
            while (operators.Count > 0)
            {
                output.Add(operators.Pop());
            }
            return output;
        }
        private double EvaluatePostfix(List<string> postfix)
        {
            var stack = new Stack<double>();
            foreach (var token in postfix)
            {
                if (double.TryParse(token, out double number))
                {
                    stack.Push(number);
                }
                else
                {
                    var b = stack.Pop();
                    var a = stack.Pop();
                    stack.Push(token switch
                    {
                        "+" => a + b,
                        "-" => a - b,
                        "*" => a * b,
                        "/" => b != 0 ? a / b : throw new DivideByZeroException("Деление на ноль."),
                        _ => throw new InvalidOperationException($"Неизвестная операция: {token}")
                    });
                }
            }
            return stack.Pop();
        }
        private List<string> Tokenize(string expression)
        {
            var tokens = new List<string>();
            var currentToken = string.Empty;
            bool lastWasOperatorOrParenthesis = true; // Определяет, может ли `-` быть унарным

            foreach (var ch in expression)
            {
                if (char.IsWhiteSpace(ch)) continue;

                if (char.IsDigit(ch) || ch == '.')
                {
                    currentToken += ch;
                    lastWasOperatorOrParenthesis = false;
                }
                else if (ch == '-' && lastWasOperatorOrParenthesis)
                {
                    // Унарный минус: добавить в текущий токен
                    currentToken += ch;
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentToken))
                    {
                        tokens.Add(currentToken);
                        currentToken = string.Empty;
                    }

                    tokens.Add(ch.ToString());
                    lastWasOperatorOrParenthesis = ch == '(' || ch == '+' || ch == '-' || ch == '*' || ch == '/';
                }
            }

            if (!string.IsNullOrEmpty(currentToken))
            {
                tokens.Add(currentToken);
            }

            return tokens;
        }

    }
}