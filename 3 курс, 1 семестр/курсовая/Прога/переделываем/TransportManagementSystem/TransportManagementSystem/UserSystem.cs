namespace TransportManagementSystem
{
    internal class UserSystem
    {
        List<User> users = new();
        int counter = 0;

        public void Test()
        {
            users.Add(new Admin(counter++, "111", "111", "111", "111", "111", 20, Gender.Male));
            users.Add(new Dispatcher(counter++, "222", "222", "222", "222", "222", 20, Gender.Male));
            users.Add(new Driver(counter++, "333", "333", "333", "333", "333", 20, Gender.Male));
        }

        public Driver? FindDriver(int id)
        {
            return (Driver?)users.Find(x => x is Driver && x.HasID(id));
        }

        public void AddUser()
        {
            string fName, lName, pName, login, password, sGender, post;
            int age;
            Gender gender;
            User user;
            Console.WriteLine("Добавление нового пользователя");
            while (true)
            {
                Console.Write("Введите логин пользователя: ");
                login = Console.ReadLine()!;
                if (login.Length >= 5) break;
                Console.WriteLine("Логин должен содержать не менее 5 символов");
            }
            while (users.Find(x => x.HasLogin(login)) is not null)
            {
                Console.Write("Логин занят. Введите другой: ");
                login = Console.ReadLine()!;
            }

            while (true)
            {
                Console.Write("Введите пароль пользователя: ");
                password = Console.ReadLine()!;
                if (password.Length >= 5) break;
                Console.WriteLine("Пароль должен содержать не менее 5 символов");
            }

            while (true)
            {
                Console.Write("Введите имя пользователя: ");
                fName = Console.ReadLine()!;
                if (fName.Length != 0) break;
                Console.WriteLine("Имя не может быть пустым");
            }

            while (true)
            {
                Console.Write("Введите фамилию пользователя: ");
                lName = Console.ReadLine()!;
                if (lName.Length != 0) break;
                Console.WriteLine("Фамилия не может быть пустой");
            }

            Console.Write("Введите отчество пользователя: ");
            pName = Console.ReadLine()!;
            while (true)
            {
                age = Programm.EnterInt("Введите возраст пользователя: ");
                if (age < 18)
                    Console.WriteLine("Пользователю не может быть меньше 18 лет");
                else
                    break;
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
            while (true)
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
            if (users.Count == 0)
                Console.WriteLine("Список пуст");
            else
                foreach (var user in users)
                    user.ShowInfo();
        }

        public void FindUser()
        {
            int id = Programm.EnterInt("Введите id пользователя");
            User? user = users.Find(x => x.HasID(id));
            if (user == null)
            {
                Console.WriteLine("Пользователь не найден");
                return;
            }
            else
            {
                FoundUserMenu(user);
            }
        }

        public void FoundUserMenu(User user)
        {
            while (true)
            {
                user.ShowInfo();
                Console.WriteLine();
                Console.WriteLine("Выбеирте действие:");
                Console.WriteLine("1. Удалить пользователя");
                Console.WriteLine("2. Изменить данные пользователя");
                Console.WriteLine("0. Вернуться назад");
                string s = Console.ReadLine()!;
                switch (s)
                {
                    case "1":
                        if (users.Contains(user))
                        {
                            Console.WriteLine("Вы не можете удалить сами себя");
                            break;
                        }
                        else
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

        public void ShowDrivers()
        {
            Console.WriteLine("Список водителей:");
            int c = 0;
            foreach (User user in users)
            {
                if (user is Driver)
                {
                    user.ShowInfo();
                    c++;
                }
                if (c == 0) Console.WriteLine("Список пуст");
            }
        }
    }
}
