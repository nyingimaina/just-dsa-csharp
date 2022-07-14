using JustDsaSharp.DataStructures.LinkedLists;
using Xunit;

namespace JustDsaSharpTests.DataStructures.LinkedLists
{
    public class SinglyLinkedListTests
    {
        [Fact]
        public void InitializationWorksCorrectly ()
        {
            var headerValue = Guid.NewGuid ();
            var list = new SinglyLinkedList<Guid> (headerValue);

            Assert.Equal (headerValue, list.Head.Value);
            Assert.Null (list.Head.Next);
        }

        [Fact]
        public void PrependingWorks ()
        {
            const int itemsToPrependCount = 3;
            var list = new SinglyLinkedList<int> (1);

            Action throwNullNodeException = () =>
                throw new Exception ("Node should not be null in this list. Check implementation of linked list");

            for (int i = 2; i <= itemsToPrependCount; i++)
            {
                list.Prepend (i);
            }

            var currentNode = list.Head;
            for (int i = itemsToPrependCount; i >= 1; i--)
            {
                if (currentNode != null)
                {
                    Assert.Equal (i, currentNode.Value);
                    if (i > 1)
                    {
                        currentNode = currentNode.Next;
                    }
                }
                else
                {
                    throwNullNodeException ();
                }
            }
            if (currentNode == null)
            {
                throwNullNodeException ();
            }
            else
            {
                Assert.True (currentNode.IsTail);
            }
        }

        [Fact]
        public void NodeSwappingNonAdjacentNodesWorks()
        {
            var singlyLinkedList = new SinglyLinkedList<int>(1)
                .Prepend(2)
                .Prepend(3)
                .Prepend(4)
                .Prepend(5);

            var node2 = singlyLinkedList.Head.Next!.Next!.Next!;
            var node4 = singlyLinkedList.Head.Next!;
            var node2Parent = singlyLinkedList.Head.Next!.Next!;
            var node4Parent = singlyLinkedList.Head;

            singlyLinkedList.SwapNodes(node2, node4, node2Parent, node4Parent);

            Assert.Equal(2,singlyLinkedList.Head.Next!.Value);
            Assert.Equal(4, singlyLinkedList.Head.Next!.Next!.Next!.Value);
        }

        [Fact]
        public void NodeSwappingAdjacentNodesWorks()
        {
            var singlyLinkedList = new SinglyLinkedList<int>(1)
                .Prepend(2)
                .Prepend(3)
                .Prepend(4);

            var node2 = singlyLinkedList.Head.Next!.Next!;
            var node3 = singlyLinkedList.Head.Next!;
            var node2Parent = node3;
            var node3Parent = singlyLinkedList.Head;

            singlyLinkedList.SwapNodes(node2, node3, node2Parent, node3Parent);

            Assert.Equal(2,singlyLinkedList.Head.Next!.Value);
            Assert.Equal(4, singlyLinkedList.Head.Next!.Next!.Next!.Value);
        }
    }
}