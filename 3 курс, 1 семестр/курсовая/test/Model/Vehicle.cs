
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Vehicle : UniqueObject {

    public Vehicle() {
    }

    protected string name;

    protected Coordinates coords;

    protected Driver driver;

    protected DirectTransportation dTransportation;

    public void ShowObject() {
        // TODO implement here
    }

    public void SetDriver(Driver driver) {
        // TODO implement here
    }

    public abstract void Move(Coordinates coords);

    public void DTransportation() {
        // TODO implement here
    }

}