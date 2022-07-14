using JustDsaSharp.Sorting.SelectionSort;
using Xunit;

namespace JustDsaSharpTests.Sorting.SelectionSort
{
    public class ArraySelectionSortTests
    {
        [Fact]
        public void SortAscendingWorks()
        {
            var unsortedArray = new int[] { 9, 1, 8, 4, 7, 2, 3 };
            var sortedArray = new SelectionSorting().Sort<int[],int>(unsortedArray, (left, right) => left <= right);

            Assert.Equal(unsortedArray.Length, sortedArray.Length);
            for (int i = 0; i < unsortedArray.Length - 1; i++)
            {
                Assert.True(unsortedArray[i] < unsortedArray[i + 1]);
            }
        }
    }
}