namespace Patterns.Prototype
{
    public class Document: ICloneable<Document>
    {
        public string Series { get; set; }
        public string Number { get; set; }

        public Document(string series, string number)
        {
            Series = series;
            Number = number;
        }

        public Document Clone()
        {
            var clone = (Document)MemberwiseClone();
            clone.Series = new string(Series);
            clone.Number = new string(Number);
            return clone;
        }
    }
}