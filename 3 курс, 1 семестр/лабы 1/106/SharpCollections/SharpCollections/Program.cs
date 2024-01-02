using System.Collections;

Cars cars = new();
cars.Add(new Car("alpha"));
cars.Add(new Car("RR"));
cars.Add(new Car("117"));
cars.Add(new Car("Nissan"));
Console.WriteLine($"We have {cars.Count} cars:");
foreach (Car car in cars)
{
    Console.WriteLine(car.Name);
}
cars.RemoveAt(3);

Console.WriteLine($"We have {cars.Count} cars:");
foreach (Car car in cars)
{
    Console.WriteLine(car.Name);
}
Car a = new Car("Audi100"); 
cars.Add(a);
if (cars.Contains(a))
{
    Console.WriteLine($"{a.Name} is present");
    cars.Clear();
}
Console.WriteLine($"We have {cars.Count} cars.");

ArrayList ar = new();
ar.Add(cars);
ar.Add(new Car("abc"));
ar.Add("Hi");
ar.Add(33);
foreach(object o in ar) Console.WriteLine(o.ToString());

class Car
{
    private string name = "noname";
    public Car() { }
    public Car(string name) { this.name = name; }
    public string Name
    {
        get { return name; }
    }
}

class Cars : IEnumerable
{
    public ArrayList cars;
    public Cars()
    {
        cars = new();
    }
    public void Add(Car car)
    {
        cars.Add(car);
    }
    public int Count { get { return cars.Count; } }
    public void Clear() { cars.Clear(); }
    public void RemoveAt(int index)
    {
        cars.RemoveAt(index);
    }
    public bool Contains(Car car) => cars.Contains(car);
    public IEnumerator GetEnumerator() => cars.GetEnumerator();
}