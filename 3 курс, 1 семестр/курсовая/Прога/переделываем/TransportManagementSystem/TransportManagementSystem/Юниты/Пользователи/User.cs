namespace TransportManagementSystem
{
    internal abstract class User : Unit
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PName { get; set; }
        public int Age { get; set; }
        public User(string login, string password, string fName, string lName, string pName, int age)
        {
            Login = login;
            Password = password;
            FName = fName;
            LName = lName;
            PName = pName;
            Age = age;
        }

        public bool HasLogin(string login)
        {
            return Login == login;
        }

        public bool TryLogin(string login, string password)
        {
            return login == Login && password == Password;
        }

        public abstract void Menu(TransportManagementSystem tms);

        public override void ShowUnit()
        {
            base.ShowUnit();
            Console.WriteLine($"Имя: {FName}");
            Console.WriteLine($"Фамилия: {LName}");
            Console.WriteLine($"Отчество: {PName}");
            Console.WriteLine($"Возраст: {Age}");
        }

        public override void ChangeUnitData(TransportManagementSystem? tms = null)
        {
            string s = "";
            while (s != "0")
            {
                Console.Clear();
                ShowUnit();
                Console.WriteLine($"Логин: {Login}");
                Console.WriteLine($"Пароль: {Password}");
                Console.WriteLine();
                Console.WriteLine("Выберите действие над пользователем:");
                Console.WriteLine("1. Изменить имя");
                Console.WriteLine("2. Изменить фамилию");
                Console.WriteLine("3. Изменить отчество");
                Console.WriteLine("4. Изменить возраст");
                Console.WriteLine("5. Изменить логин");
                Console.WriteLine("6. Изменить пароль");
                Console.WriteLine("0. Вернуться назад");
                s = Console.ReadLine()!;
                Console.Clear();
                ShowUnit();
                Console.WriteLine($"Логин: {Login}");
                Console.WriteLine($"Пароль: {Password}");
                Console.WriteLine();
                switch (s)
                {
                    case "0":
                        break;
                    case "1":
                        FName = Program.EnterString("Введите новое имя: ", "Имя не может быть пустым", 1);
                        break;
                    case "2":
                        LName = Program.EnterString("Введите новую фамилию: ", "Фамилия не может быть пустой", 1);
                        break;
                    case "3":
                        PName = Program.EnterString("Введите новое отчество: ");
                        break;
                    case "4":
                        int age = Program.EnterInt("Введите новый возраст: ");
                        if (age < 18)
                            Console.WriteLine("Пользователю не может быть меньше 18 лет");
                        else
                            Age = age;
                        break;
                    case "5":
                        Login = Program.EnterString("Введите новый логин: ", "Логин должен содержать не менее 6 символов", 6);
                        break;
                    case "6":
                        Password = Program.EnterString("Введите новый пароль: ", "Пароль должен содержать не менее 6 символов", 6);
                        break;
                    default:
                        Program.ErrorInput();
                        break;
                }
            }
        }
    }
}
