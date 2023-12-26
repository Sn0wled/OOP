
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Transportation : UniqueObject {

    public Transportation() {
    }

    protected List<DirectTransportation> dTList;

    protected Status status;

    public void ShowObject() {
        // TODO implement here
    }

    public void AddToEndDT(DirectTransportation dT) {
        // TODO implement here
    }

    public void DelLastDT() {
        // TODO implement here
    }

    public void StartNextDT() {
        // TODO implement here
    }

    public void StartTransportation() {
        // TODO implement here
    }

    public void EndTransportation() {
        // TODO implement here
    }

    public void Cancel() {
        // TODO implement here
    }

    public bool IsEmpty() {
        // TODO implement here
        return False;
    }

}