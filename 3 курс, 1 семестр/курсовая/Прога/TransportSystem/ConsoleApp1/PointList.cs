using System.Reflection.Metadata.Ecma335;

namespace TransportSystem;

class PointList : IEnumerable
{
    List<Point> pointList;

    public PointList()
    {
        pointList = new List<Point>();
    }

    IEnumerator<Point> enumarator;

    public void AddPoint(Point point) { pointList.Add(point); }

    public void DeletePoint(Point point) { }

    public void Next()
    {
        pointList.
    }

    public IEnumerator GetEnumerator() { return pointList.GetEnumerator(); }
}