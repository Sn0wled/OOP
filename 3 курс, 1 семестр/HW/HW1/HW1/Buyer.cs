namespace HW1;

delegate void BuyerDlg(double money);
internal class Buyer
{
    double money;
    Cart cart;
    public Cart Cart { get { return cart; } }
    public double Money { get { return money; } }
    public Buyer(double money)
    {
        this.money = money;
        cart = new(CheckAndBuy);
    }
    public void AddMoney(double money) { this.money += money; }
    public void CheckAndBuy(double money) {
        if (money <= Money) this.money -= money;
        else throw new Exception("У вас недостаточно средств");
    }
}
