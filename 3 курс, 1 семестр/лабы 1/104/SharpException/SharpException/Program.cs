using ClassesAndExceptions;

class Programm {
    public static void Main( ) {
        Car c1 = new(0, 100, "boom");
        c1.Tune(true);

        try {
            for (int i = 0; i < 10; i++) {
                c1.SpeedUp(10);
            }
        } 
        catch (ArgumentOutOfRangeException e) 
        {
           Console.WriteLine($"ArgumentOutOfRangeException {e.Message}");
        } 
        catch (CarInvalidSpeedUp e) {
            Console.WriteLine($"CarInvalidSpeedUp {e.Message}");
        }
        catch (CarIsDeadException2 e) {
            Console.WriteLine($"CarIsDeadException2 {e.Message}");
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
            //Console.WriteLine(e.StackTrace);
        } 
        finally {
            Console.WriteLine("Finally in");
            c1.Tune(false);
            Console.WriteLine("Finally out");
        }
    }
}

namespace ClassesAndExceptions {

    class Car {
        private int speed;
        private int maxspeed;
        private string petName;
        bool dead;
        private Radio theMusicBox = new Radio();

        public Car(int speed, int maxspeed, string name) {
            this.speed = speed;
            this.maxspeed = maxspeed;
            petName = name;
            dead = false;
        }

        public void SpeedUp(int delta) {
            if (dead) {
                throw new CarIsDeadException2($"{petName} is dead now");
                //throw new CarIsDeadException(petName);
                //throw new Exception("This car is already dead");
                /*Console.WriteLine($"{petName} is dead...");*/
            } else {
                if (delta < 0) {
                    throw new ArgumentOutOfRangeException($"Must be grater than zero");
                } else if (delta > 50) {
                    throw new CarInvalidSpeedUp($"Invalid acceleration for {petName}");
                }
                speed += delta;
                if (speed < maxspeed) {
                    Console.WriteLine($"\tCurrent speed = {speed}");
                } else {
                    Console.WriteLine($"{petName} has overheated");
                    dead = true;
                }
            }
        }

        public void Tune(bool state) {
            theMusicBox.TurnOn(state);
        }
    }

    class CarIsDeadException : Exception {
        private string carName;

        public CarIsDeadException( ) {
        }

        public CarIsDeadException(string carName) {
            this.carName = carName;
        }

        public override string Message {
            get {
                string msg = base.Message;
                if (carName != null) {
                    msg += $"\n{carName} has been destroyed";
                }
                return msg;
            }
        }
    }

    class CarIsDeadException2 : Exception {
        public CarIsDeadException2( ) {
        }

        public CarIsDeadException2(string message) : base(message) {
        }
    }

    class Radio {
        public Radio( ) {
        }

        ~Radio( ) {
            Console.WriteLine("Radio is now destroyed");
        }

        public void TurnOn(bool on) {
            if (on) {
                Console.WriteLine("Radio is on now");
            } else {
                Console.WriteLine("Radio is quiet now");
            }
        }
    }

    class CarInvalidSpeedUp : Exception {
        public CarInvalidSpeedUp( ) {
        }

        public CarInvalidSpeedUp(string message) : base(message) {
        }
    }
}