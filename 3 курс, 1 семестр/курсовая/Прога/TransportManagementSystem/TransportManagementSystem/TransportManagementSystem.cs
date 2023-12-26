namespace TransportManagementSystem
{
    internal class TransportManagementSystem
    {
        UserSystem userSystem = new();
        PointsSystem pointsSystem = new();
        TransportSystem transportSystem = new();
        RouteSystem routeSystem = new();
        User? user;
        public UserSystem GetUserSystem() => userSystem;
        public PointsSystem GetPointsSystem() => pointsSystem;
        public TransportSystem GetTransportSystem() => transportSystem;
        public RouteSystem GetRouteSystem() => routeSystem;

        public void LogIn()
        {
            Console.Clear();
            string login, password;
            Console.Write("Введите логин: ");
            login = Console.ReadLine()!;
            Console.Write("Введите пароль: ");
            password = Console.ReadLine()!;
            user = userSystem.TryLogIn(login, password);
            Console.Clear();
            if (user is null)
                Console.WriteLine("Неправильный логин или пароль");
            else
                user.Menu(this);

        }
        public void LogOut() => user = null;
    }
}
