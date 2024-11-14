namespace Patterns.Adapter
{
    public class StringAdapter
    {
        private readonly int _value;
        public StringAdapter(ref int value)
        {
            _value = value;
        }

        public string GetValueAsString() => _value.ToString();
    }
}