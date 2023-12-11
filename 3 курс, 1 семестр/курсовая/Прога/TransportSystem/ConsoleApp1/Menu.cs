using System.Text;

namespace TransportSystem;

static class Menu
{
    public static void WelcomeMessage()
    {
        Console.WriteLine("Вас приветствует Система Управления \" Единая Транспортная Автоматизирование\" (С.У.Е.Т.А.)");
    }

    public static void LogInMenu(out string login, out string password)
    {
        StringBuilder sb = new StringBuilder();
        Console.Write("Введите Ваш суетной логин: ");
        login = Console.ReadLine()!;
        Console.Write("Введите Ваш суетной пароль: ");
        ConsoleKeyInfo key;
        while (true) 
        {
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter) break;
            sb.Append(key.KeyChar);
        }
        password = sb.ToString();
        Console.WriteLine();
    }

    public static void LogInSuccess(User user)
    {
        Console.WriteLine("Вы успешно авторизовались.");
        Console.WriteLine($"Здраствуйте {user.SName} {user.FName} {user.PName}\n");
    }

    public static void LogInUnuccess()
    {
        Console.WriteLine("Неправильный логин или пароль.");
    }

    public static void AdminMenu()
    {
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Добавить пользователя");
        Console.WriteLine("2. Добавить транспорт");
        Console.WriteLine("3. Удалить пользователя");
        Console.WriteLine("0. Закрыть программу");
        Console.WriteLine("Нажмите q чтобы выйти из системы.");
    }

    public static void AddUserMenu()
    {
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Добавить диспетчера");
        Console.WriteLine("2. Добавить водителя");
        Console.WriteLine("3. Добавить адинистратора");
        Console.WriteLine("0. Вернуться назад");
    }

    public static void AddingUserMenu(out string login, out string password, out string fName, out string sName, out string? pName)
    {
        Console.WriteLine("Введите логин пользователя: ");
        login = Console.ReadLine()!;
        Console.WriteLine("Введите пароль пользователя: ");
        password = Console.ReadLine()!;
        Console.WriteLine("Введите имя пользователя: ");
        fName = Console.ReadLine()!;
        Console.WriteLine("Введите фамилию пользователя: ");
        sName = Console.ReadLine()!;
        Console.WriteLine("Введите отчество пользователя (Если отчества нет, нажмите Enter): ");
        string temp = Console.ReadLine()!;
        pName = temp.Length == 0 ? null : temp;
    }
}