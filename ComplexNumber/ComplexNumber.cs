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
            return Add(left, right);
        }

        public static Complex Add(Complex left, Complex right)
        {
            return new Complex(left.RealNumbers + right.RealNumbers, left.ImaginaryUnit + right.ImaginaryUnit);
        }
        public static Complex AddStat(params Complex[] complexes)
        {
            Complex complex = new Complex();
            for (int i = 0; i < complexes.Length; i++)
            {
                complex = Add(complex, complexes[i]);
            }
            return complex;
        }

        public Complex Add(Complex complex)
        {
            return Add(this,complex);
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
            return Sub(left, right);
        }

        public static Complex Sub(Complex left, Complex right)
        {
            return new Complex(left.RealNumbers - right.RealNumbers, left.ImaginaryUnit - right.ImaginaryUnit);
        }
       
        public Complex Sub(Complex complex)
        {
            return Sub(this,complex);
        }

        #endregion

        //-------------------- Multiplication --------------------------//
        #region Multiplication

        public static Complex operator *(Complex left, Complex right)
        {
            return Mul(left, right);
        }

        public static Complex Mul(Complex left, Complex right)
        {
            return new Complex(left.RealNumbers * right.RealNumbers - left.ImaginaryUnit * right.ImaginaryUnit, left.ImaginaryUnit * right.RealNumbers + left.RealNumbers * right.ImaginaryUnit);
        }

        public static Complex MulStat(params Complex[] complexes)
        {
            Complex complex = new Complex();
            for (int i = 0; i < complexes.Length; i++)
            {
                complex = Mul(complex, complexes[i]);
            }
            return complex;
        }

        public Complex Mul(Complex complex)
        {
            return MulStat(this, complex);
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
            return Div(left, right);
        }

        public static Complex Div(Complex left, Complex right)
        {
            double realNumbers = (left.RealNumbers * right.RealNumbers + left.ImaginaryUnit * right.ImaginaryUnit) / (Math.Pow(right.RealNumbers, 2) + Math.Pow(right.ImaginaryUnit, 2));
            double imaginaryUnit = (left.ImaginaryUnit * right.RealNumbers - left.RealNumbers * right.ImaginaryUnit) / (Math.Pow(right.RealNumbers, 2) + Math.Pow(right.ImaginaryUnit, 2));
            return new Complex(realNumbers, imaginaryUnit);
        }

        public Complex Div(Complex complex)
        {
            return Div(this,complex);
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
            if(obj != null && obj is Complex )
            return (Math.Abs(RealNumbers - ((Complex)obj).RealNumbers)  <=0.000001) && (Math.Abs(ImaginaryUnit - ((Complex)obj).ImaginaryUnit) <= 0.000001);

            return false;
        }
        #endregion

        public override int GetHashCode()
        {
            return RealNumbers.GetHashCode()*397 ^ ImaginaryUnit.GetHashCode()*131;
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
