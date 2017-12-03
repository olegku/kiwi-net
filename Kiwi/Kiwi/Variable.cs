namespace Kiwi
{
    public class Variable
    {
        public Variable(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public double Value { get; set; }
    }
}