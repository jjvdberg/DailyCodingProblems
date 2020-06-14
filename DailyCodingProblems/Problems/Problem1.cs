using System.Collections.Generic;

public class Problem1 {

    /// <summary>
    /// Problem #1 
    /// Date: 20200611
    /// 
    /// Given a list of numbers and a number k, 
    /// return whether any two numbers from the list add up to k
    /// 
    /// For example, given [10, 15, 3, 7] and k of 17, return true since
    /// 10 + 7 == 17
    /// 
    /// Bonus, can you do this in one pass? 
    /// </summary>
    /// <param name="k">The number looked for through addition of two numbers in the list</param>
    /// <param name="list">The search list of given numbers</param>
    /// <returns>bool</returns>
    public static bool CanMakeNrKFromAdditionOfTwoNrsInList(int k, List<int> list) {
        
        foreach (int n in list) {
            int needed = k - n;
            if (needed == 0) { continue; }
            if (list.Exists(tmp => tmp == needed)) {
                return true;
            }
        }

        return false;
    }
}
