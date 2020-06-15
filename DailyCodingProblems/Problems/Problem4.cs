namespace DailyCodingProblems {
    /// <summary>
    /// Problem #4
    /// Date    14-06-2020
    /// 
    /// This problem was asked by Stripe.
    /// 
    /// Given an array of integers, find the first missing positive integer in linear time and 
    /// constant space. In other words, find the lowest positive integer that does not exist 
    /// in the array. The array can contain duplicates and negative numbers as well.
    /// 
    /// For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.
    /// 
    /// You can modify the input array in-place.
    /// </summary>
    public class Problem4 {

        public static int FindFirstMissingPossitiveInteger(int[] integers) {

            // 1. sort the array, i think the rest will be much less complicated that way.
            SortArray(integers);

            // 2. loop through the array finding zero or the first positive integer
            for(int i = 0; i < integers.Length - 1; i++) {
                if (IsPositiveInteger(integers[i])) {

                    // 3. Find out if the integer that comes after the first positive integer
                    //    is the next in the link, if not then we have found our integer.
                    if(!IsNextPositiveInteger(integers[i], integers[i + 1])) {
                        return integers[i] + 1;
                    }
                }
            }

            // 4. If by this point we've found no next positive integer then the next integer
            //    is the last indexed integer + 1.
            return integers[integers.Length - 1] + 1;
        }

        /// <summary>
        /// Insertion sort algorithm
        /// </summary>
        /// <param name="integers"></param>
        public static void SortArray(int[] integers) {

            int N = integers.Length;

            for(int i = 0; i < N; i++) {
                int min = i;
                for (int j = i+1; j < N; j++) {
                    if(IsLess(integers[j], integers[min])) {
                        min = j;
                    }
                    int tmp = integers[i];
                    integers[i] = integers[min];
                    integers[min] = tmp;
                    min = i;
                }
            }
        }
        
        public static bool IsLess(int a, int b) {
            return (a < b);
        }

        public static bool IsPositiveInteger(int integer) {

            return (integer > 0);
        }

        public static bool IsNextPositiveInteger(int currentInteger, int nextPositiveInteger) {

            return ((currentInteger + 1) == nextPositiveInteger);
        }

    }

}