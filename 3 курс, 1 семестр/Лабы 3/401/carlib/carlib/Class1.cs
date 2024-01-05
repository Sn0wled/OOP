using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carlib
{
    public enum EngineState
    {
        engineAlive,
        engineDead
    }
    public abstract class Car
    {
        public EngineState state = EngineState.engineAlive;
        public string name = "noname";
        public short maxspeed = 0;
        public short speed = 0;
        public Car() { }
        public Car(string name, short maxspeed, short speed)
        {
            this.name = name;
            this.maxspeed = maxspeed;
            this.speed = speed;
        }
        public abstract void TurboBoost();
    }
    public class SportsCar : Car
    {
        public SportsCar() { }
        public SportsCar(string name, short maxspeed, short speed)
            : base(name, maxspeed, speed) { }
        public override void TurboBoost()
        {
            Console.WriteLine("Faster is better");
        }
    }
    public class MiniVan : Car
    {
        public MiniVan() { }
        public MiniVan(string name, short maxspeed, short speed)
            : base(name, maxspeed, speed) { }
        public override void TurboBoost()
        {
            Console.WriteLine("Car is Dead");
        }
    }
    public class VWMiniVan : Car
    {
        public VWMiniVan() { }
        public VWMiniVan(string name, short maxspeed, short speed)
            : base(name, maxspeed, speed) { }
        public override void TurboBoost()
        {
            Console.WriteLine("Car is Dead");
        }
        public void IsVersion()
        {
            Console.WriteLine("Version is 2.0.0.0");
        }
    }
}
