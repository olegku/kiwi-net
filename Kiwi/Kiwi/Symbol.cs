namespace Kiwi
{
    public enum SymbolType
    {
        Invalid,
        External,
        Slack,
        Error,
        Dummy
    };


    public class Symbol
    {
        public SymbolType Type { get; }
        public ulong Id { get; }

        public Symbol()
        {
        }

        public Symbol(SymbolType type, ulong id)
        {
            Id = id;
            Type = type;
        }
    }
}
