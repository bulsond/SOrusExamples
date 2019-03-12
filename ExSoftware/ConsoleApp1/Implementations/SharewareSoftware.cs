using System;

namespace ConsoleApp1
{
    public class SharewareSoftware : ASoftware, IPaidSoftware
    {
        //ctor
        public SharewareSoftware(string name, string madeIn,
            DateTime installDate, TimeSpan freeUsagePeriod) : base(name, madeIn)
        {
            InstallationDate = installDate;
            UsagePeriod = freeUsagePeriod;
            Price = 0;
        }

        public DateTime InstallationDate { get; }
        public TimeSpan UsagePeriod { get; }
        public DateTime EndUsagePeriod => InstallationDate + UsagePeriod;
        public virtual decimal Price { get; }

        public override bool CanBeUsed => EndUsagePeriod > DateTime.Now;

        public override string ToString()
        {
            return $"Название продукта: {Name}" +
                $"\nСтрана производства: {MadeIn}" +
                $"\nДоступно к беспл. использованию: {CanBeUsedString}" +
                $"\nДата окончания беспл. использования: {EndUsagePeriod.ToShortDateString()}";
        }
    }
}
