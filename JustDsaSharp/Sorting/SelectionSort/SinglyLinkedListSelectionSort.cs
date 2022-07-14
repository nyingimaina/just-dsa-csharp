using JustDsaSharp.DataStructures.LinkedLists;

namespace JustDsaSharp.Sorting.SelectionSort
{
    public class SinglyLinkedListSelectionSort : ISelectionSorting
    {
        public TInput Sort<TInput,TValue>(TInput input,Func<TValue,TValue,bool> areSorted)
        {
            var singlyLinkedList = input as SinglyLinkedList<TValue>;
            if(singlyLinkedList == null)
            {
                throw new NullReferenceException($"Could not convert input into {nameof(SinglyLinkedList<TValue>)}");
            }
            else
            {
                var result = DoSorting(singlyLinkedList,areSorted,singlyLinkedList.Head);
                var typedResult = (TInput)(object)result;
                return typedResult;
            }
        }

        private SinglyLinkedList<TValue> DoSorting<TValue>(
            SinglyLinkedList<TValue> singlyLinkedList, 
            Func<TValue,TValue,bool> areSorted,
            DataStructures.LinkedLists.LinkedListNode<TValue> unSortedStartParent)
        {
            var unSortedStart = unSortedStartParent.Next;
            if(unSortedStart != null)
            {
                var currentNode = unSortedStart.Next;
                if (currentNode != null && currentNode.Next != null)
                {
                    if (currentNode.Value == null || unSortedStart.Value == null)
                    {
                        throw new Exception("Sorting null values is currently not supported");
                    }
                    if(areSorted(unSortedStart.Value,currentNode.Value) == false)
                    {
                        var temp = unSortedStart;
                        if(unSortedStartParent != null)
                        {
                            unSortedStartParent.Next = currentNode;
                        }
                        else
                        {
                            singlyLinkedList.Head = currentNode;
                        }
                        unSortedStart.Next = currentNode.Next;
                        currentNode.Next = unSortedStart;
                        return DoSorting(
                            singlyLinkedList,
                            areSorted,
                            currentNode
                        );
                    }
                }
            } 
            return singlyLinkedList;
        }
    }
}