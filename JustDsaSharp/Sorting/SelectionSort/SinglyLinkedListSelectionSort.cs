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
                var result = DoSorting(singlyLinkedList,areSorted,singlyLinkedList.Head, true);
                var typedResult = (TInput)(object)result;
                return typedResult;
            }
        }

        private SinglyLinkedList<TValue> DoSorting<TValue>(
            SinglyLinkedList<TValue> singlyLinkedList, 
            Func<TValue,TValue,bool> areSorted,
            DataStructures.LinkedLists.LinkedListNode<TValue> unSortedStartParent,
            bool isAtHead)
        {
            var unSortedStart = isAtHead ? unSortedStartParent : unSortedStartParent.Next;

            if (unSortedStart != null && unSortedStart.Next != null)
            {
                DataStructures.LinkedLists.LinkedListNode<TValue> nodeToSwap = unSortedStart;
                DataStructures.LinkedLists.LinkedListNode<TValue> nodeToSwapParent = unSortedStart;
                DataStructures.LinkedLists.LinkedListNode<TValue> previousNode = unSortedStart;
                var currentNode = unSortedStart.Next;
                var swappingRequired = false;
                while (currentNode != null)
                {
                    if (currentNode.Value == null || unSortedStart.Value == null || nodeToSwap.Value == null)
                    {
                        throw new Exception("Sorting null values is currently not supported");
                    }
                    if (areSorted(unSortedStart.Value, currentNode.Value) == false)
                    {
                        swappingRequired = true;
                        if (areSorted(nodeToSwap.Value, currentNode.Value) == false)
                        {
                            nodeToSwap = currentNode;
                            nodeToSwapParent = previousNode;
                        }
                    }
                    previousNode = currentNode;
                    currentNode = currentNode.Next;
                }
                if(!swappingRequired)
                {
                    return singlyLinkedList;
                }
                else
                {
                    if (isAtHead == false)
                    {
                        singlyLinkedList.SwapNodes(nodeToSwap, unSortedStart, nodeToSwapParent, unSortedStartParent);
                    }
                    else
                    {
                        singlyLinkedList.Head = nodeToSwap;
                        var nodeToSwapNext = nodeToSwap.Next;
                        nodeToSwap.Next = unSortedStart.Next;
                        nodeToSwapParent.Next = unSortedStart;
                        unSortedStart.Next = nodeToSwapNext;
                    }


                    return DoSorting(
                        singlyLinkedList,
                        areSorted,
                        nodeToSwap,
                        false
                    );
                }
            }
            return singlyLinkedList;
        }
    }
}