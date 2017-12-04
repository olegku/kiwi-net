namespace Kiwi
{
    internal enum SymbolType
    {
        Invalid,
        External,
        Slack,
        Error,
        Dummy
    };


    internal class Symbol
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
