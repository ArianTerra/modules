using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Binary_Tree_Task
{
    public class BinaryTree<T>: IEnumerable<T> where T : IComparable<T>
    {
        public BinaryTree()
        {
            Enumerator = new PreOrderEnumerator<T>(this);
            Comparer = Comparer<T>.Default;
        }

        public BinaryTree(IComparer<T> comparer) : this()
        {
            Comparer = comparer;
        }

        public BinaryTreeNode<T>? Root { get; private set; }

        public int Size { get; private set; }

        public int Height => CalculateHeight(Root);

        public IComparer<T> Comparer { get; set; }

        public IEnumerator<T> Enumerator { get; set; }

        /// <summary>
        /// Calculates subtree height.
        /// </summary>
        public static int CalculateHeight(BinaryTreeNode<T>? node)
        {
            if (node == null)
            {
                return 0;
            }

            Queue<BinaryTreeNode<T>> q = new ();
            q.Enqueue(node);

            int height = 0;
            while (q.Count > 0)
            {
                height++;
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    var curr = q.Dequeue();
                    if (curr.Left != null)
                    {
                        q.Enqueue(curr.Left);
                    }

                    if (curr.Right != null)
                    {
                        q.Enqueue(curr.Right);
                    }
                }
            }

            return height;
        }

        public void Add([NotNull] T item)
        {
            BinaryInsertion(item, Comparer);
        }

        public void AddRange([NotNull] IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Searches for a node in a tree and if node is found deletes it.
        /// </summary>
        /// <param name="item">Item to search for and delete</param>
        /// <returns>True if node was deleted, false otherwise</returns>
        public bool Remove(T item)
        {
            var node = GetNode(item);
            if (node != null)
            {
                RemoveAt(node);
            }

            return node != null;
        }

        /// <summary>
        /// Removes a specific node from a tree
        /// </summary>
        /// <param name="node">Node to be removed</param>
        public void RemoveAt([NotNull] BinaryTreeNode<T> node)
        {
            Size--;
            if (node.Left == null)
            {
                ShiftNodes(node, node.Right);
            }
            else if (node.Right == null)
            {
                ShiftNodes(node, node.Left);
            }
            else
            {
                var successor = SuccessorBST(node);
                if (successor.Parent != node)
                {
                    ShiftNodes(successor, successor.Right);
                    successor.Right = node.Right;
                    successor.Right.Parent = node;
                }

                ShiftNodes(node, successor);
                successor.Left = node.Left;
                successor.Left.Parent = successor;
            }
        }

        public bool Contains(T item)
        {
            return Contains(Root, item);
        }

        /// <summary>
        /// Check if subtree contains an item
        /// </summary>
        public bool Contains([NotNull] BinaryTreeNode<T> node, T item)
        {
            return GetNode(node, item) != null;
        }

        public BinaryTreeNode<T>? GetNode(T item)
        {
            return GetNode(Root, item);
        }

        public BinaryTreeNode<T>? GetNode([NotNull] BinaryTreeNode<T> node, T item)
        {
            var current = node;
            while (current != null && !item.Equals(current.Value))
            {
                if (item.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return current;
        }

        public void Clear()
        {
            Root = null;
            Size = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Enumerator.Reset();
            return Enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private static BinaryTreeNode<T> MaximumBST(BinaryTreeNode<T> node)
        {
            var result = node;
            while (result.Right != null)
            {
                result = result.Right;
            }

            return result;
        }

        private static BinaryTreeNode<T> MinimumBST(BinaryTreeNode<T> node)
        {
            var result = node;
            while (result.Left != null)
            {
                result = result.Left;
            }

            return result;
        }

        private void BinaryInsertion(T item, IComparer<T> comparer)
        {
            Size++;
            // idk how this works but it works just fine without recursion
            BinaryTreeNode<T>? before = null, after = Root;
            while (after != null)
            {
                before = after;
                if (comparer?.Compare(item, after.Value) < 0)
                {
                    after = after.Left;
                }
                else
                {
                    after = after.Right;
                }
            }

            var node = new BinaryTreeNode<T>(before, item);

            if (Root == null)
            {
                Root = node;
            }
            else
            {
                if (comparer?.Compare(item, before.Value) < 0)
                {
                    before.Left = node;
                }
                else
                {
                    before.Right = node;
                }
            }
        }

        private BinaryTreeNode<T> SuccessorBST(BinaryTreeNode<T> node)
        {
            var result = node;
            if (result.Right != null)
            {
                return MinimumBST(result.Right);
            }

            var parent = result.Parent;
            while (parent != null && result == parent.Right)
            {
                result = parent;
                parent = parent.Parent;
            }

            return parent;
        }

        private BinaryTreeNode<T> PredecessorBST(BinaryTreeNode<T> node)
        {
            var result = node;
            if (result.Left != null)
            {
                return BinaryTree<T>.MaximumBST(result.Left);
            }

            var parent = result.Parent;
            while (parent != null && result == parent.Left)
            {
                result = parent;
                parent = parent.Parent;
            }

            return parent;
        }

        private void ShiftNodes(BinaryTreeNode<T>? u, BinaryTreeNode<T>? v)
        {
            if (u.Parent == null)
            {
                Root = v;
            }
            else if (u == u.Parent.Left)
            {
                u.Parent.Left = v;
            }
            else
            {
                u.Parent.Right = v;
            }

            if (v != null)
            {
                v.Parent = u.Parent;
            }
        }
    }
}