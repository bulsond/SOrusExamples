using System;
using WinFormsProducts.Abstractions;

namespace WinFormsProducts.Models
{
    public class Product : IProduct
    {

        public string Name { get; }
        public decimal PricePerKg { get; }
        public decimal PriceInCart { get; private set; }

        public double Weight { get; set; }

        //ctor
        public Product(string name, decimal price)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));
            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price));

            Name = name;
            PricePerKg = price;
        }

        public IProduct GetProductToCart()
        {
            //создаем экземпляр с подобными свойствами
            var result = new Product(this.Name, this.PricePerKg);
            result.Weight = this.Weight;

            //вычисляем конечную цену
            result.PriceInCart = (decimal)Weight * PricePerKg;

            return result;
        }
    }
}
