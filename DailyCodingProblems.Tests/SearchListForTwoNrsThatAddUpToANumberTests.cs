using System.Collections.Generic;
using Xunit;

public class SearchListForTwoNrsThatAddUpToANumberTests {

    [Fact]
    public void ShouldFindTwoNumbersThatAddUpToANr() {
        // Expected
        bool expected = true;

        // Actual
        List<int> list = new List<int> { 10, 15, 3, 7 };
        int k = 17;
        bool actual = SearchListForTwoNrsThatAddUpToANumber.CanMakeFromAdditionOfTwoInList(k, list);

        // Assert
        Assert.Equal(expected, actual);
    }
}