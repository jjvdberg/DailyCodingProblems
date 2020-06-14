public class Problem2 {

    /// <summary>
    /// Problem #2 
    /// Date 20200612
    /// 
    /// Given an array of integers, return a new array 
    /// such that each element at index i of the new array is the product of 
    /// all the numbers in the original array except the one at i.
    /// 
    /// For example, if our input was[1, 2, 3, 4, 5], the expected output would be
    /// [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be[2, 3, 6].
    /// 
    /// Follow-up: what if you can't use division?
    /// 
    /// </summary>
    /// <param name="input">given Array of numbers</param>
    /// <returns>Array with product of input numbers except i</returns>
    public static int[] OutputArrayWithMultiplesOfInputExceptI(int[] input) {

        int[] output = new int[input.Length];
        
        for(int i = 0; i < input.Length; i++) {

            if(input.Length % 2 != 0) {
                // With uneven arrays the middle index will be left out because of the 
                // nature of the helper algorithm, we can make use of this by
                // swapping the current index with the middle.

                // 1. swap the current index for the middle index
                SwapMiddleOfUnevenArray(input, i);

                // 2. calculate
                output[i] = CalculateCurrentOutputItem(input);

                // 3. swap back so not to disturb the next itteration
                SwapMiddleOfUnevenArray(input, i);

            } else {
                // With even arrays all objects will be calculated because of the nature
                // of the helper algorithm. so we'll have to take measures to not calculate 
                // the current index. This is achieved by replacing the current index with zero
                // and replacing the current index (which is now zero) with the last index
                
                // 1. store the current index
                int tmp = input[i];

                // 2. replace the current index with zero 
                input[i] = 0;

                // 3. swap the current index with the last index
                SwapLastOfEvenArray(input, i);

                // 4. calculate
                output[i] = CalculateCurrentOutputItem(input);

                // 5. swap back for the next itteration
                SwapLastOfEvenArray(input, i);

                // 6. restore the current index
                input[i] = tmp;
            }
        }
        return output;
    }

    public static void SwapLastOfEvenArray(int[] evenArray, int indexToSwapWithLast) {
        int len = evenArray.Length;
        int tmp = evenArray[len - 1];
        evenArray[len - 1] = evenArray[indexToSwapWithLast];
        evenArray[indexToSwapWithLast] = tmp;
    }

    public static void SwapMiddleOfUnevenArray(int[] unevenArray, int indexToSwapWithMiddle) {

        int len = unevenArray.Length;
        int middle = len / 2;
        int tmp = unevenArray[middle];
        unevenArray[middle] = unevenArray[indexToSwapWithMiddle];
        unevenArray[indexToSwapWithMiddle] = tmp;
    }

    /// <summary>
    /// Algorithm for calculating the current output item of given input[]
    /// The output item is the product of all items except 1. 
    /// With uneven arrays the middle item is left out.
    /// With even arrays you should take measures to leave 1 item out, this can be achieved by
    /// replacing the desired left out item with 0 (see case 2 in the switch statement)
    /// and swapping that zero with either the last index or index 1.
    /// </summary>
    /// <param name="input">array of integers</param>
    /// <returns>product of all items except 1.</returns>
    public static int CalculateCurrentOutputItem(int[] input) {

        int[] topHalf;
        int[] bottomHalf;
        int length = input.Length;

        switch (length) {
            case 1:
                return input[0];

            case 2:
                if (input[1] == 0) {
                    return CalculateCurrentOutputItem(new int[1] { input[0] });
                } 
                
                return input[0] * input[1];

            case 6:
                if (input[length - 1] == 0) {
                    // special case.
                    // here we make 1 4 lenghted array, the top half
                    int topLength = length / 2 + 1;
                    topHalf = new int[topLength];
                    // and 1 3 lengthed array, the bottom
                    int bottomLength = length / 2;
                    bottomHalf = new int[bottomLength];
                    for (int i = 0; i < length / 2; i++) {
                        topHalf[i] = input[i];
                        bottomHalf[bottomLength - i - 1] = input[length - i - 1];
                    }
                    // place zero in the last index of the top half
                    topHalf[topLength - 1] = 0;
                    // swap the middle of the bottom half with the last index
                    SwapMiddleOfUnevenArray(bottomHalf, 2);
                } else {
                    // here we make 2 4 lenghted arrays, with the last index being zero.
                    int subLength = length / 2 + 1;
                    topHalf = new int[subLength];
                    topHalf[subLength - 1] = 0;
                    bottomHalf = new int[subLength];
                    bottomHalf[subLength - 1] = 0;
                    // fill up the rest of the arrays.
                    for (int i = 0; i < length / 2; i++) {
                        topHalf[i] = input[i];
                        bottomHalf[subLength - i - 2] = input[length - i - 1];
                    }
                }
                break;

            default:
                int halfLength = length / 2;
                topHalf = new int[halfLength];
                bottomHalf = new int[halfLength];
                for (int i = 0; i < halfLength; i++) {
                    topHalf[i] = input[i];
                    bottomHalf[halfLength - i - 1] = input[length - i - 1];
                }
                break;
        }

        return CalculateCurrentOutputItem(topHalf) * CalculateCurrentOutputItem(bottomHalf);
    }
}