using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests
{
    public class ErrorTests
    {
        [Fact]
        public void Should_ExceptionInvalidExpression()
        {
            var calculator = new StringCalculatorExpression();
            Assert.Throws<InvalidOperationException>(() => calculator.Calculate("1 + + 2"));
        }
        [Fact]
        public void Should_ExceptionUnbalancedParentheses()
        {
            var calculator = new StringCalculatorExpression();
            Assert.Throws<InvalidOperationException>(() => calculator.Calculate("(3 + 4 * 5"));
        }
        [Fact]
        public void Should_ExceptionDivisionByZero()
        {
            var calculator = new StringCalculatorExpression();
            Assert.Throws<DivideByZeroException>(() => calculator.Calculate("10 / 0"));
        }
        [Fact]
        public void Should_ExceptionEmptyExpression()
        {
            var calculator = new StringCalculatorExpression();
            Assert.Throws<InvalidOperationException>(() => calculator.Calculate(""));
        }
        
        [Fact]
        public void Should_ExceptionUnsupportedOperation()
        {
            var calculator = new StringCalculatorExpression();
            Assert.Throws<InvalidOperationException>(() => calculator.Calculate("2 ^ 3"));
        }

    }
}