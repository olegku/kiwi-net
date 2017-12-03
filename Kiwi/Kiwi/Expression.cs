using System.Collections.Generic;

namespace Kiwi
{
    public class Expression
    {
        public Expression(double constant = 0.0)
        {
            Terms = new List<Term>();
            Constant = constant;
        }

        public Expression(Term term, double constant = 0.0)
        {
            Terms = new List<Term> {term};
            Constant = constant;
        }

        public Expression(List<Term> terms, double constant = 0.0)
        {
            Terms = terms; // TODO this looks weird
            Constant = constant;
        }

        public List<Term> Terms { get; }

        public double Constant { get; }

        // TODO should be converter to method, as getter is not trivial
        public double Value
        {
            get
            {
                var result = Constant;
                foreach (var term in Terms)
                {
                    result += term.Value;
                }
                return result;
            }
        }
    }
}