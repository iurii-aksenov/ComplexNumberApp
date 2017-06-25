using ComplexNumber;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumberTest
{
    [TestFixture]
    public class ComplexNumberTest
    {
        Complex _left;
        Complex _right;

        [SetUp]
        public void SetUp()
        {
            _left = new Complex(7, -5);
            _right = new Complex(3, 4);
        }

        [Test]
        public void AddStatTest()
        {
            Complex rightComplex = new Complex(10, -1);

            Assert.AreEqual(rightComplex,Complex.AddStat(_left,_right));
        }

        [Test]
        public void SubStatTest()
        {
            Complex rightComplex = new Complex(4, -9);

            Assert.AreEqual(rightComplex, Complex.SubStat(_left, _right));
        }

        [Test]
        public void MulStatTest()
        {
            Complex rightComplex = new Complex(41, 13);

            Assert.AreEqual(rightComplex, Complex.MulStat(_left, _right));
        }

        [Test]
        public void DivStatTest()
        {
            Complex rightComplex = new Complex(1.0 / 25.0, -43.0 / 25.0);

            Assert.AreEqual(rightComplex, Complex.DivStat(_left, _right));
        }

        [Test]
        public void ModuleStatTest()
        {
            double right = Math.Sqrt(Math.Pow(_left.RealNumbers, 2) + Math.Pow(_left.ImaginaryUnit, 2));
            Assert.AreEqual(right, Complex.ModuleStat(_left));

        }

        [Test]
        public void EqualsTest()
        {
            Assert.AreEqual(false,_left.Equals(_right));
            Complex complex = new Complex(_left.RealNumbers,_left.ImaginaryUnit);
            Assert.AreEqual(true, _left.Equals(complex));
        }

        [Test]
        public void GetHashCodeTest()
        {
            Complex complex = new Complex(_left.RealNumbers, _left.ImaginaryUnit);
            Assert.AreEqual(_left.GetHashCode(),complex.GetHashCode());
        }

        [Test]
        public void ToStringTest()
        {
            string realNumbers = _left.RealNumbers.ToString();
            string sign = _left.ImaginaryUnit > 0 ? "+" : "";
            string imaginaryUnit = _left.ImaginaryUnit == 1 ? "" : _left.ImaginaryUnit.ToString();

            string right =  $"{realNumbers}{sign}{imaginaryUnit}i";

            Assert.AreEqual(right,_left.ToString());
        }
    }
}
