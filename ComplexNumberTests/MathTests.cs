using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

using ComplexNumber;
using NUnit.Framework;
using System.Collections;

namespace ComplexNumberTests
{
    [TestFixture]
    public class MathTests
    {
        public class AddTestData
        {
            public Complex n1 {get;set;}
            public Complex n2 { get; set; }
            public Complex res { get; set; }

            public static string FileName = @"C:\Users\alexa\Documents\visual studio 2015\Projects\ComplexNumberSolution\ComplexNumberTests\Data\AddTestData.xml";

            public static IEnumerable Data{
                get {

                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(FileName);

                    XmlElement xRoot = xdoc.DocumentElement;

                    List<TestCaseData> l = new List<TestCaseData>();

                    foreach (XmlElement e in xRoot.ChildNodes)
                    {
                        var testCaseId = e.GetAttribute("id");
                        var testCaseName = e.GetAttribute("name");
                        var executeCase = bool.Parse(e.GetAttribute("execute"));

                        var testFullName = String.Format("Iteration {0}: {1}", testCaseId, testCaseName);

                        XmlElement c1 = e.FirstChild as XmlElement;
                        XmlElement c2 = c1.NextSibling as XmlElement;
                        XmlElement res = c2.NextSibling as XmlElement;

                        float r = float.Parse(c1.GetAttribute("real"));
                        float i = float.Parse(c1.GetAttribute("imaginary"));

                        Complex first = new Complex(r, i);

                        r = float.Parse(c2.GetAttribute("real"));
                        i = float.Parse(c2.GetAttribute("imaginary"));

                        Complex secnd = new Complex(r, i);

                        r = float.Parse(res.GetAttribute("real"));
                        i = float.Parse(res.GetAttribute("imaginary"));

                        Complex reslt = new Complex(r, i);

                        TestCaseData tcd = new TestCaseData(new AddTestData()
                        {
                            n1 = first,
                            n2 = secnd,
                            res = reslt
                        });

                        tcd.SetName(testFullName);
                        if (!executeCase)
                            tcd.Ignore("Unstable");

                        l.Add(tcd);
                    }
                    
                    return l;
                }
                }

        }


        [Test]
        public void Test_AreEquial()
        {
            Complex c1 = new Complex(1, 3);
            Complex c2 = new Complex(1, 3);

            Assert.True(c1 == c2);
            Assert.True(c2 == c1);
        }
        
        [Test]
        public void Test_AreNotEquial()
        {
            Complex c1 = new Complex(1, 3);
            Complex c2 = new Complex(3, 1);

            Assert.True(c1 != c2);
            Assert.True(c2 != c1);
        }

        [Test]
        public void Test_Add()
        {
            Complex c1 = new Complex(1, 3);
            Complex c2 = new Complex(3, 1);

            Complex res = new Complex(4, 4);

            Assert.AreEqual(res, c1 + c2);
            Assert.AreEqual(res, c2 + c1);
        }

        [Test, TestCaseSource(typeof(AddTestData), "Data")]
        public void Test_Add_Param(AddTestData data)
        {
            Complex c1 = data.n1;
            Complex c2 = data.n2;

            Complex res = data.res;

            Assert.AreEqual(res, c1 + c2);
            Assert.AreEqual(res, c2 + c1);
        }

        [Test]
        public void Test_Sub()
        {
            Complex c1 = new Complex(4, 3);
            Complex c2 = new Complex(3, 1);

            Complex res = new Complex(1, 2);

            Assert.AreEqual(res, c1 - c2);
            Assert.AreNotEqual(res, c2 - c1);
        }

        [Test]
        public void Test_Mult()
        {
            Complex c1 = new Complex(2, 3);
            Complex c2 = new Complex(3, 2);

            Complex res = new Complex(0, 13);

            Assert.AreEqual(res, c1 * c2);
            Assert.AreEqual(res, c2 * c1);
        }

    }
}
