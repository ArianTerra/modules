namespace Binary_Tree_Task
{
    public class CustomType : IComparable<CustomType>
    {
        public CustomType(double value)
        {
            Value = value;
        }

        public double Value { get; private set; }

        public int CompareTo(CustomType other)
        {
            return Value.CompareTo(other?.Value) * -1;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}