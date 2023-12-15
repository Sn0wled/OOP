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
                Console.WriteLine();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Просмотр всех пользователей");
                Console.WriteLine("2. Выбрать пользователя по id");
                Console.WriteLine("3. Добавить пользователя");
                Console.WriteLine("4. Посмотреть список точек");
                Console.WriteLine("5. Добавить точку");
                Console.WriteLine("6. Выбрать точку по id");
                Console.WriteLine("7. Показать список транспорта");
                Console.WriteLine("8. Добавить транспорт");
                Console.WriteLine("9. Выбрать транспорт по id");
                Console.WriteLine("0. Выйти");
                s = Console.ReadLine()!;
                Console.WriteLine();
                switch (s)
                {
                    case "1":
                        tMS.GetUserSystem().ShowAllUsers();
                        break;
                    case "2":
                        tMS.GetUserSystem().FindUser();
                        break;
                    case "3":
                        tMS.GetUserSystem().AddUser();
                        break;
                    case "0":
                        tMS.LogOut();
                        return;
                    case "4":
                        tMS.GetPointsSystem().ShowPoints();
                        break;
                    case "5":
                        tMS.GetPointsSystem().AddPoint();
                        break;
                    case "6":
                        tMS.GetPointsSystem().FindPoint();
                        break;
                    case "7":
                        tMS.GetTransportSystem().ShowTransport();
                        break;
                    case "8":
                        tMS.GetTransportSystem().AddTransport();
                        break;
                    case "9":
                        tMS.GetTransportSystem().FindTransport();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }
    }
}
