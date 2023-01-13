namespace Binary_Tree_Task
{
    public class BinaryTreeNode<T> where T : IComparable<T>
    {
        public BinaryTreeNode()
        {
        }

        public BinaryTreeNode(BinaryTreeNode<T> parent)
        {
            Parent = parent;
        }

        public BinaryTreeNode(BinaryTreeNode<T> parent, T item) : this(parent)
        {
            Value = item;
        }

        public BinaryTreeNode(BinaryTreeNode<T> parent, T item, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
            : this(parent, item)
        {
            Left = left;
            Right = right;
        }

        public BinaryTreeNode<T>? Parent { get; set; }

        public BinaryTreeNode<T>? Left { get; set; }

        public BinaryTreeNode<T>? Right { get; set; }

        public T? Value { get; set; }

        public int Height
        {
            get
            {
                var parent = Parent;
                int height = 1;
                while (parent != null)
                {
                    parent = parent.Parent;
                    height++;
                }

                return height;
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}