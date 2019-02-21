namespace NumberNotationsUI.Models
{
    public interface INotation
    {
        //название нотации
        string Name { get; }

        //значение
        int ValueInt { get; }
        //значение в виде строки
        string ValueString { get; }

        //присвоение значения
        void SetValue(int value);
        bool SetValue(string value);
    }
}
