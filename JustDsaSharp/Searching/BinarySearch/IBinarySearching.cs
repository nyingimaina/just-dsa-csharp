namespace JustDsaSharp.Searching.BinarySearch
{
    public interface IBinarySearching
    {
        /// <summary>
        /// Definition for how entry methods into the binary search should look like.
        /// This allows for a standardized caller to correctly route search of supported 
        /// data types to the appropriate worker class.
        /// </summary>
        /// <param name="input">The input container which will be searched in.</param>
        /// <param name="comparer">A comparer function that will determine if a candidate value matches value being searched for.</param>
        /// <typeparam name="TInput">Type of input data structure.</typeparam>
        /// <typeparam name="TValue">Type of data held in the data structure</typeparam>
        /// <returns></returns>
        SearchResult<TInput>? Search<TInput, TValue>(TInput? input, Func<TValue?, ComparisonResult> comparer);
    }
}