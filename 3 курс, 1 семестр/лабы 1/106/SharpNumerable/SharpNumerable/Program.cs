using System.Collections;

Cars carlot = new Cars();
foreach (Car c in carlot)
{
    Console.WriteLine(c.Name);
}

carlot.Reset();
carlot.MoveNext();
Console.WriteLine((carlot.Current as Car)?.Name);


class Car
{
    private string name = "noname";
    public Car() { }
    public Car(string name) => this.name = name;
    public string Name {  get { return name; } }
}

class Cars : IEnumerable, IEnumerator
{
    private Car[] cars;
    private int current = -1;
    public Cars()
    {
        cars = new Car[4];
        cars[0] = new Car("alpha");
        cars[1] = new Car("porshe");
        cars[2] = new Car("nissan");
        cars[3] = new Car("ГАЗ-13");
    }
    public IEnumerator GetEnumerator()
    {
        return this;
        /*for (int i = 0; i < cars.Length; i++)
        {
            yield return cars[i];
        }*/
    }
    public void Reset() => current = -1;
    public bool MoveNext()
    {
        if (current < cars.Length - 1)
        {
            current++;
            return true;
        } else
        {
            return false;
        }
    }
    public object Current
    {
        get { return cars[current]; }
    }
}