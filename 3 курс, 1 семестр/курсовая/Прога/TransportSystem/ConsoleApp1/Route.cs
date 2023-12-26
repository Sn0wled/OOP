namespace TransportSystem;

class Route : PointList
{
    public int RouteID { get; init; }

    public void AddWayPoint(WayPoint point) =>AddPoint(point);

    public void DeleteWayPoint(WayPoint point) => DeletePoint(point);
    public Point? LastNotMarked()
    {
        if (Count == 0) return null;
        foreach (Point point in pointList) { if }
    }

    public Route(int routeID) { RouteID = routeID; }

}