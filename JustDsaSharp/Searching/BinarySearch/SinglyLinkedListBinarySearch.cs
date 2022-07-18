
using JustDsaSharp.DataStructures.LinkedLists;

namespace JustDsaSharp.Searching.BinarySearch
{
    /// <summary>
    /// Performs a binary search on a sorted by ascending value <see cref="SinglyLinkedList{TValue}"/>
    /// Time Complexity is O(N * logN) as we need to run a O(N) operation to get the count of nodes, then proceed 
    /// to do the O(logN) binary search.
    /// </summary>
    public class SinglyLinkedListBinarySearch
    {
        /// <summary>
        /// Takes in a sorted <see cref="SinglyLinkedList{TValue}"/> and performs a binary search on it,
        /// and returns a <see cref="SearchResult{TResult}"/> object if the value is found, or null if
        /// it is not.
        /// </summary>
        /// <param name="input!!">The input <see cref="SinglyLinkedList{TValue}"/> to search from.</param>
        /// <param name="comparer">This is a function that is called with a single value, to allow you to compare if it matches the target value you are searching for.</param>
        /// <typeparam name="TInput">This will always be <see cref="SinglyLinkedList{TValue}"/>.</typeparam>
        /// <typeparam name="TValue">The type of the value held in the nodes of <see cref="SinglyLinkedList{TValue}"/>.</typeparam>
        /// <returns>If search value was found, then we return a search result object containing the <see cref="SinglyLinkedList{TValue}"/>
        /// with the search result as its head, as well as the index at which the node was found.
        /// If no match was found, then null is returned.
        /// </returns>
        public SearchResult<TInput>? Search<TInput,TValue>(
            TInput? input,
            Func<TValue?,ComparisonResult> comparer
            )
        {
            if(input == null)
            {
                return null;
            }
            var singlyLinkedList = input as SinglyLinkedList<TValue>;
            if(singlyLinkedList == null)
            {
                throw new NullReferenceException($"Could not convert input into {nameof(SinglyLinkedList<TValue>)}");
            }
            var nodeCount = singlyLinkedList.Count();
            return DoSearch<TInput, TValue>(
                singlyLinkedList.Head,
                comparer,
                0,
                nodeCount,
                nodeCount
            );
        }

        private SearchResult<TInput>? DoSearch<TInput,TValue>(
            DataStructures.LinkedLists.LinkedListNode<TValue> startNode!!,
            Func<TValue?,ComparisonResult> comparer,
            long startIndex,
            long endIndex,
            long nodeCount)
        {
            var midPoint = (int)Math.Floor((decimal)(endIndex + startIndex) / 2);
            var currentIndex = startIndex;
            var currentNode = startNode;
            while(endIndex > 0 && currentIndex <= midPoint && currentNode!.IsTail == false)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }
            if(currentNode == null)
            {
                return null;
            }
            var comparisonResult = comparer(currentNode.Value);
            switch(comparisonResult)
            {
                case ComparisonResult.SearchValueIsLessThanCandidateValue:
                    if(currentIndex == 0)
                    {
                        return null;
                    }
                    else
                    {
                        var nextEndIndex = midPoint == endIndex ? midPoint - 1 : midPoint;
                        if(nextEndIndex < 0)
                        {
                            return null;
                        }
                        else
                        {
                            return DoSearch<TInput, TValue>(
                                startNode,
                                comparer,
                                startIndex,
                                midPoint,
                                nodeCount
                            );
                        }
                    }
                case ComparisonResult.SearchValueIsGreaterThanCandidateValue:
                    var nextStartIndex = currentIndex == startIndex ? currentIndex + 1 : currentIndex;
                    if (nextStartIndex < nodeCount)
                    {
                        return DoSearch<TInput, TValue>(
                            currentNode,
                            comparer,
                            nextStartIndex,
                            endIndex,
                            nodeCount
                        );
                    }
                    else
                    {
                        return null;
                    }
                case ComparisonResult.SearchValueEqualToCandidateValue:
                    return new SearchResult<TInput>
                    {
                        Result = (TInput)(object)new SinglyLinkedList<TValue>(currentNode),
                        ResultIndex = currentIndex
                    };
                default:
                    throw new InvalidComparisonResultException($"Invalid search result '{comparisonResult}'");
            }

        }
    }
}