using System.Collections;

delegate void carDeleg(Car car);

internal class Program
{
    private static void Main(string[] args)
    {
        Washer washer = new Washer();
        carDeleg cd = washer.Wash;
        Garage g = new();
        foreach (Car c in g)
        {
            cd(c);
        }
    }
}

class Car
{
    string name = "noname";
    public string Name
    {
        get { return name; }
    }
    public Car() { }
    public Car(string name)
    {
        this.name = name;
    }
    public override string ToString() => $"Car {Name}";
}

class Garage : IEnumerable
{
    Car[] cars;
    public Garage()
    {
        cars = new Car[5];
        cars[0] = new Car("1");
        cars[1] = new Car("2");
        cars[2] = new Car("3");
        cars[3] = new Car("4");
        cars[4] = new Car("5");
    }
    public IEnumerator GetEnumerator() => cars.GetEnumerator();
    public Car this[int index] => cars[index];
}

class Washer
{
    public void Wash(Car car)
    {
        Console.WriteLine($"Моем {car}");
    }
}