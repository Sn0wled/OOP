Cars carlot = new Cars();
foreach (object o in carlot)
{
    Console.WriteLine((o as Car)?.Name);
}



class Car
{
    public string name = "noname";
    public Car() { }
    public Car(string name) => this.name = name;
    public string Name { get => name; }
}

class Cars : System.Collections.IEnumerable
{
    private Car[] cars;
    public Cars()
    {
        cars = new Car[4];
        cars[0] = new Car("alpha");
        cars[1] = new Car("porshe");
        cars[2] = new Car("nissan");
        cars[3] = new Car("Газ-13");
    }
    public System.Collections.IEnumerator GetEnumerator()
    {
        return new CarsEnumerator(this);
    }
    private class CarsEnumerator : System.Collections.IEnumerator
    {
        private int current = -1;
        private Cars c;
        public CarsEnumerator(Cars c)
        {
            this.c = c;
        }
        public void Reset() => current = -1;
        public bool MoveNext()
        {
            if (current < c.cars.Length - 1)
            {
                current++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public object Current { get { return c.cars[current]; } }
    }
}