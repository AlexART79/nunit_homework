using System;
using System.Globalization;

namespace ComplexNumber
{
    public class Complex
    {
        //
        // Protected fields
        //
        protected float _real;
        protected float _imaginary;

        //
        // public Properties
        //
        public float real {
            get { return _real; }
        }
        public float imaginary {
            get { return _imaginary; }
        }

        //
        // Constructor
        //
        public Complex(float r, float i)
        {
            _real = r;
            _imaginary = i;
        }

        //
        // General methods (ToString and Equals) overriding
        //
        public override string ToString()
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

            var s = "";
            if (real != 0)
                s += (Math.Round(real * 100) / 100).ToString(nfi);
            
            if (imaginary < 0)
                s += " - ";
            if (imaginary > 0)
                s += " + ";
            if (imaginary != 0)
                s += "i" + (Math.Round(Math.Abs(imaginary) * 100) / 100).ToString(nfi);

            return s;//real + " + i" + imaginary;
        }

        public override bool Equals(Object obj)
        {
            return ((Complex)obj).real == real && ((Complex)obj).imaginary == imaginary;
        }

        //
        // Operators overloading
        //
        public static bool operator ==(Complex a, Complex b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Complex a, Complex b)
        {
            return !a.Equals(b);
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.real + b.real, a.imaginary+b.imaginary);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.real - b.real, a.imaginary - b.imaginary);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(
                    a.real*b.real - a.imaginary*b.imaginary, 
                    a.imaginary*b.real + a.real*b.imaginary
                );
        }

        public static Complex operator /(Complex a, Complex b)
        {
            return new Complex(
                    (a.real * b.real + a.imaginary * b.imaginary)/(b.real * b.real + b.imaginary * b.imaginary),
                    (a.imaginary * b.real - a.real * b.imaginary)/(b.real * b.real + b.imaginary * b.imaginary)
                );
        }
    }
}
