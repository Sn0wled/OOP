namespace Domino
{
    internal class Dice
    {
        static Random rnd = new Random();
        int value;
        public int Value { get { return value; }  }
        public void Roll()
        {
            value = rnd.Next(1, 7);
        }
    }
}
