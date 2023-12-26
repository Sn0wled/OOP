namespace TransportManagementSystem;

public abstract class UniqueObject {
    public UniqueObject() {
    }

    public int ID { get; set; }

    public virtual void ShowObject()
    {
        Console.WriteLine($"ID: {ID}");
    }
}
