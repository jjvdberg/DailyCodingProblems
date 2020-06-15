using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DailyCodingProblems.Tests.Tests {
    public class Problem2Tests {

        [Theory]
        [ClassData(typeof(Problem2TestData))]
        public void OutputArrayWithMultiplesOfInputExceptI_ShouldWork(int[] input, int[] expected) {

            int[] actual = Problem2.OutputArrayWithMultiplesOfInputExceptI(input);

            Assert.Equal(expected, actual);
        }
    }

    public class Problem2TestData : IEnumerable<object[]> {
        public IEnumerator<object[]> GetEnumerator() {
            yield return new object[] { new int[] { 1, 2, 3, 4, 5 }, new int[] { 120, 60, 40, 30, 24 } };
            yield return new object[] { new int[] { 3, 2, 1 }, new int[] { 2, 3, 6 } };
            yield return new object[] { new int[] { 4, 3, 2, 1 }, new int[] { 6, 8, 12, 24 } };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 720, 360, 240, 180, 144, 120 } };
            yield return new object[] { new int[] { 2, 2, 2, 2, 2, 2, 2, 2 }, new int[] { 128, 128, 128, 128, 128, 128, 128, 128 } };
            yield return new object[] { new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2 }, new int[] { 256, 256, 256, 256, 256, 256, 256, 256, 256 } };
            yield return new object[] { new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, new int[] { 2048, 2048, 2048, 2048, 2048, 2048, 2048, 2048, 2048, 2048, 2048, 2048 } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}