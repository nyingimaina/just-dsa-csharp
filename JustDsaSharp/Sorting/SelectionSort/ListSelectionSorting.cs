using System.Collections;

namespace JustDsaSharp.Sorting.SelectionSort
{
    public class ListSelectionSorting : ISelectionSorting
    {
        public TInput Sort<TInput, TValue>(TInput input!!, Func<TValue, TValue, bool> areSorted)
        {
            var list = (IList)input;
            var sorted = DoSort(list, areSorted, 0);
            return (TInput)sorted;
        }

        private IList DoSort<TValue>(
            IList list, 
            Func<TValue, TValue, bool> areSorted,
            int unsortedStartIndex)
        {
            var unsortedValue = (TValue) list[unsortedStartIndex]!;
            var indexToSwapWith = unsortedStartIndex;
            var swappingRequired = false;
            for (int i = unsortedStartIndex + 1; i < list.Count; i++)
            {
                var valueToCompare = (TValue)list[i]!;
                if(areSorted( unsortedValue, valueToCompare) == false)
                {
                    if (areSorted(valueToCompare, (TValue)list[indexToSwapWith]!))
                    {
                        swappingRequired = true;
                        indexToSwapWith = i;
                    }
                }
            }

            if (swappingRequired)
            {
                list[unsortedStartIndex] = list[indexToSwapWith];
                list[indexToSwapWith] = unsortedValue;
            }
            var isAtEndOfList = unsortedStartIndex == list.Count - 1;
            if(isAtEndOfList)
            {
                return list;
            }
            else
            {
                return DoSort(list, areSorted, ++unsortedStartIndex);
            }
        }
    }
}