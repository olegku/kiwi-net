using System;
using Xunit;
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace Kiwi.Tests
{
    public class TestSymbolicOperators
    {
        [Fact]
        public void TestVarMultiply()
        {
            var x = new Var("x");

            Trm term = x * 3;
            Assert.Equal(term.Var, x);
            Assert.True(term.Coeff == 3);

            term = 4 * x;
            Assert.Equal(term.Var, x);
            Assert.Equal(4, term.Coeff);
        }

        [Fact]
        public void TestVarDivide()
        {
            var x = new Var("x");
            Trm term = x / 4;
            Assert.Equal(x, term.Var);
            Assert.Equal(0.25, term.Coeff);
        }

        [Fact]
        public void TestVarMinus()
        {
            var x = new Var("x");
            Trm term = -x;
            Assert.Equal(x, term.Var);
            Assert.Equal(-1.0, term.Coeff);
        }


        [Fact]
        public void TestTermMultiply()
        {
            var x = new Var("x");
            var t = new Trm(x, 2);

            Trm term = 3 * t;
            Assert.Equal(x, term.Var);
            Assert.Equal(6, term.Coeff);

            term = t * 4;
            Assert.Equal(x, term.Var);
            Assert.Equal(8, term.Coeff);
        }

        [Fact]
        public void TestTermDivide()
        {
            var x = new Var("x");
            var t = new Trm(x, 2);

            Trm term = t / 4;
            Assert.Equal(x, term.Var);
            Assert.Equal(0.5, term.Coeff);
        }

        [Fact]
        public void TestTermMinus()
        {
            var x = new Var("x");
            var t = new Trm(x, 2);

            Trm term = -t;
            Assert.Equal(x, term.Var);
            Assert.Equal(-2.0, term.Coeff);
        }

        [Fact]
        public void TestExpressionMultiply()
        {
            var x = new Var("x");
            var t = new Trm(x, 2);
            var e = new Expr(t, 1);

            Expr expr = e * 3;
            Assert.Single(expr.Terms);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(6, expr.Terms[0].Coeff);
            Assert.Equal(3, expr.Const);

            expr = 4 * e;
            Assert.Single(expr.Terms);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(8, expr.Terms[0].Coeff);
            Assert.Equal(4, expr.Const);
        }

        [Fact]
        public void TestExpressionDivide()
        {
            var x = new Var("x");
            var t = new Trm(x, 2);
            var e = new Expr(t, 1);

            Expr expr = e / 4;
            Assert.Single(expr.Terms);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(0.5, expr.Terms[0].Coeff);
            Assert.Equal(0.25, expr.Const);
        }

        [Fact]
        public void TestExpressionMinus()
        {
            var x = new Var("x");
            var t = new Trm(x, 2);
            var e = new Expr(t, 1);

            Expr expr = -e;
            Assert.Single(expr.Terms);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(-2.0, expr.Terms[0].Coeff);
            Assert.Equal(-1.0, expr.Const);
        }

        #region Var Add

        [Fact]
        public void TestVariableAddExpression()
        {
            var x = new Var("x");
            var y = new Var("y");
            var e = new Expr(new Trm(y, 3), 1);

            var expr = x + e;

            Assert.Equal(2, expr.Terms.Length);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(y, expr.Terms[1].Var);
            Assert.Equal(3, expr.Terms[1].Coeff);
        }

        [Fact]
        public void TestVariableAddTerm()
        {
            var x = new Var("x");
            var y = new Var("x");
            var ty = new Trm(y, 3);

            Expr expr = x + ty;
            Assert.Equal(2, expr.Terms.Length);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(y, expr.Terms[1].Var);
            Assert.Equal(3, expr.Terms[1].Coeff);

            expr = ty + x;
            Assert.Equal(2, expr.Terms.Length);
            Assert.Equal(y, expr.Terms[0].Var);
            Assert.Equal(3, expr.Terms[0].Coeff);
            Assert.Equal(x, expr.Terms[1].Var);
        }

        [Fact]
        public void TestVariableAddVariable()
        {
            var x = new Var("x");
            var y = new Var("x");

            Expr expr = x + y;
            Assert.Equal(2, expr.Terms.Length);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(y, expr.Terms[1].Var);
        }

        [Fact]
        public void TestVariableAddConstant()
        {
            var x = new Var("x");

            Expr expr = x + 1;
            Assert.Single(expr.Terms);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(1, expr.Const);

            expr = 1 + x;
            Assert.Single(expr.Terms);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(1, expr.Const);
        }

        #endregion

    }
}