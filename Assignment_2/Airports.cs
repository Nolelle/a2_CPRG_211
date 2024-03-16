namespace Assignment_2
{
    internal class Airports
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public Airports(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Code} - {Name}";
        }
    }
}
