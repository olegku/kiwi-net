using System.Collections.Generic;
using System.Linq;

namespace Kiwi
{
    public enum RelationalOperator
    {
        OP_LE,
        OP_GE,
        OP_EQ
    }

    public class Constraint
    {
        public Constraint(Expression expr, RelationalOperator op, double strength)
        {
            Expression = expr;
            Op = op;
            Strength = Kiwi.Strength.Clip(strength);
        }

        public Constraint(Expression expr, RelationalOperator op)
            : this(expr, op, Kiwi.Strength.Required)
        {
        }

        public Constraint(Constraint other, double strength) 
            : this(other.Expression, other.Op, strength)
        {
        }

        public Expression Expression { get; }

        public RelationalOperator Op { get; }

        public double Strength { get; }

        public static Expression Reduce(Expression expr)
        {
            var vars = new Dictionary<Variable, double>();
            foreach (var term in expr.Terms)
            {
                vars.TryGetValue(term.Variable, out var coefficient);
                vars[term.Variable] = coefficient + term.Coefficient;
            }

            var terms = vars.Select(pair => new Term(pair.Key, pair.Value)).ToList(); // TODO remove linq
            return new Expression(terms, expr.Constant);
        }
    }
}