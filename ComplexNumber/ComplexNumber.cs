using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumber
{
    public struct Complex
    {
        public double RealNumbers { get; }
        public double ImaginaryUnit { get; }

        public Complex(double realNumbers) : this(realNumbers, 0) { }
        public Complex(double realNumbers, double imaginaryUnit)
        {
            this.RealNumbers = realNumbers;
            this.ImaginaryUnit = imaginaryUnit;
        }

        //-------------------- Addition --------------------------//
        #region Addition

        public static Complex operator +(Complex left, Complex right)
        {
            return AddStat(left, right);
        }

        public static Complex AddStat(Complex left, Complex right)
        {
            return new Complex(left.RealNumbers + right.RealNumbers, left.ImaginaryUnit + right.ImaginaryUnit);
        }
        public static Complex AddStat(params Complex[] complexes)
        {
            Complex complex = new Complex();
            for (int i = 0; i < complexes.Length; i++)
            {
                complex = AddStat(complex, complexes[i]);
            }
            return complex;
        }

        public Complex Add(Complex left, Complex right)
        {
            return AddStat(left, right);
        }
        public Complex Add(params Complex[] complexes)
        {
            return AddStat(complexes);
        }

        #endregion


        //-------------------- Substraction --------------------------//
        #region Substraction

        public static Complex operator -(Complex left, Complex right)
        {
            return SubStat(left, right);
        }

        public static Complex SubStat(Complex left, Complex right)
        {
            return new Complex(left.RealNumbers - right.RealNumbers, left.ImaginaryUnit - right.ImaginaryUnit);
        }

        public static Complex SubStat(params Complex[] complexes)
        {
            Complex complex = new Complex();
            for (int i = 0; i < complexes.Length; i++)
            {
                complex = SubStat(complex, complexes[i]);
            }
            return complex;
        }

        public Complex Sub(Complex left, Complex right)
        {
            return SubStat(left, right);
        }

        public Complex Sub(params Complex[] complexes)
        {
            return SubStat(complexes);
        }

        #endregion

        //-------------------- Multiplication --------------------------//
        #region Multiplication

        public static Complex operator *(Complex left, Complex right)
        {
            return MulStat(left, right);
        }

        public static Complex MulStat(Complex left, Complex right)
        {
            return new Complex(left.RealNumbers * right.RealNumbers - left.ImaginaryUnit * right.ImaginaryUnit, left.ImaginaryUnit * right.RealNumbers + left.RealNumbers * right.ImaginaryUnit);
        }

        public static Complex MulStat(params Complex[] complexes)
        {
            Complex complex = new Complex();
            for (int i = 0; i < complexes.Length; i++)
            {
                complex = MulStat(complex, complexes[i]);
            }
            return complex;
        }

        public Complex Mul(Complex left, Complex right)
        {
            return MulStat(left, right);
        }

        public Complex Mul(params Complex[] complexes)
        {
            return MulStat(complexes);
        }
        #endregion

        //-------------------- Division --------------------------//
        #region Division

        public static Complex operator /(Complex left, Complex right)
        {
            return DivStat(left, right);
        }

        public static Complex DivStat(Complex left, Complex right)
        {
            double realNumbers = (left.RealNumbers * right.RealNumbers + left.ImaginaryUnit * right.ImaginaryUnit) / (Math.Pow(right.RealNumbers, 2) + Math.Pow(right.ImaginaryUnit, 2));
            double imaginaryUnit = (left.ImaginaryUnit * right.RealNumbers - left.RealNumbers * right.ImaginaryUnit) / (Math.Pow(right.RealNumbers, 2) + Math.Pow(right.ImaginaryUnit, 2));
            return new Complex(realNumbers, imaginaryUnit);
        }

        public static Complex DivStat(params Complex[] complexes)
        {
            Complex complex = new Complex();
            for (int i = 0; i < complexes.Length; i++)
            {
                complex = DivStat(complex, complexes[i]);
            }
            return complex;
        }

        public Complex Div(Complex left, Complex right)
        {
            return MulStat(left, right);
        }

        public Complex Div(params Complex[] complexes)
        {
            return DivStat(complexes);
        }
        #endregion

        //-------------------- Module --------------------------//
        #region Module

        public static double ModuleStat(Complex complex)
        {
            return Math.Sqrt(Math.Pow(complex.RealNumbers, 2) + Math.Pow(complex.ImaginaryUnit, 2));
        }

        public double Module(Complex complex)
        {
            return ModuleStat(complex);
        }

        public static implicit operator Complex(double num)
        {
            return new Complex(num);
        }

        public static explicit operator double(Complex complex)
        {
            return ModuleStat(complex);
        }
        #endregion

        //-------------------- Equality operators --------------------------//
        #region Equality operators

        public static bool operator ==(Complex left, Complex right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Complex left, Complex right)
        {
            return left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            return (Math.Abs(RealNumbers - ((Complex)obj).RealNumbers)  <=0.000001) && (Math.Abs(ImaginaryUnit - ((Complex)obj).ImaginaryUnit) <= 0.000001);
        }
        #endregion

        public override int GetHashCode()
        {
            return RealNumbers.GetHashCode() ^ ImaginaryUnit.GetHashCode();
        }

        public override string ToString()
        {
            string realNumbers = RealNumbers.ToString();
            string sign = ImaginaryUnit > 0 ? "+" : "";
            string imaginaryUnit = ImaginaryUnit == 1 ? "" : ImaginaryUnit.ToString();

            return $"{realNumbers}{sign}{imaginaryUnit}i";
        }
    }
}
