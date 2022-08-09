namespace Binary_Tree_Task
{
    public class OddEvenIntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 == 0 || x % 2 != 0 && y % 2 != 0)
            {
                return x.CompareTo(y);
            }

            if (x % 2 == 0)
            {
                return 1;
            }

            return -1;
        }
    }
}