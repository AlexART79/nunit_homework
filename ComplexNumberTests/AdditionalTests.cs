using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ComplexNumber;
using NUnit.Framework;

namespace ComplexNumberTests
{
    [TestFixture]
    class AdditionalTests
    {
        [Test]
        public void Test_ToString()
        {
            Complex c1 = new Complex(1, 2);
            string res = "1 + i2";

            Assert.AreEqual(res, c1.ToString());
        }

        [Test]        
        public void Test_ToString_FloatValues()
        {
            Complex c1 = new Complex(1.325f, 2.024f);
            string res = "1.33 + i2.02";

            Assert.AreEqual(res, c1.ToString());
        }
    }
}
