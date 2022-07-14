namespace JustDsaSharp.Sorting.SelectionSort
{
    public interface ISelectionSorting
    {
        TInput Sort<TInput,TValue>(TInput input,Func<TValue,TValue,bool> areSorted);
    }
}