using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        ArrayWithEvents list = new ArrayWithEvents();
        ListEventListener listener = new(list);
        list.Add("asd");
        list.Add(123);
        list.Clear();
        listener.Detach();
    }
}

class ArrayWithEvents : ArrayList
{
    public event EventHandler Changed;
    protected virtual void OnChanged(EventArgs e)
    {
        Changed?.Invoke(this, e);
    }
    public override int Add(object? value)
    {
        int i = base.Add(value);
        OnChanged(EventArgs.Empty);
        return i;
    }
    public override void Clear()
    {
        base.Clear();
        OnChanged(EventArgs.Empty);
    }
    public override object? this[int index]
    {
        set
        {
            base[index] = value;
            OnChanged(EventArgs.Empty);
        }
    }
}

class ListEventListener
{
    private ArrayWithEvents list;
    private void ListChanged(object? sender, EventArgs e)
    {
        Console.WriteLine("Event fired");
    }
    public ListEventListener(ArrayWithEvents list)
    {
        this.list = list;
        this.list.Changed += ListChanged;
    }
    public void Detach()
    {
        list.Changed -= ListChanged;
        list = null;
    }
}