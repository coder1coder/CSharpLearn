namespace Patterns.Prototype
{
    public class Person: ICloneable<Person>
    {
        public string FullName { get; set; }
        public Document Document { get; set; }

        public Person(string fullName)
        {
            FullName = fullName;
        }

        public override string ToString()
        {
            return $"Person: {FullName}. Document: {Document?.Series} {Document?.Number}";
        }

        public Person Clone()
        {
            var clone = (Person)MemberwiseClone();
            clone.FullName = new string(FullName);
            clone.Document = Document?.Clone();
            return clone;
        }
    }
}