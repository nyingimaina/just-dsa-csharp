using System.Diagnostics.CodeAnalysis;

namespace JustDsaSharp.Searching
{
    /// <summary>
    /// Object that describes the result of a search.
    /// </summary>
    /// <typeparam name="TResult">The type of value to be returned by the search</typeparam>
    [ExcludeFromCodeCoverage]
    public class SearchResult<TResult>
    {
        
        /// <summary>
        /// Gets or sets the value being searched for, if it was found.
        /// If value was not found, then this property is null.
        /// </summary>
        public TResult? Result { get; set; }

        /// <summary>
        /// Gets a value indicating whether a value is missing.
        /// Returns true if the value is missing, or false if the value was found.
        /// </summary>
        public bool NotFound => Result == null;

        /// <summary>
        /// Gets or sets the index of the element at which the searched value was found.
        /// If the searched value was found, index 0 or greater is returned, but if searched
        /// value was not found, then -1 is returned.
        /// </summary>
        public long ResultIndex { get; set; }
    }
}