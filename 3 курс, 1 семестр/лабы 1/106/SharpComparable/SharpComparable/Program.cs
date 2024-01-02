Car[] cars = new Car[4];
cars[0] = new Car("3");
cars[1] = new Car("2");
cars[2] = new Car("1");
cars[3] = new Car("4");
foreach (Car car in cars)
{
    Console.WriteLine(car.Name);
}

Array.Sort(cars);
Console.WriteLine("Sorted:");
foreach (Car car in cars)
{
    Console.WriteLine(car.Name);
}

class Car : IComparable
{
    private string name = "noname";
    public Car() { }
    public Car(string name) { this.name = name; }
    public string Name { get { return name; } }
    int IComparable.CompareTo(object? obj)
    {
        return name.CompareTo((obj as Car).Name);
    }
}