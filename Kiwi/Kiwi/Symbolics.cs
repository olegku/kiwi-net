using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Kiwi
{
    struct Var
    {
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
        public static Expr operator +(Var left, double right) => throw new NotImplementedException();
        public static Expr operator +(double left, Var right) => throw new NotImplementedException();

        public static Expr operator -(Var left, Expr right) => throw new NotImplementedException();
        public static Expr operator -(Var left, Trm right) => throw new NotImplementedException();
        public static Expr operator -(Var left, Var right) => throw new NotImplementedException();
        public static Expr operator -(Var left, double right) => throw new NotImplementedException();
        public static Expr operator -(double left, Var right) => throw new NotImplementedException();

        public static Cnt operator ==(Var left, Expr right) => throw new NotImplementedException();
        public static Cnt operator ==(Var left, Trm right) => throw new NotImplementedException();
        public static Cnt operator ==(Var left, Var right) => throw new NotImplementedException();
        public static Cnt operator ==(Var left, double right) => throw new NotImplementedException();
        public static Cnt operator ==(double left, Var right) => throw new NotImplementedException();

        public static Cnt operator !=(Var left, Expr right) => throw new NotImplementedException();
        public static Cnt operator !=(Var left, Trm right) => throw new NotImplementedException();
        public static Cnt operator !=(Var left, Var right) => throw new NotImplementedException();
        public static Cnt operator !=(Var left, double right) => throw new NotImplementedException();
        public static Cnt operator !=(double left, Var right) => throw new NotImplementedException();

        public static Cnt operator <=(Var left, Expr right) => throw new NotImplementedException();
        public static Cnt operator <=(Var left, Trm right) => throw new NotImplementedException();
        public static Cnt operator <=(Var left, Var right) => throw new NotImplementedException();
        public static Cnt operator <=(Var left, double right) => throw new NotImplementedException();
        public static Cnt operator <=(double left, Var right) => throw new NotImplementedException();

        public static Cnt operator >=(Var left, Expr right) => throw new NotImplementedException();
        public static Cnt operator >=(Var left, Trm right) => throw new NotImplementedException();
        public static Cnt operator >=(Var left, Var right) => throw new NotImplementedException();
        public static Cnt operator >=(Var left, double right) => throw new NotImplementedException();
        public static Cnt operator >=(double left, Var right) => throw new NotImplementedException();

    }

    struct Trm
    {
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

        public static Expr operator +(Trm left, Expr right) => throw new NotImplementedException();
        public static Expr operator +(Trm left, Trm right) => throw new NotImplementedException();
        public static Expr operator +(Trm left, Var right) => throw new NotImplementedException();
        public static Expr operator +(Trm left, double right) => throw new NotImplementedException();
        public static Expr operator +(double left, Trm right) => throw new NotImplementedException();

        public static Expr operator -(Trm left, Expr right) => throw new NotImplementedException();
        public static Expr operator -(Trm left, Trm right) => throw new NotImplementedException();
        public static Expr operator -(Trm left, Var right) => throw new NotImplementedException();
        public static Expr operator -(Trm left, double right) => throw new NotImplementedException();
        public static Expr operator -(double left, Trm right) => throw new NotImplementedException();

        public static Cnt operator ==(Trm left, Expr right) => throw new NotImplementedException();
        public static Cnt operator ==(Trm left, Trm right) => throw new NotImplementedException();
        public static Cnt operator ==(Trm left, Var right) => throw new NotImplementedException();
        public static Cnt operator ==(Trm left, double right) => throw new NotImplementedException();
        public static Cnt operator ==(double left, Trm right) => throw new NotImplementedException();

        public static Cnt operator !=(Trm left, Expr right) => throw new NotImplementedException();
        public static Cnt operator !=(Trm left, Trm right) => throw new NotImplementedException();
        public static Cnt operator !=(Trm left, Var right) => throw new NotImplementedException();
        public static Cnt operator !=(Trm left, double right) => throw new NotImplementedException();
        public static Cnt operator !=(double left, Trm right) => throw new NotImplementedException();

        public static Cnt operator <=(Trm left, Expr right) => throw new NotImplementedException();
        public static Cnt operator <=(Trm left, Trm right) => throw new NotImplementedException();
        public static Cnt operator <=(Trm left, Var right) => throw new NotImplementedException();
        public static Cnt operator <=(Trm left, double right) => throw new NotImplementedException();
        public static Cnt operator <=(double left, Trm right) => throw new NotImplementedException();

        public static Cnt operator >=(Trm left, Expr right) => throw new NotImplementedException();
        public static Cnt operator >=(Trm left, Trm right) => throw new NotImplementedException();
        public static Cnt operator >=(Trm left, Var right) => throw new NotImplementedException();
        public static Cnt operator >=(Trm left, double right) => throw new NotImplementedException();
        public static Cnt operator >=(double left, Trm right) => throw new NotImplementedException();
    }

    struct Expr
    {
        public double C { get; }
        public Trm[] Ts { get; }

        public Expr(double c, params Trm[] ts)
        {
            C = c;
            Ts = ts;
        }

        [Pure]
        private Expr Scale(double scale)
        {
            var scaledTs = new Trm[Ts.Length];
            for (int i = 0; i < Ts.Length; i++)
            {
                scaledTs[i] = Ts[i] * scale;
            }


            return new Expr(C * scale, scaledTs);
        }

        private Expr Append(Expr right)
        {
            throw new NotImplementedException();
        }

        private Expr Append(Trm right)
        {
            throw new NotImplementedException();
        }
        private Expr Append(Var v)
        {
            throw new NotImplementedException();
        }
        private Expr Append(double c)
        {
            throw new NotImplementedException();
        }

        public static Expr operator *(Expr e, double c) => e.Scale(c);
        public static Expr operator *(double c, Expr e) => e.Scale(c);
        public static Expr operator /(Expr e, double c) => e.Scale(1/c);
        public static Expr operator -(Expr e) => e.Scale(-1.0);

        public static Expr operator +(Expr left, Expr right) => left.Append(right);
        public static Expr operator +(Expr left, Trm right) => left.Append(right);
        public static Expr operator +(Expr left, Var right) => left.Append(right);
        public static Expr operator +(Expr left, double right) => left.Append(right);
        public static Expr operator +(double left, Expr right) => right.Append(left);

        public static Expr operator -(Expr left, Expr right) => left.Append(-right);
        public static Expr operator -(Expr left, Trm right) => left.Append(-right);
        public static Expr operator -(Expr left, Var right) => left.Append(-right);
        public static Expr operator -(Expr left, double right) => left.Append(-right);
        public static Expr operator -(double left, Expr right) => right.Append(-left);

        public static Cnt operator ==(Expr left, Expr right) => new Cnt(left - right);
        public static Cnt operator ==(Expr left, Trm right) => new Cnt(left - right);
        public static Cnt operator ==(Expr left, Var right) => new Cnt(left - right);
        public static Cnt operator ==(Expr left, double right) => new Cnt(left - right);
        public static Cnt operator ==(double left, Expr right) => new Cnt(left - right);

        public static Cnt operator !=(Expr left, Expr right) => throw new NotImplementedException();
        public static Cnt operator !=(Expr left, Trm right) => throw new NotImplementedException();
        public static Cnt operator !=(Expr left, Var right) => throw new NotImplementedException();
        public static Cnt operator !=(Expr left, double right) => throw new NotImplementedException();
        public static Cnt operator !=(double left, Expr right) => throw new NotImplementedException();

        public static Cnt operator <=(Expr left, Expr right) => throw new NotImplementedException();
        public static Cnt operator <=(Expr left, Trm right) => throw new NotImplementedException();
        public static Cnt operator <=(Expr left, Var right) => throw new NotImplementedException();
        public static Cnt operator <=(Expr left, double right) => throw new NotImplementedException();
        public static Cnt operator <=(double left, Expr right) => throw new NotImplementedException();

        public static Cnt operator >=(Expr left, Expr right) => throw new NotImplementedException();
        public static Cnt operator >=(Expr left, Trm right) => throw new NotImplementedException();
        public static Cnt operator >=(Expr left, Var right) => throw new NotImplementedException();
        public static Cnt operator >=(Expr left, double right) => throw new NotImplementedException();
        public static Cnt operator >=(double left, Expr right) => throw new NotImplementedException();
    }

    struct Cnt
    {
        public Expr E { get; }

        public Cnt(Expr e)
        {
            E = e;
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
        }
    }
}
