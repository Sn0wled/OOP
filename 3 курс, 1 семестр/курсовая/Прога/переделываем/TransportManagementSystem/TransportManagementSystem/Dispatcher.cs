namespace TransportManagementSystem
{
    internal class Dispatcher : User
    {
        public Dispatcher(string login, string password, string fName, string lName, string pName, int age)
            : base(login, password, fName, lName, pName, age) { }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Должность: Диспетчер");
        }
    }
}
