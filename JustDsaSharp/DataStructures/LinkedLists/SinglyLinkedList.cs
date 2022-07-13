namespace JustDsaSharp.DataStructures.LinkedLists
{
    /// <summary>
    /// Collection of one or more linked nodes.
    /// </summary>
    /// <typeparam name="TValue">The type of data the nodes hold</typeparam>
    public class SinglyLinkedList<TValue>
    {
        /// <summary>
        /// Gets the first node in the linked list;
        /// </summary>
        public LinkedListNode<TValue> Head { get; private set; }

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
        /// Adds a node to the head of the list, and then links to the previous head.
        /// Time Complexity O(1), as reference to current head is known.
        /// </summary>
        /// <param name="value">The value to be contained in the head.</param>
        public void Prepend (TValue value)
        {
            var newHead = new LinkedListNode<TValue>
            {
                Next = this.Head,
                Value = value,
            };
            this.Head = newHead;
        }
    }
}