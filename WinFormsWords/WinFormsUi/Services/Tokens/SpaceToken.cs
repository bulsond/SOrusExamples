using WinFormsUi.Interfaces;

namespace WinFormsUi.Services.Tokens
{
    public class SpaceToken : IToken
    {
        public string Value { get; }
        public int Position { get; }
        public string TokenName { get; }
        public string TokenValue => $@"[{TokenName}:{Position}]";

        public SpaceToken(int position)
        {
            Position = position;
            Value = " ";
            TokenName = "space";
        }

        public override string ToString()
        {
            return TokenName;
        }
    }
}
