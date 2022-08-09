namespace Binary_Tree_Task
{
    public static class ToBinaryTreeExtension
    {
        public static BinaryTree<T> ToBinaryTree<T>(this IEnumerable<T> enumerable) where T : IComparable<T>
        {
            var tree = new BinaryTree<T>();
            tree.AddRange(enumerable);
            return tree;
        }

        public static BinaryTree<T> ToBinaryTree<T>(this IEnumerable<T> enumerable, IComparer<T> comparer, IEnumerator<T> enumerator)
            where T : IComparable<T>
        {
            var tree = new BinaryTree<T>() { Comparer = comparer, Enumerator = enumerator };
            tree.AddRange(enumerable);
            return tree;
        }
    }
}