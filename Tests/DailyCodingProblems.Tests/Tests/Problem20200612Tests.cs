﻿using System.Collections;
using System.Collections.Generic;
using Xunit;

public class Problem20200612Tests {


    [Theory]
    [ClassData(typeof(TestListData))]
    public void ShouldFindTwoNumbersInListThatAddUpToNrK(int k, List<int> list, bool expected) {

        bool actual = Problem20200612.CanMakeNrKFromAdditionOfTwoNrsInList(k, list);

        Assert.Equal(expected, actual);
    }
}

public class TestListData : IEnumerable<object[]> {
    public IEnumerator<object[]> GetEnumerator() {
        yield return new object[] { 17, new List<int> { 10, 15, 3, 7 }, true };
        yield return new object[] { 17, new List<int> { 7, 10, 3, 15 }, true };
        yield return new object[] { 17, new List<int> { 5, 9, 3, 7 }, false };
        yield return new object[] { -17, new List<int> { -10, -15, -3, -7 }, true };
        yield return new object[] { 1025, new List<int> { 225, 335, 445, 555, 665, 775, 885 }, false };
        yield return new object[] { 1025, new List<int> { 140, 245, 360, 475, 690, 885, 1025 }, true };
        yield return new object[] { 1025, new List<int> { 1025, 885, 690, 475, 360, 245, 140 }, true };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}