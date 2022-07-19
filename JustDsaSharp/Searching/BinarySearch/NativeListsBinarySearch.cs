namespace JustDsaSharp.Searching.BinarySearch
{
    public class NativeListsBinarySearch : IBinarySearching
    {
        public SearchResult<TInput>? Search<TInput, TValue>(TInput? input, Func<TValue?, ComparisonResult> comparer)
        {
            throw new NotImplementedException();
        }
    }
}