using HW1;

internal class Program
{
    public static void Main()
    {
        Shop shop = new Shop();
        Buyer buyer = new Buyer(1000);
        shop.AddProduct(new Product("Тыква", 100, 10));
        shop.AddProduct(new Product("Помидор", 100, 10));
        shop.AddProduct(new Product("Огурец", 100, 10));
        Console.WriteLine("Витрина магазина:");
        foreach (Product product in shop.Products)
        {
            Console.WriteLine(product);
        }
        buyer.Cart.AddToCart(new CartUnit(shop.Products[1], 5));
        Console.WriteLine($"\nДеньги покупателя: {buyer.Money}");
        Console.WriteLine("Корзина покупателя:");
        foreach(CartUnit product in buyer.Cart.Products)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine("\nПокупаем все в корзине");
        buyer.Cart.BuyAll();
        Console.WriteLine("\nВитрина магазина:");
        foreach (Product product in shop.Products)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine("\nКорзина покупателя:");
        foreach (CartUnit product in buyer.Cart.Products)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine($"Деньги покупателя: {buyer.Money}");
        Console.WriteLine($"Прибыль магазина: {shop.Revenue}");
    }
}
