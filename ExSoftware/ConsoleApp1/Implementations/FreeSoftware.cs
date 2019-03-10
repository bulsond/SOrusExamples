namespace ConsoleApp1
{
    public class FreeSoftware : ASoftware
    {
        //ctor
        public FreeSoftware(string name, string madeIn) : base(name, madeIn)
        { }

        public override string ToString()
        {
            return $"Название продукта: {Name}" +
                $"\nСтрана производства: {MadeIn}" +
                $"\nВсегда доступно к беспл.использованию.";
        }
    }
}
