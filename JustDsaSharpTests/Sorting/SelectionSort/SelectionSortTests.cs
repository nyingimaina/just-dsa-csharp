using JustDsaSharp.DataStructures.LinkedLists;
using JustDsaSharp.Sorting.SelectionSort;

namespace JustDsaSharpTests.Sorting.SelectionSort
{
    public class SelectionSortTests
    {
        [Fact]
        public void SinglyLinkedListsAreRoutedCorrectly()
        {
            var selectionSorting = new SelectionSorting();
            var result = selectionSorting.Sort<SinglyLinkedList<int>,int>(new SinglyLinkedList<int>(1),(_, __) => true);
            Assert.NotNull(result);
        }
    }
}