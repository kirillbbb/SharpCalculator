
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
namespace CalculatorTests
{
    public class PriorityOperationsTests
    {
        [Fact]
        public void Should_PriorityOfOperations()
        {
            var calculator = new StringCalculatorExpression();

            var result = calculator.Calculate("3 + 4 * 5");
            Assert.Equal(23, result);
        }
        [Fact]
        public void Should_PriorityOfDivision()
        {
            var calculator = new StringCalculatorExpression();

            var result = calculator.Calculate("7 - 6 / 3");
            Assert.Equal(5, result);
        }
        [Fact]
        public void Should_MultipleOperations()
        {
            var calculator = new StringCalculatorExpression();

            var result = calculator.Calculate("3 + 4 * 5 - 2 / 4");
            Assert.Equal(22.5, result);
        }
        [Fact]
        public void Should_CalculateWithParentheses()
        {
            var calculator = new StringCalculatorExpression();

            var result = calculator.Calculate("(4 + 5) * 3");
            Assert.Equal(27, result);
        }
        [Fact]
        public void Should_CalculateWithMultiParentheses()
        {
            var calculator = new StringCalculatorExpression();

            var result = calculator.Calculate("4 * (2 + (3 - 1))");
            Assert.Equal(16, result);
        }
    }
}