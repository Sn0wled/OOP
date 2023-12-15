namespace TransportManagementSystem
{
    internal class UserSystem
    {
        List<User> users = new();
        int counter = 0;
        // надо поменять
        public void AddUser()
        {
            string fName, lName, pName, login, password, sAge, sGender, post;
            int age;
            Gender gender;
            User user;
            Console.WriteLine("Добавление нового пользователя");
            Console.Write("Введите логин пользователя: ");
            login = Console.ReadLine()!;
            while (users.Find(x => x.CheckLogin(login)) is not null)
            {
                Console.Write("Логин занят. Введите другой: ");
                login = Console.ReadLine()!;
            }
            Console.Write("Введите пароль пользователя: ");
            password = Console.ReadLine()!;
            Console.Write("Введите имя пользователя: ");
            fName = Console.ReadLine()!;
            Console.Write("Введите фамилию пользователя: ");
            lName = Console.ReadLine()!;
            Console.Write("Введите отчество пользователя: ");
            pName = Console.ReadLine()!;
            while (true) 
            {
                Console.Write("Введите возраст пользователя: ");
                sAge = Console.ReadLine()!;
                if (int.TryParse(sAge, out age))
                    break;
                else
                    Console.WriteLine("Ошибка ввода. Введено не число.");
            }
            while (true)
            {
                Console.Write("Введите пол пользователя: ");
                sGender = Console.ReadLine()!;
                if (sGender.Equals("м"))
                {
                    gender = Gender.Male;
                    break;
                }
                else if (sGender.Equals("ж"))
                {
                    gender = Gender.Female;
                    break;
                }
                else
                    Console.WriteLine("Ошибка");
            }
            while(true)
            {
                Console.WriteLine("Введите должность: ");
                Console.WriteLine("1. Администратор");
                Console.WriteLine("2. Диспетчер");
                Console.WriteLine("3. Водитель");
                post = Console.ReadLine()!;
                if (post.Equals("1"))
                {
                    user = new Admin(counter++, login, password, fName, lName, pName, age, gender);
                    break;
                }
                else if (post.Equals("2"))
                {
                    user = new Dispatcher(counter++, login, password, fName, lName, pName, age, gender);
                    break;
                }
                else if (post.Equals("3"))
                {
                    user = new Driver(counter++, login, password, fName, lName, pName, age, gender);
                    break;
                }
                else
                {
                    Console.WriteLine("Неверно выбрана должность");
                }
            }
            users.Add(user);
        }
        public User? TryLogIn(string login, string password)
        {
            return users.Find(x => x.LogIn(login, password));
        }
        public void ShowAllUsers()
        {
            foreach (var user in users)
                user.ShowInfo();
        }

        public void FindUser() {
            Console.WriteLine("Введите id пользователя");
            string sID = Console.ReadLine()!;
            int id;
            while (!int.TryParse(sID, out id)) {
                Console.WriteLine("Введено не число");
                Console.WriteLine("Введите id пользователя");
                sID = Console.ReadLine()!;
            }
            User? user = users.Find(x => x.HasID(id));
            if (user == null) {
                Console.WriteLine("пользователь не найден");
                return;
            } else {
                FoundUserMenu(user);
            }
        }

        public void FoundUserMenu(User user ) {
            while (true) {
                user.ShowInfo();
                Console.WriteLine("Выбеирте действие:");
                Console.WriteLine("1. Удалить пользователя");
                Console.WriteLine("2. Изменить данные пользователя");
                Console.WriteLine("0. Вернуться назад");
                string s = Console.ReadLine()!;
                switch (s) {
                    case "1":
                        users.Remove(user);
                        return;
                    case "2":
                        user.ChangeData();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Ошибка ввода");
                        break;
                }
            }
        }
    }
}
