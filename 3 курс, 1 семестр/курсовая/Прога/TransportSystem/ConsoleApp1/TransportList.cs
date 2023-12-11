namespace TransportSystem;

class TransportList
{
    List<Transport> transports = new();
    int counter = 0;
    public int Length {  get { return counter; } }

    public Transport? FindTransport(int transportID)
    {
        return transports.Find(t => t.TransportID == transportID);
    }

    public void AddTransport(Transport t)
    {
        transports.Add(t);
    }

    public void DeleteTransport(Transport t)
    {
        transports.Remove(t);
    }
}