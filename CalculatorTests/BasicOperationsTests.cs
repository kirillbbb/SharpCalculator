using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;

namespace CalculatorTests
{
    public class BasicOperationsTests
{
    [Fact]
    public void Should_AdditionTwoNumbers()
    {

        var calculator = new StringCalculatorExpression();

        var result = calculator.Calculate("3 + 4");

        Assert.Equal(7, result);
    }
    [Fact]

    public void Should_SubtractTwoNumbers()
    {

        var calculator = new StringCalculatorExpression();

        var result = calculator.Calculate("6 - 5");

        Assert.Equal(1, result);
    }
    [Fact]
    public void Should_MultiplyTwoNumbers()
    {

        var calculator = new StringCalculatorExpression();

        var result = calculator.Calculate("7 * 4");

        Assert.Equal(28, result);
    }
    [Fact]
    public void Should_DivideTwoNumbers()
    {

        var calculator = new StringCalculatorExpression();

        var result = calculator.Calculate("9 / 3");

        Assert.Equal(3, result);
    }
    [Fact]
    public async Task Should_ExceptionDividingByZero()
    {
        var calculator = new StringCalculatorExpression();
        await Assert.ThrowsAsync<DivideByZeroException>(async () => await calculator.CalculateAsync("10 / 0"));
    }
}
}