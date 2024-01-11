namespace Backgammon;

internal class Player
{
    string name;
    Dice dice1, dice2;
    public int Dice1 { get { return dice1.Value; } }
    public int Dice2 { get { return dice2.Value; } }
    public string Name { get { return name; } }
    public Color Color { get; set; }
    public Player(string name, Color color)
    {
        this.name = name;
        Color = color;
        dice1 = new Dice();
        dice2 = new Dice();
    }
    public void RollDices()
    {
        dice1.Roll();
        dice2.Roll();
    }
}
