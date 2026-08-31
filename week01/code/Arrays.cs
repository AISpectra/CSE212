public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // 1. Create a new array that has exactly enough room for the requested number of multiples.
        // 2. Loop through each position in the array from the first index to the last index.
        // 3. For each position, multiply the original number by the multiple number for that position.
        // 4. Store the calculated multiple in the current array position.
        // 5. Return the completed array after all positions have been filled.
        var multiples = new double[length];

        for (var i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // 1. Find the index where the rotated list should begin.
        // 2. Copy the values from that starting index to the end of the list.
        // 3. Copy the values from the beginning of the list up to the starting index.
        // 4. Clear the original list so it can be rebuilt in the rotated order.
        // 5. Add the ending values first, then add the beginning values after them.
        var startIndex = data.Count - amount;
        var endValues = data.GetRange(startIndex, amount);
        var beginningValues = data.GetRange(0, startIndex);

        data.Clear();
        data.AddRange(endValues);
        data.AddRange(beginningValues);
    }
}
