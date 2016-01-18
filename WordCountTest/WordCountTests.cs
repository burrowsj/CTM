using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCount;

namespace WordCountTest
{
    [TestFixture]
    public class WordCountTests
    {
        static int[] PrimeNumbers = new int[] { 2, 3, 5, 7, 11, 13 };

        static int[] NonPrimeNumbers = new int[] { 4, 6, 8, 24, 27, 35 };

        [Test, TestCaseSource("PrimeNumbers")]
        public void isPrime(int number)
        {
            //Arrange
            
            //Act

            var prime = PrimeCalculator.isPrime(number);

            //Assert
            Assert.IsTrue(prime);
        }

        [Test, TestCaseSource("NonPrimeNumbers")]
        public void isNotPrime(int number)
        {
            //Arrange

            //Act

            var prime = PrimeCalculator.isPrime(number);

            //Assert
            Assert.IsFalse(prime);
        }
    }
}
