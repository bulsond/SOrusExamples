using WinFormsUi.Interfaces;

namespace WinFormsUi.Services.Tokens
{
    public class WordToken : IToken
    {
        public string Value { get; }
        public int Position { get; }
        public string TokenName { get; }
        public string TokenValue => $"<{Value}:{Position}:{OrderNumber}>";
        public int OrderNumber { get; }

        public WordToken(int position, string value, int orderNumber)
        {
            Position = position;
            Value = value.ToLower();
            TokenName = "word";
            OrderNumber = orderNumber;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
