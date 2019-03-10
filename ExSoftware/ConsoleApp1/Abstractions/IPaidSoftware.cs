using System;

namespace ConsoleApp1
{
    public interface IPaidSoftware
    {
        //дата установки
        DateTime InstallationDate { get; }
        //период использования
        TimeSpan UsagePeriod { get; }
        //дата окончания использования
        DateTime EndUsagePeriod { get; }
        //цена (для монетарных расчетов надо использ. decimal, а не double)
        decimal Price { get; }
    }
}
