namespace JustDsaSharp.DataStructures.LinkedLists
{
    /// <summary>
    /// Collection of one or more linked nodes.
    /// </summary>
    /// <typeparam name="TValue">The type of data the nodes hold</typeparam>
    public class SinglyLinkedList<TValue>
    {
        /// <summary>
        /// Gets or sets the first node in the linked list;
        /// </summary>
        public LinkedListNode<TValue> Head { get; set; }

        /// <summary>
        /// Initialize an instance of the singly linked list, allowing you to create the first node node.
        /// Time Complexity O(1).
        /// </summary>
        /// <param name="headValue">The value to be stored in the head of the list.</param>
        public SinglyLinkedList (TValue headValue)
        {
            Head = new LinkedListNode<TValue>
            {
                Value = headValue
            };
        }


        /// <summary>
        /// Initialize an instance of the singly linked list, allowing you to pass in the head
        /// Time Complexity O(1).
        /// </summary>
        /// <param name="head">The head of the list.</param>
        public SinglyLinkedList(LinkedListNode<TValue> head)
        {
            Head = head;
        }

        /// <summary>
        /// Adds a node to the head of the list, and then links to the previous head.
        /// Time Complexity O(1), as reference to current head is known.
        /// </summary>
        /// <param name="value">The value to be contained in the head.</param>
        /// <returns>Handle to itself</returns>
        public SinglyLinkedList<TValue> Prepend (TValue value)
        {
            var newHead = new LinkedListNode<TValue>
            {
                Next = this.Head,
                Value = value,
            };
            this.Head = newHead;
            return this;
        }

        /// <summary>
        /// Swaps the position of two nodes.
        /// </summary>
        /// <param name="nodeOne">First node.</param>
        /// <param name="nodeTwo">Second node.</param>
        /// <param name="nodeOneParent">The parent of the first node.</param>
        /// <param name="nodeTwoParent">The parent of the second node.</param>
        /// <returns>Handle to self</returns>
        public SinglyLinkedList<TValue> SwapNodes(
            LinkedListNode<TValue> nodeOne, 
            LinkedListNode<TValue> nodeTwo, 
            LinkedListNode<TValue> nodeOneParent,
            LinkedListNode<TValue> nodeTwoParent)
        {
            var nodesAreAdjacent = nodeOne.Next == nodeTwo || nodeTwo.Next == nodeOne;
            Action<LinkedListNode<TValue>, LinkedListNode<TValue>, LinkedListNode<TValue>, LinkedListNode<TValue>> swap;
            if(nodesAreAdjacent)
            {
                swap = SwapAdjacentNodes;
            }
            else
            {
                swap = SwapNonAdjacentNodes;
            }
            swap(
                nodeOne,
                nodeTwo,
                nodeOneParent,
                nodeTwoParent
            );
            return this;
        }

        /// <summary>
        /// Returns the number of nodes in the linked list.
        /// Time Complexity O(n) as requires traversing the whole list.
        /// </summary>
        /// <returns>Returns the number of nodes in the linked list.</returns>
        public long Count()
        {
            long count = 0;
            var currentNode = Head;
            while(currentNode != null)
            {
                count++;
                currentNode = currentNode.Next;
            }
            return count;
        }

        private void SwapNonAdjacentNodes(
            LinkedListNode<TValue> nodeOne, 
            LinkedListNode<TValue> nodeTwo, 
            LinkedListNode<TValue> nodeOneParent,
            LinkedListNode<TValue> nodeTwoParent)
        {
            var nodeOneGrandChild = nodeOne.Next;
            var nodeTwoGrandChild = nodeTwo.Next;

            Action<LinkedListNode<TValue>, LinkedListNode<TValue>, LinkedListNode<TValue>?> attach = (parent, child, grandChild) =>
            {
                child.Next = grandChild;
                parent.Next = child;
            };

            attach(nodeTwoParent, nodeOne, nodeTwoGrandChild);
            attach(nodeOneParent, nodeTwo, nodeOneGrandChild);
        }

        private void SwapAdjacentNodes(
            LinkedListNode<TValue> nodeOne, 
            LinkedListNode<TValue> nodeTwo, 
            LinkedListNode<TValue> nodeOneParent,
            LinkedListNode<TValue> nodeTwoParent)
        {
            if(nodeOne.Next == nodeTwo)
            {
                nodeOneParent.Next = nodeTwo;
                nodeOne.Next = nodeTwo.Next;
                nodeTwo.Next = nodeOne;
            }
            else
            {
                SwapAdjacentNodes(nodeTwo, nodeOne, nodeTwoParent, nodeOneParent);
            }
        }


    }
}