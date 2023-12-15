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
                Console.Write("Введите должность (Администратор / Диспетчер / Водитель): ");
                post = Console.ReadLine()!;
                if (post.Equals("Администратор"))
                {
                    user = new Admin(counter++, login, password, fName, lName, pName, age, gender);
                    break;
                }
                else if (post.Equals("Диспетчер"))
                {
                    user = new Dispatcher(counter++, login, password, fName, lName, pName, age, gender);
                    break;
                }
                else if (post.Equals("Водитель"))
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
        public User? FindUser(int id)
        {
            return users.Find(x => x.ID == id);
        }
        public void RemoveUser()
        {
            Console.Write("Введите id пользователя, которого нужно удалить: ");
            string temp = Console.ReadLine()!;
            int id;
            if (int.TryParse(temp, out id))
            {
                User? user = FindUser(id);
                if (user is null)
                    Console.WriteLine("Пользователь с данным id не найден");
                else
                {
                    users.Remove(user);
                    Console.WriteLine("Пользователь удален");
                }
            }
            else
                Console.WriteLine("Неверный ввод");
        }
    }
}
