using WinFormsUi.Interfaces;

namespace WinFormsUi.Services.Tokens
{
    public class SignToken : IToken
    {
        public string Value { get; }
        public int Position { get; }
        public string TokenName { get; }
        public string TokenValue => $@"[{TokenName}:{Position}]";

        public SignToken(int position, string value)
        {
            Position = position;
            Value = value;
            TokenName = "sign";
        }

        public override string ToString()
        {
            return TokenName;
        }
    }
}
