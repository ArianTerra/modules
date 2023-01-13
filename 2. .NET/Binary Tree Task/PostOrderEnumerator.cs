using System;
using System.Collections;

namespace Binary_Tree_Task
{
    public class PostOrderEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private BinaryTree<T> _tree;
        private Stack<BinaryTreeNode<T>> _stack;
        private int _index = -1;
        private BinaryTreeNode<T>? _currentNode;
        private BinaryTreeNode<T>? _prevNode;
        private List<T> _data = new List<T>();

        public PostOrderEnumerator(BinaryTree<T> tree)
        {
            _tree = tree;
            _stack = new Stack<BinaryTreeNode<T>>();
        }

        public T Current
        {
            get => _data[_index];
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_index == -1)
            {
                _currentNode = _tree.Root;
                _stack.Push(_currentNode);
                Calculate();
            }

            _index++;
            return _tree.Size > _index;
        }

        public void Reset()
        {
            _index = -1;
            _stack.Clear();
            _prevNode = null;
            _currentNode = null;
        }

        public void Dispose()
        {
        }

        private void Calculate()
        {
            while (_stack.Count != 0)
            {
                _currentNode = _stack.Peek();

                if (_prevNode == null || _prevNode.Left == _currentNode || _prevNode.Right == _currentNode)
                {
                    if (_currentNode.Left != null)
                    {
                        _stack.Push(_currentNode.Left);
                    }
                    else if (_currentNode.Right != null)
                    {
                        _stack.Push(_currentNode.Right);
                    }
                    else
                    {
                        _stack.Pop();
                        _data.Add(_currentNode.Value);
                    }
                }
                else if (_currentNode.Left == _prevNode)
                {
                    if (_currentNode.Right != null)
                    {
                        _stack.Push(_currentNode.Right);
                    }
                    else
                    {
                        _stack.Pop();
                        _data.Add(_currentNode.Value);
                    }
                }
                else if (_currentNode.Right == _prevNode)
                {
                    _stack.Pop();
                    _data.Add(_currentNode.Value);
                }

                _prevNode = _currentNode;
            }
        }
    }
}