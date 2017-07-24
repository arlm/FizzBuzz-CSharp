using FizzBuzzConsole;
using NUnit.Framework;
using System.Collections;
using System.Linq;

namespace FizzBuzzTests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestLimits()
        {
            Assert.IsEmpty(FizzBuzz.Generate(0));
            Assert.IsEmpty(FizzBuzz.Generate(-1));
            Assert.IsEmpty(FizzBuzz.Generate(int.MinValue));
            Assert.IsNotEmpty(FizzBuzz.Generate(1));
        }

        [Test]
        public void TestQuantities()
        {
            var sequence = FizzBuzz.Generate(1500);

            Assert.AreEqual(500, sequence.Count(item => item.Contains("Fizz")));
            Assert.AreEqual(300, sequence.Count(item => item.Contains("Buzz")));
            Assert.AreEqual(100, sequence.Count(item => item == "FizzBuzz"));

            Assert.AreEqual(800, sequence.Count(item => !item.Contains("Fizz") && !item.Contains("Buzz")));
            var div3 = sequence.Where((item, index) => (index + 1) % 3 == 0).Select(i => i);
            var div5 = sequence.Where((item, index) => (index + 1) % 5 == 0).Select(i => i);
            var div15 = sequence.Where((item, index) => (index + 1) % 15 == 0).Select(i => i);

            Assert.AreEqual(div3.Count(), div3.Count(item => item.Contains("Fizz")));
            Assert.AreEqual(div3.Count() - 100, div3.Count(item => item == "Fizz"));
            Assert.AreEqual(div5.Count(), div5.Count(item => item.Contains("Buzz")));
            Assert.AreEqual(div5.Count() - 100, div5.Count(item => item == "Buzz"));
            Assert.AreEqual(div15.Count(), div15.Count(item => item == "FizzBuzz"));
        }

        [Test]
        public void TestItems()
        {
            var sequence = FizzBuzz.Generate(1500);

            var fizz = sequence.Where((item, index) => (index + 1) % 3 == 0 && (index + 1) % 5 != 0).Select(i => i);
            var buzz = sequence.Where((item, index) => (index + 1) % 3 != 0 && (index + 1) % 5 == 0).Select(i => i);
            var fizzBuzz = sequence.Where((item, index) => (index + 1) % 15 == 0).Select(i => i);
            var numbers = sequence.Where((item, index) => (index + 1) % 3 != 0 && (index + 1) % 5 != 0).Select(i => i);

            Assert.AreEqual(fizz.Count(), fizz.Count(item => item == "Fizz"));
            Assert.AreEqual(buzz.Count(), buzz.Count(item => item == "Buzz"));
            Assert.AreEqual(fizzBuzz.Count(), fizzBuzz.Count(item => item == "FizzBuzz"));
            Assert.AreEqual(800, numbers.Count(item => int.TryParse(item, out int result)));
        }

        [Test]
        [TestCaseSource(typeof(SelectedItems), "TestCases")]
        public string TestSelectedItems(int index, int count)
        {
            var sequence = FizzBuzz.Generate(count);

            return sequence.Skip(index - 1).First();
        }

        public class SelectedItems
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(1, 31).Returns("1");
                    yield return new TestCaseData(2, 31).Returns("2");
                    yield return new TestCaseData(3, 31).Returns("Fizz");
                    yield return new TestCaseData(4, 31).Returns("4");
                    yield return new TestCaseData(5, 31).Returns("Buzz");
                    yield return new TestCaseData(6, 31).Returns("Fizz");
                    yield return new TestCaseData(7, 31).Returns("7");
                    yield return new TestCaseData(8, 31).Returns("8");
                    yield return new TestCaseData(9, 31).Returns("Fizz");
                    yield return new TestCaseData(10, 31).Returns("Buzz");
                    yield return new TestCaseData(11, 31).Returns("11");
                    yield return new TestCaseData(12, 31).Returns("Fizz");
                    yield return new TestCaseData(13, 31).Returns("13");
                    yield return new TestCaseData(14, 31).Returns("14");
                    yield return new TestCaseData(15, 31).Returns("FizzBuzz");
                    yield return new TestCaseData(17, 31).Returns("17");
                    yield return new TestCaseData(18, 31).Returns("Fizz");
                    yield return new TestCaseData(20, 31).Returns("Buzz");
                    yield return new TestCaseData(21, 31).Returns("Fizz");
                    yield return new TestCaseData(24, 31).Returns("Fizz");
                    yield return new TestCaseData(25, 31).Returns("Buzz");
                    yield return new TestCaseData(30, 31).Returns("FizzBuzz");
                    yield return new TestCaseData(30, 30).Returns("FizzBuzz");
                    yield return new TestCaseData(35, 35).Returns("Buzz");
                    yield return new TestCaseData(40, 45).Returns("Buzz");
                    yield return new TestCaseData(45, 45).Returns("FizzBuzz");
                    yield return new TestCaseData(50, 50).Returns("Buzz");
                    yield return new TestCaseData(60, 60).Returns("FizzBuzz");
                    yield return new TestCaseData(111, 111).Returns("Fizz");
                    yield return new TestCaseData(500, 500).Returns("Buzz");
                    yield return new TestCaseData(600, 600).Returns("FizzBuzz");
                    yield return new TestCaseData(998, 998).Returns("998");
                    yield return new TestCaseData(999, 999).Returns("Fizz");
                    yield return new TestCaseData(1500, 1500).Returns("FizzBuzz");
                }
            }
        }
    }
}
