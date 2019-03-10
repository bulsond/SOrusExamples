namespace ConsoleApp1
{
    public interface ISoftware
    {
        //название продукта
        string Name { get; }
        //страна производитель
        string MadeIn { get; }
        //возможность легального использования
        bool CanBeUsed { get; }
        string CanBeUsedString { get; }
    }
}
