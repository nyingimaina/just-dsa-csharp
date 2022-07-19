

using System.Collections;
using JustDsaSharp.DataStructures.LinkedLists;

namespace JustDsaSharp.Sorting.SelectionSort
{
    public class SelectionSorting
    {
        /// <summary>
        /// Entry point for selection sorting of data structures.
        /// For supported data structures, this method will perform selection sort and return the result.
        /// </summary>
        /// <param name="input">The input to be sorted</param>
        /// <param name="areSorted">Comparer function to be called with two values to allow testing if they meet the desired sorting criteria</param>
        /// <typeparam name="TInput">Type of the input</typeparam>
        /// <typeparam name="TValue">If <paramref name="input"/> is generic, then the type of the of data it holds</typeparam>
        /// <returns>The sorted output from the input provided</returns>
        public TInput Sort<TInput,TValue>(TInput input, Func<TValue,TValue,bool> areSorted)
        {
            if(input == null)
            {
                throw new NullReferenceException($"Input provided to SelectionSort is Null");
            }
            var sortWorkers = new Dictionary<string, Func<ISelectionSorting>>
            {
                { GetTypeKey(typeof(SinglyLinkedList<>)), () => new SinglyLinkedListSelectionSort() },
                { GetTypeKey(typeof(object[])), () => new NativeListSelectionSorting() },
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
            var implementsIList = typeof(IList).IsAssignableFrom(type);
            if(implementsIList)
            {
                return typeof(IList).FullName!;
            }
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