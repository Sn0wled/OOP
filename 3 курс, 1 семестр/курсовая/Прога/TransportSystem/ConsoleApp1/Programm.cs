namespace TransportSystem;

class Programm
{
    static User? user = null;
    static TransportSystem system = new TransportSystem();
    public static void Main(string[] args)
    {
        system.TestUser();
        while (user is null) {
            LogInMenu();
            Menu.LogInSuccess(user!);
            if (user is Administrator admin)
            {
                AdminMenu(admin);
            }
        }
    }

    static void LogInMenu()
    {
        Menu.WelcomeMessage();
        string login, password;
        while (user is null)
        {
            Menu.LogInMenu(out login, out password);
            user = system.LogIn(login, password);
            if (user == null)
            {
                Menu.LogInUnuccess();
            }
        }
        Console.Clear();
    }
    static void AdminMenu(Administrator admin)
    {
        ConsoleKeyInfo key;
        do
        {
            Menu.AdminMenu();
            key = Console.ReadKey(true);
            switch (key.KeyChar)
            {
                case '1':
                    Console.Clear();
                    AddUserMenu(admin);
                    break;
                case '2':
                    Console.Clear();
                    break;
                case '3':
                    Console.Clear();
                    break;
                case '0':
                    Console.Clear();
                    break;
                case 'q':
                    LogOut();
                    Console.Clear();
                    return;
                default: 
                    Console.Clear();
                    break;
            }
        } while (key.KeyChar != '0');
    }

    static void AddUserMenu(Administrator admin)
    {
        ConsoleKeyInfo key;
        do
        {
            Administrator.AddUser addUser;
            Menu.AddUserMenu();
            key = Console.ReadKey(true);
            switch (key.KeyChar)
            {
                case '1':
                    Console.Clear();
                    addUser = admin.AddDispatcher;
                    AddingUserMenu(addUser);
                    break;
                case '2':
                    Console.Clear();
                    addUser = admin.AddDriver;
                    AddingUserMenu(addUser);
                    break;
                case '3':
                    Console.Clear();
                    addUser = admin.AddAdmin;
                    AddingUserMenu(addUser);
                    break;
                case '0':
                    Console.Clear();
                    return;
                default:
                    Console.Clear();
                    break;
            }
        } while (key.KeyChar != '0');
    }

    static void AddingUserMenu(Administrator.AddUser addUser)
    {
        string login, password, fName, sName;
        string? pName;
        Menu.AddingUserMenu(out login, out password, out fName, out sName, out pName);
        addUser(login, password, fName, sName, pName);
        Console.WriteLine("Диспетчер добавлен");
        Console.WriteLine("Нажмите любую кнопку");
        Console.ReadKey();
        Console.Clear();
    }

    static void LogOut()
    {
        user = null;
    }
}