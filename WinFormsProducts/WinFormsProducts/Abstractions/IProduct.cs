namespace WinFormsProducts.Abstractions
{
    public interface IProduct
    {
        //наименование товара
        string Name { get; }
        //цена за 1 кг.
        decimal PricePerKg { get; }
        //вес товара в корзине
        double Weight { get; set; }
        //цена в корзине
        decimal PriceInCart { get; }

        //получение экземпляра для добавления в корзину
        IProduct GetProductToCart();
    }
}
