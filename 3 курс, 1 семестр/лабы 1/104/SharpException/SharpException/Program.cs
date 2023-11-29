using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Car
{
    private int speed;
    private int maxSpeed;
    private string petName;
    private Radio theMusicBox = new Radio();
    public void Tune(bool state)
    {
        theMusicBox.TurnOn(state);
    }
    bool dead;
    public Car(string petName, int maxSpeed, int speed)
    {
        this.speed = speed;
        this.maxSpeed = maxSpeed;
        this.petName = petName;
        this.dead = false;
    }
    public void SpeedUp(int delta)
    {
        if (dead)
        {
            throw new CarIsDeadException(this.petName);
            //throw new Exception("This car is already dead");
            /*Console.WriteLine(petName + " is dead");*/
        }
        else
        {
            if (delta < 0)
            {
                throw new ArgumentOutOfRangeException("" + "Must be greater than zero");
            } else if (delta > 50)
            {
                throw new CarInvalidSpeedUp("" + "Invalid acceleration for " + petName);
            }
            speed += delta;
            if (speed < maxSpeed)
            {
                Console.WriteLine("\tCurrent Speed = " + speed);
            }
            else
            {
                Console.WriteLine(petName + " has overheated...");
                dead = true;
            }
        }
    }
}

class CarIsDeadException : Exception
{
    private string carName;
    public CarIsDeadException() { }
    public CarIsDeadException(string carName)
    {
        this.carName = carName;
    }
    public override string Message
    {
        get
        {
            string msg = base.Message;
            if (carName != null)
            {
                msg += "\n" + carName + " has been destroyed";
            }
            return msg;
        }
    }
}

class Radio
{
    public Radio() { }
    public void TurnOn(bool on)
    {
        if (on)
        {
            Console.WriteLine("Radio in now on");
        } else
        {
            Console.WriteLine("Radio in now quiet");
        }
    }
    ~Radio()
    {
        Console.WriteLine("Radio is now destroyed");
    }
}

class CarInvalidSpeedUp : Exception
{
    public CarInvalidSpeedUp() { }
    public CarInvalidSpeedUp(string message) : base(message) { }
}

namespace SharpException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("boom", 100, 0);
            c1.Tune(true);
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    c1.SpeedUp(60);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("ArgumentOutOfRangeException " + e.Message);
            }
            catch (CarInvalidSpeedUp e)
            {
                Console.WriteLine("CarInvalidSpeedUp " + e.Message);
            }
            catch (CarIsDeadException2)
            catch (Exception e)
            {
                Console.WriteLine($"Exception Message: {e.Message}");
                Console.WriteLine($"StackTrace: {e.StackTrace}");
            }
            c1.Tune(false);
        }
    }
}
