namespace NumberNotationsUI.Models
{
    public class DecimalNotation : INotation
    {
        //ctor
        public DecimalNotation()
        {
            Name = "Десятичная";
        }

        public string Name { get; }
        public int ValueInt { get; private set; }
        public string ValueString { get; private set; }

        public void SetValue(int value)
        {
            ValueInt = value;
            ValueString = ValueInt.ToString();
        }

        public bool SetValue(string value)
        {
            int input;
            if (int.TryParse(value, out input))
            {
                ValueInt = input;
                ValueString = value;
                return true;
            }

            return false;
        }
    }
}
