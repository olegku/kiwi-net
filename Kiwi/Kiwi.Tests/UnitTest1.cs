using System;
using Xunit;

namespace Kiwi.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var x = new Var("x");
            var y = new Var("y");
            var expr = 3 * x + 4 * y + 5;

            Assert.Equal(2, expr.Ts.Length);
            Assert.Equal(3, expr.Ts[0].Coeff);
            Assert.Equal(4, expr.Ts[1].Coeff);
            Assert.Equal(5, expr.Const);
        }

    }
}
