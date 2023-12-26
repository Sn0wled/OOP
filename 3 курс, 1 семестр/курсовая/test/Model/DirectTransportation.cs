
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DirectTransportation {

    public DirectTransportation() {
    }

    protected Point startPoint;

    protected Point endPoint;

    protected Status status = NotStarted;

    protected Vehicle vehicle;

    protected Transportation transportation;

    public void ShowInfo() {
        // TODO implement here
    }

    public void IsStartPoint(Coordinates coords) {
        // TODO implement here
    }

    public void IsEndPoint(Coordinates coords) {
        // TODO implement here
    }

    public Status GetStatus() {
        // TODO implement here
        return null;
    }

    public void StartDTranportation() {
        // TODO implement here
    }

    public void EndDTransportqation() {
        // TODO implement here
    }

    public void Cancel() {
        // TODO implement here
    }

}