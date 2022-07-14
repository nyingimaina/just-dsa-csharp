using JustDsaSharp.DataStructures.LinkedLists;
using JustDsaSharp.Sorting.SelectionSort;

namespace JustDsaSharpTests.Sorting.SelectionSort
{
    public class SinglyLinkedListSelectionSortTests
    {
        [Fact]
        public void SortAscendingWorks()
        {
            var unsortedList = new SinglyLinkedList<int>(12)
                .Prepend(25)
                .Prepend(64);

            var sortedList = new SelectionSorting()
                .Sort<SinglyLinkedList<int>,int>(
                    unsortedList,
                    (leftNodeValue,rightNodeValue) => 
                    {
                        return leftNodeValue < rightNodeValue;
                    });
            var currentNode = sortedList.Head;
            while(currentNode.Next != null)
            {
                Assert.True(currentNode.Value < currentNode.Next.Value);
                currentNode = currentNode.Next;
            }
        }
    }
}