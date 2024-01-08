namespace HW1;

internal class Shop
{
    double revenue = 0;
    List<Product> products = new List<Product>();
    public double Revenue { get { return revenue; } }
    public Product[] Products { get { return products.ToArray(); } }
    public void AddProduct(Product product)
    {
        if (!products.Contains(product))
        {
            products.Add(product);
            product.ProductBought += ProductBought;
        }
    }
    public void RemoveProduct(Product product)
    {
        if (!products.Remove(product)) throw new ArgumentException("Данного продукта нет в магазине");
        product.ProductBought -= ProductBought;
    }
    void ProductBought(Product p, int count)
    {
        revenue += p.Price * count;
    }
}
