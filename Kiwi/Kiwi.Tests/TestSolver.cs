using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kiwi.Tests
{
    public class TestSolver
    {
        [Fact]
        public void test_solver_creation()
        {
            //    """Test initializing a solver.

            //    """
            //    s = Solver()
            //    assert isinstance(s, Solver)

            //    with pytest.raises(TypeError):
            //        Solver(Variable())
        }

        [Fact]
        public void test_managing_edit_variable()
        {
            //    """Test adding/removing edit variables.

            //    """
            //    s = Solver()
            //    v1 = Variable("foo")
            //    v2 = Variable("bar")

            //    with pytest.raises(TypeError):
            //        s.hasEditVariable(object())
            //    with pytest.raises(TypeError):
            //        s.addEditVariable(object(), "weak")
            //    with pytest.raises(TypeError):
            //        s.removeEditVariable(object())
            //    with pytest.raises(TypeError):
            //        s.suggestValue(object(), 10)

            //    assert not s.hasEditVariable(v1)
            //    s.addEditVariable(v1, "weak")
            //    assert s.hasEditVariable(v1)
            //    with pytest.raises(DuplicateEditVariable):
            //        s.addEditVariable(v1, "medium")
            //    with pytest.raises(UnknownEditVariable):
            //        s.removeEditVariable(v2)
            //    s.removeEditVariable(v1)
            //    assert not s.hasEditVariable(v1)

            //    with pytest.raises(BadRequiredStrength):
            //        s.addEditVariable(v1, "required")

            //    s.addEditVariable(v2, "strong")
            //    assert s.hasEditVariable(v2)
            //    with pytest.raises(UnknownEditVariable):
            //        s.suggestValue(v1, 10)

            //    s.reset()
            //    assert not s.hasEditVariable(v2)
                    }

                    [Fact]
                    public void test_managing_constraints()
                    {
            //    """Test adding/removing constraints.

            //    """
            //    s = Solver()
            //    v = Variable("foo")
            //    c1 = v >= 1
            //    c2 = v <= 0

            //    with pytest.raises(TypeError):
            //        s.hasConstraint(object())
            //    with pytest.raises(TypeError):
            //        s.addConstraint(object())
            //    with pytest.raises(TypeError):
            //        s.removeConstraint(object())

            //    assert not s.hasConstraint(c1)
            //    s.addConstraint(c1)
            //    assert s.hasConstraint(c1)
            //    with pytest.raises(DuplicateConstraint):
            //        s.addConstraint(c1)
            //    with pytest.raises(UnknownConstraint):
            //        s.removeConstraint(c2)
            //    with pytest.raises(UnsatisfiableConstraint):
            //        s.addConstraint(c2)
            //    s.removeConstraint(c1)
            //    assert not s.hasConstraint(c1)

            //    s.addConstraint(c2)
            //    assert s.hasConstraint(c2)
            //    s.reset()
            //    assert not s.hasConstraint(c2)
        }

        [Fact]
        public void test_solving_under_constrained_system()
        {
            // Test solving an under constrained system.
            var s = new Solver();
            var v = new Variable("foo");
            var c = 2 * v + 1 >= 0;
            s.AddEditVariable(v, Strength.Weak);
            s.AddConstraint(c);
            s.SuggestValue(v, 10);
            s.UpdateVariables();

            Assert.Equal(21, c.Expression.Value);
            Assert.Equal(20, c.Expression.Terms[0].Value);
            Assert.Equal(10, c.Expression.Terms[0].Variable.Value);
        }

        [Fact]
        public void test_solving_with_strength()
        {
            //    """Test solving a system with unstatisfiable non-required constraint.

            //    """
            //    v1 = Variable("foo")
            //    v2 = Variable("bar")
            //    s = Solver()

            //    s.addConstraint(v1 + v2 == 0)
            //    s.addConstraint(v1 == 10)
            //    s.addConstraint((v2 >= 0) | "weak")
            //    s.updateVariables()
            //    assert v1.value() == 10 and v2.value() == -10

            //    s.reset()

            //    s.addConstraint(v1 + v2 == 0)
            //    s.addConstraint((v1 >= 10) | "medium")
            //    s.addConstraint((v2 == 2) | "strong")
            //    s.updateVariables()
            //    assert v1.value() == -2 and v2.value() == 2
        }
    }
}
