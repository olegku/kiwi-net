using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Kiwi
{
    public class Var
    {
        private const string _notSupported = "Not supported";
        public string Name { get; }

        public Var(string name)
        {
            Name = name;
        }

        public static Trm operator *(Var v, double c) => new Trm(v, c);
        public static Trm operator *(double c, Var v) => new Trm(v, c);
        public static Trm operator /(Var v, double c) => new Trm(v, 1/c);
        public static Trm operator -(Var v) => new Trm(v, -1.0);

        public static Expr operator +(Var left, Expr right) => new Trm(left) + right;
        public static Expr operator +(Var left, Trm right) => new Trm(left) + right;
        public static Expr operator +(Var left, Var right) => new Trm(left) + right;
        public static Expr operator +(Var left, double right) => new Trm(left) + right;
        public static Expr operator +(double left, Var right) => new Trm(right) + left;

        public static Expr operator -(Var left, Expr right) => new Trm(left) - right;
        public static Expr operator -(Var left, Trm right) => new Trm(left) - right;
        public static Expr operator -(Var left, Var right) => new Trm(left) - right;
        public static Expr operator -(Var left, double right) => new Trm(left) - right;
        public static Expr operator -(double left, Var right) => new Trm(right) - left;

        public static Cnt operator ==(Var left, Expr right) => new Trm(left) == right;
        public static Cnt operator ==(Var left, Trm right) => new Trm(left) == right;
        public static Cnt operator ==(Var left, Var right) => new Trm(left) == right;
        public static Cnt operator ==(Var left, double right) => new Trm(left) == right;
        public static Cnt operator ==(double left, Var right) => new Trm(right) == left;

        [Obsolete(_notSupported, true)] public static Cnt operator !=(Var left, Expr right) => throw new InvalidOperationException();
        [Obsolete(_notSupported, true)] public static Cnt operator !=(Var left, Trm right) => throw new InvalidOperationException();
        [Obsolete(_notSupported, true)] public static Cnt operator !=(Var left, Var right) => throw new InvalidOperationException();
        [Obsolete(_notSupported, true)] public static Cnt operator !=(Var left, double right) => throw new InvalidOperationException();
        [Obsolete(_notSupported, true)] public static Cnt operator !=(double left, Var right) => throw new InvalidOperationException();

        public static Cnt operator <=(Var left, Expr right) => new Trm(left) <= right;
        public static Cnt operator <=(Var left, Trm right) => new Trm(left) <= right;
        public static Cnt operator <=(Var left, Var right) => new Trm(left) <= right;
        public static Cnt operator <=(Var left, double right) => new Trm(left) <= right;
        public static Cnt operator <=(double left, Var right) => new Trm(right) <= left;

        public static Cnt operator >=(Var left, Expr right) => new Trm(left) >= right;
        public static Cnt operator >=(Var left, Trm right) => new Trm(left) >= right;
        public static Cnt operator >=(Var left, Var right) => new Trm(left) >= right;
        public static Cnt operator >=(Var left, double right) => new Trm(left) >= right;
        public static Cnt operator >=(double left, Var right) => new Trm(right) >= left;

    }

    public class Trm
    {
        private const string _notSupported = "Not supported";

        public Var V { get; }
        public double C { get; }

        public Trm(Var v, double c = 1.0)
        {
            V = v;
            C = c;
        }

        public static Trm operator *(Trm t, double c) => new Trm(t.V, t.C * c);
        public static Trm operator *(double c, Trm t) => new Trm(t.V, t.C * c);
        public static Trm operator /(Trm t, double c) => new Trm(t.V, t.C / c);
        public static Trm operator -(Trm t) => new Trm(t.V, -t.C);

        public static Expr operator +(Trm left, Expr right) => new Expr(left).Add(right);
        public static Expr operator +(Trm left, Trm right) => new Expr(left).Add(right);
        public static Expr operator +(Trm left, Var right) => new Expr(left).Add(right);
        public static Expr operator +(Trm left, double right) => new Expr(left, right);
        public static Expr operator +(double left, Trm right) => new Expr(right, left);

        public static Expr operator -(Trm left, Expr right) => new Expr(left).Add(-right);
        public static Expr operator -(Trm left, Trm right) => new Expr(left).Add(-right);
        public static Expr operator -(Trm left, Var right) => new Expr(left).Add(-right);
        public static Expr operator -(Trm left, double right) => new Expr(left, -right);
        public static Expr operator -(double left, Trm right) => new Expr(-right, left);

        public static Cnt operator ==(Trm left, Expr right) => new Cnt(left - right);
        public static Cnt operator ==(Trm left, Trm right) => new Cnt(left - right);
        public static Cnt operator ==(Trm left, Var right) => new Cnt(left - right);
        public static Cnt operator ==(Trm left, double right) => new Cnt(left - right);
        public static Cnt operator ==(double left, Trm right) => new Cnt(left - right);

        [Obsolete(_notSupported, true)] public static Cnt operator !=(Trm left, Expr right) => throw new InvalidOperationException();
        [Obsolete(_notSupported, true)] public static Cnt operator !=(Trm left, Trm right) => throw new InvalidOperationException();
        [Obsolete(_notSupported, true)] public static Cnt operator !=(Trm left, Var right) => throw new InvalidOperationException();
        [Obsolete(_notSupported, true)] public static Cnt operator !=(Trm left, double right) => throw new InvalidOperationException();
        [Obsolete(_notSupported, true)] public static Cnt operator !=(double left, Trm right) => throw new InvalidOperationException();

        public static Cnt operator <=(Trm left, Expr right) => new Cnt(left - right, RelationalOperator.OP_LE);
        public static Cnt operator <=(Trm left, Trm right) => new Cnt(left - right, RelationalOperator.OP_LE);
        public static Cnt operator <=(Trm left, Var right) => new Cnt(left - right, RelationalOperator.OP_LE);
        public static Cnt operator <=(Trm left, double right) => new Cnt(left - right, RelationalOperator.OP_LE);
        public static Cnt operator <=(double left, Trm right) => new Cnt(left - right, RelationalOperator.OP_LE);

        public static Cnt operator >=(Trm left, Expr right) => new Cnt(left - right, RelationalOperator.OP_GE);
        public static Cnt operator >=(Trm left, Trm right) => new Cnt(left - right, RelationalOperator.OP_GE);
        public static Cnt operator >=(Trm left, Var right) => new Cnt(left - right, RelationalOperator.OP_GE);
        public static Cnt operator >=(Trm left, double right) => new Cnt(left - right, RelationalOperator.OP_GE);
        public static Cnt operator >=(double left, Trm right) => new Cnt(left - right, RelationalOperator.OP_GE);
    }

    
    public class Expr
    {
        private const string _notSupported = "Not supported";

        public double C { get; }
        public Trm[] Ts { get; }

        public Expr(Trm t, double c = 0.0)
        {
            Ts = new[] {t};
            C = c;
        }

        private Expr(Trm[] ts, double c)
        {
            Ts = ts;
            C = c;
        }

        #region Array Concat Methods

        [Pure]
        private static Trm[] Concat(Trm[] a, Trm[] b)
        {
            var result = new Trm[a.Length + b.Length];
            a.CopyTo(result, 0);
            b.CopyTo(result, a.Length);
            return result;
        }

        [Pure]
        private static Trm[] Concat(Trm[] a, Trm b)
        {
            var result = new Trm[a.Length + 1];
            a.CopyTo(result, 0);
            result[a.Length] = b;
            return result;
        }

        #endregion

        [Pure]
        public Expr Scale(double scale)
        {
            var scaledTs = new Trm[Ts.Length];
            for (int i = 0; i < Ts.Length; i++)
            {
                scaledTs[i] = Ts[i] * scale;
            }
            return new Expr(scaledTs, C * scale);
        }

        #region Append Methods

        [Pure]
        public Expr Add(Expr other)
        {
            return new Expr(Concat(Ts, other.Ts), C + other.C);
        }

        [Pure]
        public Expr Add(Trm other)
        {
            return new Expr(Concat(Ts, other), C);
        }

        // TODO can be removed if there is Var cast to Term operator
        [Pure]
        public Expr Add(Var v)
        {
            return new Expr(Concat(Ts, new Trm(v)), C);
        }

        [Pure]
        public Expr Add(double c)
        {
            return new Expr(Ts, C + c);
        }

        #endregion

        public static Expr operator *(Expr e, double c) => e.Scale(c);
        public static Expr operator *(double c, Expr e) => e.Scale(c);
        public static Expr operator /(Expr e, double c) => e.Scale(1/c);
        public static Expr operator -(Expr e) => e.Scale(-1.0);

        public static Expr operator +(Expr left, Expr right) => left.Add(right);
        public static Expr operator +(Expr left, Trm right) => left.Add(right);
        public static Expr operator +(Expr left, Var right) => left.Add(right);
        public static Expr operator +(Expr left, double right) => left.Add(right);
        public static Expr operator +(double left, Expr right) => right.Add(left);

        public static Expr operator -(Expr left, Expr right) => left.Add(-right);
        public static Expr operator -(Expr left, Trm right) => left.Add(-right);
        public static Expr operator -(Expr left, Var right) => left.Add(-right);
        public static Expr operator -(Expr left, double right) => left.Add(-right);
        public static Expr operator -(double left, Expr right) => right.Add(-left);

        public static Cnt operator ==(Expr left, Expr right) => new Cnt(left - right);
        public static Cnt operator ==(Expr left, Trm right) => new Cnt(left - right);
        public static Cnt operator ==(Expr left, Var right) => new Cnt(left - right);
        public static Cnt operator ==(Expr left, double right) => new Cnt(left - right);
        public static Cnt operator ==(double left, Expr right) => new Cnt(left - right);

        [Obsolete(_notSupported, true)] public static Cnt operator !=(Expr left, Expr right) => throw new InvalidOperationException();
        [Obsolete(_notSupported, true)] public static Cnt operator !=(Expr left, Trm right) => throw new InvalidOperationException();
        [Obsolete(_notSupported, true)] public static Cnt operator !=(Expr left, Var right) => throw new InvalidOperationException();
        [Obsolete(_notSupported, true)] public static Cnt operator !=(Expr left, double right) => throw new InvalidOperationException();
        [Obsolete(_notSupported, true)] public static Cnt operator !=(double left, Expr right) => throw new InvalidOperationException();

        public static Cnt operator <=(Expr left, Expr right) => new Cnt(left - right, RelationalOperator.OP_LE);
        public static Cnt operator <=(Expr left, Trm right) => new Cnt(left - right, RelationalOperator.OP_LE);
        public static Cnt operator <=(Expr left, Var right) => new Cnt(left - right, RelationalOperator.OP_LE);
        public static Cnt operator <=(Expr left, double right) => new Cnt(left - right, RelationalOperator.OP_LE);
        public static Cnt operator <=(double left, Expr right) => new Cnt(left - right, RelationalOperator.OP_LE);

        public static Cnt operator >=(Expr left, Expr right) => new Cnt(left - right, RelationalOperator.OP_GE);
        public static Cnt operator >=(Expr left, Trm right) => new Cnt(left - right, RelationalOperator.OP_GE);
        public static Cnt operator >=(Expr left, Var right) => new Cnt(left - right, RelationalOperator.OP_GE);
        public static Cnt operator >=(Expr left, double right) => new Cnt(left - right, RelationalOperator.OP_GE);
        public static Cnt operator >=(double left, Expr right) => new Cnt(left - right, RelationalOperator.OP_GE);
    }

    public class Cnt
    {
        public Expr E { get; }
        public RelationalOperator Op { get; }

        public Cnt(Expr e, RelationalOperator op = RelationalOperator.OP_EQ)
        {
            E = e;
            Op = op;
        }

        public static Cnt operator |(Cnt cnt, double strength) => throw new NotImplementedException();
        public static Cnt operator |(double strength, Cnt cnt) => throw new NotImplementedException();
    }

    public class Symbolics
    {
        public Symbolics()
        {
            var x = new Var("x");
            var y = new Var("y");

            var i = 10 + 20;
            var expr = x + 1;

            (2 * x + 1).Add(4);

            var e2 = x == y;
            //var e3 = x != y; // compile error
        }
    }
}
