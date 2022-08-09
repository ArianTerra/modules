using Binary_Tree_Task;

// BinaryTree is a generic type collection.
// Generic type must implement IComparable<T> interface so it can be sorted when added to binary tree.
// This implementation of binary tree uses BinaryTreeNode as nodes.
// You can create a new binary tree like this:
var tree = new BinaryTree<int>();

// We can add elements one by one using Add(T item) method.
// Elements are added as in binary search tree (BST).
// Note that there's no recursion used.
tree.Add(5);
tree.Add(3);
tree.Add(7);

// Let's clear the tree:
tree.Clear();

// We can use AddRange(IEnumerable<T> items) method:
var list = new List<int> { 5, 2, 6, 7, 1, 3 };
tree.AddRange(list);
Console.WriteLine("Tree height: " + tree.Height);

// Here's how the tree looks like in memory:
//
//       5
//      / \
//     2   6
//    / \   \
//   1   3   7
//
// We can check if collection have any specific value.
// It uses binary search to find a value and returns True if value is found.
Console.WriteLine("Does the tree contains 3: " + tree.Contains(3));
Console.WriteLine("Does the tree contains 666: " + tree.Contains(666));

// Also we can get a BinaryTreeNode using GetNode() method. Maybe it should be private.
var nodeA = tree.GetNode(3);
var nodeB = tree.GetNode(666); //returns null because this value does not exist
Console.WriteLine("Height of nodeA: " + nodeA.Height);

// We can delete items. Let's delete a node without leaves.
// The result is gonna look like this:
//
//       5
//      / \
//     2   6
//      \   \
//       3   7
//
tree.Remove(1);

// Let's remove a node with one leaf.
//
//       5
//      / \
//     2   7
//    / \
//   1   3
//
tree = new BinaryTree<int>();
tree.AddRange(list);
tree.Remove(6);

// Let's remove root node and see what happens.
//
//       6
//      / \
//     2   7
//    / \
//   1   3
//
tree = new BinaryTree<int>();
tree.AddRange(list);
tree.Remove(5);

// By default, the tree uses PreOrderEnumerator which implements IEnumerator<T> interface.
// When using GetEnumerator (e. g. when using ToList() or foreach) preorder traversal (NLR) is used.
// What's cool about PreOrderEnumerator is that:
// 1) There's no recursion used. Stack is used instead.
// 2) All calculations are made step by step. What I mean is that "public T Current" is not precalculated.
// Output: 5 2 1 3 6 7
tree = new BinaryTree<int>();
tree.AddRange(list);
Console.Write("Pre order: ");
foreach (var item in tree)
{
    Console.Write($"{item} ");
}

// We can change enumerator to another so we can traverse through the tree using another method.
// Let's use PostOrderEnumerator (i. e. Post Order Traversal or LRN).
// It's not that cool as PreOrderEnumerator because it precalculates the result at first iteration.
// It means that additional storage is used (private List<T> _data).
// Output: 1 3 2 7 6 5
tree.Enumerator = new PostOrderEnumerator<int>(tree);
Console.Write("\nPost order: ");
foreach (var item in tree)
{
    Console.Write($"{item} ");
}

// Also we can use custom comparer. For example, we want odd numbers go to the left branch and even go the right.
// Tbh the task 3 looks kinda confusing.
// "Реалізувати можливість використання нестандартного впорядкування дерева, наприклад із кожної пари чисел спочатку
// йде непарне, а потім – парне (1,0,3,2,5,4,7,6,9,8…)"
// I did not understand that part well, so I made it in my way. See OddEvenComparer.cs
//
//        5
//      /  \
//     1    2
//     \   / \
//      3 7   6

tree = new BinaryTree<int>(new OddEvenIntComparer());
tree.AddRange(list);

// As been said we can use custom types that implement IComparable<T> interface.
// For example, that's a type with slightly tweaked CompareTo() method. See CustomType.cs for more details.
// The tree is now mirrored:
//
//       5
//      / \
//     6   2
//    /   / \
//   7   3   1
//
var anotherList = new List<CustomType>()
{
    new (5d), new (2d), new (6d), new (7d), new (1d), new (3d)
};
var anotherTree = new BinaryTree<CustomType>();
anotherTree.AddRange(anotherList);
Console.Write("\nCustom type test: ");
foreach (var item in anotherTree)
{
    Console.Write($"{item} ");
}

// Thanks to IEnumerable<T> interface our collection now supports LINQ methods.
// Let's select all items larger than 3:
tree = new BinaryTree<int>();
tree.AddRange(list);
Console.Write("\nLINQ select X where x > 3: ");
foreach (var item in tree.Where(x => x > 3))
{
    Console.Write($"{item} ");
}

// We can use extension method to create IEnumerable<T> from BinaryTree<T>:
IEnumerable<int> res = tree.ToList();
Console.Write("\nBinaryTree to List: ");
foreach (var item in res)
{
    Console.Write($"{item} ");
}