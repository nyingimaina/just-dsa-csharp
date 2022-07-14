

using JustDsaSharp.DataStructures.LinkedLists;

namespace JustDsaSharp.Sorting.SelectionSort
{
    public class SelectionSorting
    {
        public TInput Sort<TInput,TValue>(TInput input, Func<TValue,TValue,bool> areSorted)
        {
            if(input == null)
            {
                throw new NullReferenceException($"Input provided to SelectionSort is Null");
            }
            var sortWorkers = new Dictionary<string, Func<ISelectionSorting>>
            {
                { GetTypeKey(typeof(SinglyLinkedList<>)), () => new SinglyLinkedListSelectionSort() }
            };

            var typeOfInput = GetTypeKey(typeof(TInput));

            if(sortWorkers.ContainsKey(typeOfInput))
            {
                var worker = sortWorkers[typeOfInput]();
                return worker.Sort(input, areSorted);
            }
            else
            {
                throw new Exception($"Unsupported Data Structure with type '{typeof(TInput).Name}'");
            }
        }
        
        private string GetTypeKey(Type type)
        {
            if(type.FullName == null)
            {
                throw new Exception($"Full name for type '{type.Name}' could not be determined");
            }
            var indexOfChar = type.FullName.IndexOf('`');
            if(indexOfChar > -1)
            {
                return type.FullName.Substring(0, indexOfChar);
            }
            else
            {
                return type.FullName;
            }
        }
    }
}