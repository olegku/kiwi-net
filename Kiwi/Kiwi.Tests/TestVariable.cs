﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kiwi.Tests
{
    public class TestVariable
    {
        // Test the variable modification methods.
        [Fact]
        public void test_variable_methods()
        {
            var v = new Variable("foo");

            Assert.Equal("foo", v.Name);
            Assert.Equal(0.0, v.Value);

            //    ctx = object()
            //    v.setContext(ctx)
            //    assert v.context() is ctx

            //    assert str(v) == "foo"
        }

        // Test the arithmetic operation on variables.
        [Fact]
        public void test_variable_arith_operators()
        {

            var v = new Variable("foo");
            var v2 = new Variable("bar");

            //    Term neg = -v;
            //    assert neg.variable() is v and neg.coefficient() == -1

            //    mul = v * 2;
            //    assert isinstance(mul, Term)
            //    assert mul.variable() is v and mul.coefficient() == 2

            //    with pytest.raises(TypeError):
            //        v * v2

            //    div = v / 2
            //    assert isinstance(div, Term)
            //    assert div.variable() is v and div.coefficient() == 0.5

            //    with pytest.raises(TypeError):
            //        v / v2

            //    add = v + 2;
            //    assert isinstance(add, Expression)
            //    assert add.constant() == 2
            //    terms = add.terms()
            //    assert (len(terms) == 1 and terms[0].variable() is v and
            //            terms[0].coefficient() == 1)

            //    add2 = v + v2;
            //    assert isinstance(add2, Expression)
            //    assert add2.constant() == 0
            //    terms = add2.terms()
            //    assert (len(terms) == 2 and
            //            terms[0].variable() is v and terms[0].coefficient() == 1 and
            //            terms[1].variable() is v2 and terms[1].coefficient() == 1)

            //    sub = v - 2;
            //    assert isinstance(sub, Expression)
            //    assert sub.constant() == -2
            //    terms = sub.terms()
            //    assert (len(terms) == 1 and terms[0].variable() is v and
            //            terms[0].coefficient() == 1)

            //    sub2 = v - v2;
            //    assert isinstance(sub2, Expression)
            //    assert sub2.constant() == 0
            //    terms = sub2.terms()
            //    assert (len(terms) == 2 and
            //            terms[0].variable() is v and terms[0].coefficient() == 1 and
            //            terms[1].variable() is v2 and terms[1].coefficient() == -1)
        }

        // Test using comparison on variables.
        [Fact]
        public void test_variable_rich_compare_operations()
        {
            var v = new Variable("foo");
            var v2 = new Variable("bar");

            //    for op, symbol in ((operator.le, "<="), (operator.eq, "=="),
            //                       (operator.ge, ">=")):
            //        c = op(v, v2 + 1)
            //        assert isinstance(c, Constraint)
            //        e = c.expression()
            //        t = e.terms()
            //        assert len(t) == 2
            //        if t[0].variable() is not v:
            //            t = (t[1], t[0])
            //        assert (t[0].variable() is v and t[0].coefficient() == 1 and
            //                t[1].variable() is v2 and t[1].coefficient() == -1)
            //        assert e.constant() == -1
            //        assert c.op() == symbol and c.strength() == strength.required

            //    for op in (operator.lt, operator.ne, operator.gt):
            //        with pytest.raises(TypeError):
            //            op(v, v2)
        }
    }
}