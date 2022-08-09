using System.Collections;

namespace Binary_Tree_Task
{
    public class PreOrderEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private BinaryTree<T> _tree;
        private Stack<BinaryTreeNode<T>> _stack;
        private int _count;
        private BinaryTreeNode<T>? _currentNode;

        public PreOrderEnumerator(BinaryTree<T> tree)
        {
            _tree = tree;
            _stack = new Stack<BinaryTreeNode<T>>();
        }

        public T Current
        {
            get => _currentNode.Value;
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_stack.Count > 0)
            {
                _currentNode = _stack.Pop();
            }
            else
            {
                _currentNode = _tree.Root;
                _stack.Push(_currentNode);
            }

            if (_currentNode.Right != null)
            {
                _stack.Push(_currentNode.Right);
            }

            if (_currentNode.Left != null)
            {
                _stack.Push(_currentNode.Left);
            }

            _count++;
            return _tree.Size >= _count;
        }

        public void Reset()
        {
            _stack.Clear();
            _stack.Push(_tree.Root);
            _count = 0;
            _currentNode = _tree.Root;
        }

        public void Dispose()
        {
        }
    }
}