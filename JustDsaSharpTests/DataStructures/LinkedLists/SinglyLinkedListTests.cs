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
    }
}