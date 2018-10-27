namespace LeetCode_CSharp
{
    public class Node
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="value"></param>
        public Node(int value)
        {
            this.Value = value;
        }

        /// <summary>
        /// The int value of the node
        /// </summary>
        internal int Value { get; set; }

        /// <summary>
        /// The previous node
        /// </summary>
        internal Node Prev { get; set; }

        /// <summary>
        /// The next node
        /// </summary>
        internal Node Next { get; set; }

        /// <summary>
        /// The previous min node before marking this node as min node
        /// </summary>
        internal Node PrevMinNode { get; set; }
    }

    /// <summary>
    /// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
    /// push(x) -- Push element x onto stack.
    /// pop() -- Removes the element on top of the stack.
    /// top() -- Get the top element.
    /// getMin() -- Retrieve the minimum element in the stack.
    /// </summary>
    public class MinStack
    {
        /// <summary>
        /// The head of the min stack
        /// </summary>
        Node Head { get; set; }

        /// <summary>
        /// The node which has the min value in the stack
        /// </summary>
        Node Min { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        public MinStack()
        {
        }

        /// <summary>
        /// Push a node with an int value to the min stack
        /// </summary>
        /// <param name="x">the int value to be pushed</param>
        public void Push(int x)
        {
            if (this.Head == null)
            {
                this.Head = new Node(x);
                this.Min = this.Head;
            }
            else
            {
                Node node = new Node(x);
                this.Head.Prev = node;
                node.Next = this.Head;
                this.Head = node;

                /// If this int value is less than the current min value
                /// Set the current min node as the previous min node of this value node
                /// And update the current min node
                if (node.Value < this.Min.Value)
                {
                    node.PrevMinNode = this.Min;
                    this.Min = node;
                }
            }
        }

        public void Pop()
        {
            if (this.Head == null)
            {
                return;
            }

            /// If the head is the min node
            /// Update the min node to the previous min node of the head
            /// Reading: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-test-for-reference-equality-identity
            if (this.Min == this.Head)
            {
                this.Min = this.Head.PrevMinNode;
            }

            this.Head = this.Head.Next;
        }

        public int Top()
        {
            return this.Head.Value;
        }

        public int GetMin()
        {
            return this.Min.Value;
        }
    }
}
