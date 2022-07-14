using JustDsaSharp.DataStructures.LinkedLists;
using JustDsaSharp.Sorting.SelectionSort;

namespace JustDsaSharpTests.Sorting.SelectionSort
{
    public class SinglyLinkedListSelectionSortTests
    {
        [Fact]
        public void SortAscendingWorks()
        {
            var unsortedList = new SinglyLinkedList<int>(11)
                .Prepend(22)
                .Prepend(12)
                .Prepend(25)
            .Prepend(565)
            .Prepend(5);  /*
            .Prepend(7)
            .Prepend(4934)
            .Prepend(8)
            .Prepend(33)
            .Prepend(22);*/

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