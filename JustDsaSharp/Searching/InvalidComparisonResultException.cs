using System.Diagnostics.CodeAnalysis;

namespace JustDsaSharp.Searching
{
    public class InvalidComparisonResultException : Exception
    {
        [ExcludeFromCodeCoverage]
        public InvalidComparisonResultException(string message) : base(message)
        {
        }
    }
}