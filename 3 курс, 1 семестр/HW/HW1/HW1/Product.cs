namespace HW1;

delegate void ProductDlg(Product product, int count);

internal class Product
{
    string name;
    double price;
    int count;
    public string Name { get { return name; } }
    public double Price { get { return price; } }
    public int Count { get { return count; } }
    public event ProductDlg ProductBought;
    public Product(string name, double price, int count)
    {
        if (price < 0) throw new ArgumentOutOfRangeException("price меньше 0");
        if (count < 0) throw new ArgumentOutOfRangeException("count меньше 0");
        this.name = name;
        this.price = price;
        this.count = count;
    }
     public void Buy(int count)
    {
        if (count < 1) { throw new ArgumentOutOfRangeException("count меньше 1"); }
        if (count > this.count) { throw new ArgumentOutOfRangeException("недостаточно товара в магазине"); }
        this.count -= count;
        ProductBought?.Invoke(this, count);
    }
    public void Add(int count)
    {
        if (count < 1) throw new ArgumentOutOfRangeException("count меньше 1");
        this.count += count;
    }
    public void Remove(int count)
    {
        if (count > this.count) throw new ArgumentOutOfRangeException("Нет столько продукта");
        this.count -= count;
    }
    public override string ToString()
    {
        return $"Название: {Name}, кол-во: {count}, цена: {Price}";
    }
}
