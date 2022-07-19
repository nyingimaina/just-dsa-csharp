using JustDsaSharp.Sorting.SelectionSort;
using Xunit;

namespace JustDsaSharpTests.Sorting.SelectionSort
{
    public class ArraySelectionSortTests
    {
        [Fact]
        public void SortAscendingWorks()
        {
            var unsortedArray = new int[] { 9, 1, 8, 4, 1, 7, 2, 3 };
            var sortedArray = new SelectionSorting().Sort<int[],int>(unsortedArray, (left, right) => left <= right);

            for (int i = 0; i < sortedArray.Length - 1; i++)
            {
                Assert.True(sortedArray[i] <= sortedArray[i + 1]);
            }
        }
    }
}