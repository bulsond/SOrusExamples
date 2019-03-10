using System;

namespace ConsoleApp1
{
    public class ProprietarySoftware : SharewareSoftware
    {
        //ctor
        public ProprietarySoftware(string name, string madeIn,
            DateTime installDate, TimeSpan usagePeriod, decimal price) : base(name, madeIn, installDate, usagePeriod)
        {
            Price = price;
        }

        public override decimal Price { get; }

        public override string ToString()
        {
            return $"Название продукта: {Name}" +
                $"\nСтрана производства: {MadeIn}" +
                $"\nЦена: {Price}" +
                $"\nДоступно к использованию: {CanBeUsedString}" +
                $"\nДата окончания использования: {EndUsagePeriod.ToShortDateString()}";
        }
    }
}
