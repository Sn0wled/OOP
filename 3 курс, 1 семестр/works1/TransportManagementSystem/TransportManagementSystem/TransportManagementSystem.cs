namespace TransportManagementSystem
{
    internal class TransportManagementSystem
    {
        UserSystem userSystem = new();
        User? user;
        public UserSystem GetUserSystem() => userSystem;
        public void LogIn()
        {
            string login, password;
            Console.Write("Введите логин: ");
            login = Console.ReadLine()!;
            Console.Write("Введите пароль: ");
            password = Console.ReadLine()!;
            user = userSystem.TryLogIn(login, password);
            if (user is null)
                Console.WriteLine("Неправильный логин или пароль");
            else
                user.Menu(this);

        }
        public void LogOut() => user = null;
    }
}
