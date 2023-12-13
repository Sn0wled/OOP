A[] f = { new A(), new B(), new A() };

foreach (A a in f)
{
    a.Show();
}

A a1 = new();
B b1 = new();
Console.WriteLine(a1.Equals(b1));

class A
{
    int a = 10;
    public virtual void Show() => Console.WriteLine("A");
    public int HetHashCode()
    {
        return 0;
    }
    public override bool Equals(object? obj)
    {
        if (obj is A a)
        {
            return this.a == a.a;
        }
        return false;
    }
}

class B : A {
}