using System;

namespace NumberNotationsUI.Models
{
    public class BinaryNotation : INotation
    {
        //ctor
        public BinaryNotation()
        {
            Name = "Двоичная";
        }

        public string Name { get; }
        public string ValueString { get; private set; }
        public int ValueInt { get; private set; }

        public void SetValue(int value)
        {
            ValueInt = value;
            ValueString = Convert.ToString(value, 2);
        }

        public bool SetValue(string value)
        {
            try
            {
                ValueInt = Convert.ToInt32(value, 2);
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
