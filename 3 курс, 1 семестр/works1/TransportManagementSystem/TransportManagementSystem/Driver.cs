namespace TransportManagementSystem
{
    internal class Driver : User
    {
        public Driver(int id, string login, string password, string fName, string lName, string pName, int age, Gender gender)
            : base(id, login, password, fName, lName, pName, age, gender) { }
        public override void Menu(TransportManagementSystem tMS) { 
        }
    }
}
