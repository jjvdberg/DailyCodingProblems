using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DailyCodingProblems.Tests.Tests {
    public class Problem4Tests {

        [Theory]
        [ClassData(typeof(Problem4TestData))]
        public void FindFirstMissingPossitiveInteger_ShouldWork(int[] integers, int expected) {

            int actual = Problem4.FindFirstMissingPossitiveInteger(integers);

            Assert.Equal(expected, actual);
        }
    }

    public class Problem4TestData : IEnumerable<object[]> {
        public IEnumerator<object[]> GetEnumerator() {
            yield return new object[] { new int[] { 3, 4, -1, 1 }, 2 };
            yield return new object[] { new int[] { 1, 2, 0}, 3};
            yield return new object[] { new int[] { -7, 4, 5, 0, 7 }, 6 };
            yield return new object[] { new int[] { 1, 3, 0, 4, 6, 7 }, 2 };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
