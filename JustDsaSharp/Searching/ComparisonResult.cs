namespace JustDsaSharp.Searching
{
    /// <summary>
    /// An enum to allow for proper description of results when a comparison of
    /// value being searched for, against a 'candidate' value is done.
    /// </summary>
    public enum ComparisonResult : byte
    {
        /// <summary>
        /// Indicates that the value being searched for is less that the candidate value.
        /// </summary>
        SearchValueIsLessThanCandidateValue = 1,

        /// <summary>
        /// Indicates that search value and candidate value are equal.
        /// </summary>
        SearchValueEqualToCandidateValue = 2,

        /// <summary>
        /// Indicates that search value is greater than candidate value.
        /// </summary>
        SearchValueIsGreaterThanCandidateValue = 3
    }
}