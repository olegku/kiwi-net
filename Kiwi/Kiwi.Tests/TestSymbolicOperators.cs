using System;
using Xunit;
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace Kiwi.Tests
{
    public class TestSymbolicOperators
    {
        [Fact]
        public void VariableTermExpressionConstructors()
        {
            var x = new Var("x");
            Assert.Equal("x", x.Name);

            var t = new Trm(x, 2);
            Assert.Equal(x, t.Var);
            Assert.Equal(2, t.Coeff);

            var e = new Expr(t, 10);
            Assert.Single(e.Terms, t);
            Assert.Equal(10, e.Const);
        }


        [Fact]
        public void VariableMultiplyConstant()
        {
            var x = new Var("x");

            Trm term = x * 3;

            Assert.Equal(term.Var, x);
            Assert.True(term.Coeff == 3);
        }

        [Fact]
        public void ConstantMultiplyVariable()
        {
            var x = new Var("x");

            Trm term = 4 * x;

            Assert.Equal(term.Var, x);
            Assert.Equal(4, term.Coeff);
        }

        [Fact]
        public void VariableDivideConstant()
        {
            var x = new Var("x");

            Trm term = x / 4;

            Assert.Equal(x, term.Var);
            Assert.Equal(0.25, term.Coeff);
        }

        [Fact]
        public void VariableMinus()
        {
            var x = new Var("x");

            Trm term = -x;

            Assert.Equal(x, term.Var);
            Assert.Equal(-1.0, term.Coeff);
        }


        [Fact]
        public void TermMultiplyConstant()
        {
            var x = new Var("x");
            var t = new Trm(x, 2);

            Trm term = 3 * t;

            Assert.Equal(x, term.Var);
            Assert.Equal(6, term.Coeff);
        }

        [Fact]
        public void ConstantMultiplyTerm()
        {
            var x = new Var("x");
            var t = new Trm(x, 2);

            Trm term = t * 4;

            Assert.Equal(x, term.Var);
            Assert.Equal(8, term.Coeff);
        }

        [Fact]
        public void TermDivideConstant()
        {
            var x = new Var("x");
            var t = new Trm(x, 2);

            Trm term = t / 4;

            Assert.Equal(x, term.Var);
            Assert.Equal(0.5, term.Coeff);
        }

        [Fact]
        public void TermMinus()
        {
            var x = new Var("x");
            var t = new Trm(x, 2);

            Trm term = -t;

            Assert.Equal(x, term.Var);
            Assert.Equal(-2.0, term.Coeff);
        }

        [Fact]
        public void ExpressionMultiplyConstant()
        {
            var x = new Var("x");
            var t = new Trm(x, 2);
            var e = new Expr(t, 1);

            Expr expr = e * 3;

            Assert.Single(expr.Terms);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(6, expr.Terms[0].Coeff);
            Assert.Equal(3, expr.Const);
        }

        [Fact]
        public void ConstantMultiplyExpression()
        {
            var x = new Var("x");
            var t = new Trm(x, 2);
            var e = new Expr(t, 1);

            Expr expr = 4 * e;

            Assert.Single(expr.Terms);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(8, expr.Terms[0].Coeff);
            Assert.Equal(4, expr.Const);
        }

        [Fact]
        public void ExpressionDivideConstant()
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
        public void ExpressionMinus()
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


        #region Variable +,- operators
        
        [Fact]
        public void VariableAddExpression()
        {
            var x = new Var("x");
            var y = new Var("y");
            var t = new Trm(y, 3);
            var e = new Expr(t, 10);

            var expr = x + e;

            Assert.Collection(expr.Terms,
                first => Assert.Equal(x, first.Var),
                second => Assert.Equal(t, second));
            Assert.Equal(10, expr.Const);
        }

        [Fact]
        public void VariableSubtactExpression()
        {
            var x = new Var("x");
            var y = new Var("y");
            var t = new Trm(y, 3);
            var e = new Expr(t, 10);

            var expr = x - e;

            Assert.Collection(expr.Terms,
                first => Assert.Equal(x, first.Var),
                second =>
                {
                    //TODO: implement Equals for Var,Trm,Expr classes: Assert.Equal(-t, second);
                    Assert.Equal(y, second.Var);
                    Assert.Equal(-3, second.Coeff);
                });
            Assert.Equal(-10, expr.Const);
        }


        [Fact]
        public void VariableAddTerm()
        {
            var x = new Var("x");
            var y = new Var("x");

            Expr expr = x + new Trm(y, 3);

            Assert.Collection(expr.Terms,
                first => Assert.Equal(x, first.Var),
                second =>
                {
                    Assert.Equal(y, second.Var);
                    Assert.Equal(3, second.Coeff);
                });
        }

        [Fact]
        public void VariableSubtractTerm()
        {
            var x = new Var("x");
            var y = new Var("x");

            Expr expr = x - new Trm(y, 3);

            Assert.Collection(expr.Terms,
                first =>
                {
                    Assert.Equal(x, first.Var);
                },
                second =>
                {
                    Assert.Equal(y, second.Var);
                    Assert.Equal(-3, second.Coeff);
                }
            );
        }


        [Fact]
        public void VariableAddVariable()
        {
            var x = new Var("x");
            var y = new Var("y");

            Expr expr = x + y;

            Assert.Collection(expr.Terms,
                first => Assert.Equal(x, first.Var),
                second => Assert.Equal(y, second.Var));
        }

        [Fact]
        public void VariableSubtractVariable()
        {
            var x = new Var("x");
            var y = new Var("x");

            Expr expr = x - y;

            Assert.Collection(expr.Terms,
                first => Assert.Equal(x, first.Var),
                second =>
                {
                    Assert.Equal(y, second.Var);
                    Assert.Equal(-1, second.Coeff);
                });
        }


        [Fact]
        public void VariableAddConstant()
        {
            var x = new Var("x");

            Expr expr = x + 10;

            Assert.Single(expr.Terms);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(10, expr.Const);
        }

        [Fact]
        public void VariableSubtractConstant()
        {
            var x = new Var("x");

            Expr expr = x - 10;

            Assert.Single(expr.Terms);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(-10, expr.Const);
        }


        [Fact]
        public void ConstantAddVariable()
        {
            var x = new Var("x");

            Expr expr = 10 + x;

            Assert.Single(expr.Terms);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(10, expr.Const);
        }

        [Fact]
        public void ConstantSubtractVariable()
        {
            var x = new Var("x");

            Expr expr = 10 - x;

            Assert.Single(expr.Terms);
            Assert.Equal(x, expr.Terms[0].Var);
            Assert.Equal(10, expr.Const);
        }
        
        #endregion
    }
}