using System;

namespace NumberNotationsUI.Models
{
    public class HexNotation : INotation
    {
        //ctor
        public HexNotation()
        {
            Name = "Шестнадцатеричная";
        }

        public string Name { get; }
        public int ValueInt { get; private set; }
        public string ValueString { get; private set; }

        public void SetValue(int value)
        {
            ValueInt = value;
            ValueString = Convert.ToString(value, 16);
        }

        public bool SetValue(string value)
        {
            try
            {
                ValueInt = Convert.ToInt32(value, 16);
            }
            catch (Exception)
            {
                return false;
            }

            ValueString = value;
            return true;
        }
    }
}
