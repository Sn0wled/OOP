namespace TransportManagementSystem
{
    internal class Admin : User
    {
        public Admin(string login, string password, string fName, string lName, string pName, int age)
            : base(login, password, fName, lName, pName, age) { }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Должность: Администратор");
        }
        
    }
}
