namespace HW1;

internal class Cart
{
    List<CartUnit> unitList = new();
    BuyerDlg CheckAndBuy;
    public CartUnit[] Products
    {
        get
        {
            return unitList.ToArray();
        }
    }
    public Cart(BuyerDlg CheckAndBuy)
    {
        this.CheckAndBuy = CheckAndBuy;
    }
    public void AddToCart(CartUnit unit)
    {
        unitList.Add(unit);
        unit.ZeroCount += RemoveFromCart;
        unit.CheckMoney += CheckAndBuy;
    }
    public void RemoveFromCart(CartUnit unit)
    {
        if (!unitList.Remove(unit)) throw new ArgumentException("Данного продукта нет в корзине");
        unit.ZeroCount -= RemoveFromCart;
    }
    public void BuyAll()
    {
        foreach (CartUnit unit in unitList.ToArray())
        {
            unit.Buy();
        }
    }
}
