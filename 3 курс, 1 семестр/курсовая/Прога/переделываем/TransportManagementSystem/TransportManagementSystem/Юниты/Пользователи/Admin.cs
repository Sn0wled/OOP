namespace TransportManagementSystem
{
    internal class Admin : User
    {
        public Admin(string login, string password, string fName, string lName, string pName, int age)
            : base(login, password, fName, lName, pName, age) { }

        public override void ShowUnit()
        {
            base.ShowUnit();
            Console.WriteLine("Должность: Администратор");
        }

        public override void Menu(TransportManagementSystem tms)
        {
            string s = "";
            while (s != "0")
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Показать список пользователей");
                Console.WriteLine("2. Показать список пунктов");
                Console.WriteLine("3. Показать список транспорта");
                Console.WriteLine("4. Добавить пользователя");
                Console.WriteLine("5. Добавить транспорт");
                Console.WriteLine("6. Добавить пункт");
                Console.WriteLine("7. Выбрать пользователя по id");
                Console.WriteLine("8. Выбрать пункт по id");
                Console.WriteLine("9. Выбрать транспорт по id");
                Console.WriteLine("0. Выйти из системы");
                s = Console.ReadLine()!;
                switch (s)
                {
                    // Выйти из системы
                    case "0":
                        tms.LogOut();
                        break;
                    // Показать список пользователей
                    case "1":
                        tms.UserSystem.ShowUnits();
                        break;
                    // Показать список пунктов
                    case "2":
                        tms.PointsSystem.ShowUnits();
                        break;
                    // Показать список транспорта
                    case "3":
                        tms.TransportSystem.ShowUnits();
                        break;
                    // Добавить пользователя
                    case "4":
                        tms.UserSystem.CreateUnit();
                        break;
                    // Добавить транспорт
                    case "5":
                        tms.TransportSystem.CreateUnit();
                        break;
                    // Добавить пункт
                    case "6":
                        tms.PointsSystem.CreateUnit();
                        break;
                    // Выбрать пользователя по id
                    case "7":
                        tms.UserSystem.SelectUnit();
                        break;
                    // Выбрать пункт по id
                    case "8":
                        tms.PointsSystem.SelectUnit();
                        break;
                    //Выбрать транспорт по id
                    case "9":
                        tms.TransportSystem.SelectUnit();
                        break;
                    default:
                        Program.ErrorInput();
                        break;
                }
            }
        }
    }
}
