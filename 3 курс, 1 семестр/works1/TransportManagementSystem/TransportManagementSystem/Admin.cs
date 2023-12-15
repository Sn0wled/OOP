namespace TransportManagementSystem
{
    internal class Admin : User
    {
        public Admin(int id, string login, string password, string fName, string lName, string pName, int age, Gender gender)
            : base(id, login, password, fName, lName, pName, age, gender) { }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Должность: Администратор");
        }
        public override void Menu(TransportManagementSystem tMS)
        {
            string s;
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Просмотр всех пользователей");
                Console.WriteLine("2. Выбрать пользователя по id");
                Console.WriteLine("3. Добавить пользователя");
                Console.WriteLine("0. Выйти");
                s = Console.ReadLine()!;
                User? fUser;
                switch (s)
                {
                    case "1":
                        tMS.GetUserSystem().ShowAllUsers();
                        break;
                    case "2":
                        Console.Write("Введите ID пользователя: ");
                        int id;
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            fUser = tMS.GetUserSystem().FindUser(id);
                            if (fUser == null)
                                Console.WriteLine("Пользователь не найден");
                            else
                                FoundUserMenu(tMS, fUser);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка ввода");
                            break;
                        }
                        break;
                    case "3":
                        tMS.GetUserSystem().AddUser();
                        break;
                    case "0":
                        tMS.LogOut();
                        return;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }
        protected void FoundUserMenu(TransportManagementSystem tMS, User user)
        {
            string s;
            while (true)
            {
                user.ShowInfo();
                Console.WriteLine("Выберите действие над пользователем:");
                Console.WriteLine("1. Изменить данные пользователя");
                Console.WriteLine("2. Удалить пользователя");
                Console.WriteLine("0. Вернуться назад");
                s = Console.ReadLine()!;
                switch (s)
                {
                    case "1":
                        user.ChangeDataMenu();
                        break;
                    case "2":
                        tMS.GetUserSystem().RemoveUser();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }
    }
}
