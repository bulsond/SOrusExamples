using WinFormsUi.Interfaces;

namespace WinFormsUi.Services.Tokens
{
    public class NumberToken : IToken
    {
        public string Value { get; }
        public int Position { get; }
        public string TokenName { get; }
        public string TokenValue => $@"[{TokenName}:{Position}]";

        public NumberToken(int position, string value)
        {
            Position = position;
            Value = value;
            TokenName = "number";
        }

        public override string ToString()
        {
            return TokenName;
        }
    }
}
