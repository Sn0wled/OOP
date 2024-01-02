using System.Collections;

Car[] cars = new Car[4];
cars[0] = new Car("4");
cars[1] = new Car("1");
cars[2] = new Car("3");
cars[3] = new Car("2");

foreach (Car car in cars)
{
    Console.WriteLine(car.Name);
}

//Array.Sort(cars, new SortByName());
Array.Sort(cars, Car.SortByName);

Console.WriteLine("Sorted");
foreach (Car car in cars)
{
    Console.WriteLine(car.Name);
}

class Car
{
    private string name = "noname";
    public Car() { }
    public Car(string name) { this.name = name;}
    public string Name {  get { return name;} }
    public static IComparer SortByName
    {
        get => new SortByName();
    }
}

class SortByName : IComparer
{
    int IComparer.Compare(object? a, object? b)
    {
        return string.Compare((a as Car)?.Name, (b as Car)?.Name);
    }
}