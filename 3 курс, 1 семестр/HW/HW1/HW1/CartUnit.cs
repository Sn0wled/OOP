using System.Diagnostics;
using System.Xml.Linq;

namespace HW1;

delegate void CartUnitDlg(CartUnit unit);

internal class CartUnit
{
    Product product;
    int count;
    public event CartUnitDlg ZeroCount;
    public BuyerDlg CheckMoney;
    public string Name { get { return product.Name; } }
    public double Price { get { return product.Price; } }
    public double FullPrice { get { return Price * count; } }
    public int Count { get { return count; } }
    public CartUnit(Product product, int count)
    {
        if (product.Count < count) { throw new ArgumentOutOfRangeException("Недостаточно продукта в магазине"); }
        else if (count <= 0) {  throw new ArgumentOutOfRangeException("count должен быть не меньше 1"); }
        this.product = product;
        this.count = count;
        product.ProductBought += Recount;
    }
    public void AddToUnit(int count)
    {
        if (count < 0) {  throw new ArgumentOutOfRangeException("count не может быть меньше 0"); }
        count += this.count;
        if (count > product.Count) { throw new ArgumentOutOfRangeException("недостаточно продукта в магазине"); }
        this.count = count;
    }
    public void RemoveFromUnit(int count)
    {
        if (count < 0) { throw new ArgumentOutOfRangeException("count не может быть меньше 0"); }
        count -= this.count;
        if (count > product.Count) { throw new ArgumentOutOfRangeException("count не может быть больше, чем продуктов в корзине"); }
        this.count = count;
        if (count == 0) ZeroCount?.Invoke(this);
    }
    public void Recount(Product p, int count1)
    {
        if (product.Count < count) count = product.Count;
        if ( count == 0)
        {
            ZeroCount?.Invoke(this);
            product.ProductBought -= Recount;
        }
    }
    public void Buy()
    {
        CheckMoney(FullPrice);
        product.Buy(count);
        ZeroCount?.Invoke(this);
        product.ProductBought -= Recount;
    }

    public override string ToString()
    {
        return $"Название: {product.Name}, кол-во: {count}, общая стоимость: {count * product.Price}";
    }
}
