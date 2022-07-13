namespace JustDsaSharp.DataStructures.LinkedLists
{
    /// <summary>
    /// Optionally contains the value of the current node as well as a pointer to the next node
    /// </summary>
    /// <typeparam name="TValue">Type of the data held by the node</typeparam>
    public class LinkedListNode<TValue>
    {
        /// <summary>
        /// Gets or sets the value held by the node. This property is nullable.
        /// </summary>
        public TValue? Value { get; set; }

        /// <summary>
        /// Gets or sets pointer to the next node in the chain. This property is nullable.
        /// </summary>
        public LinkedListNode<TValue>? Next { get; set; }

        /// <summary>
        /// Gets a value indicating whether this is the last node in the chain.
        /// Only returns true if <see cref="Next"/> is null.
        /// </summary>
        public bool IsTail => Next == null;
    }
}