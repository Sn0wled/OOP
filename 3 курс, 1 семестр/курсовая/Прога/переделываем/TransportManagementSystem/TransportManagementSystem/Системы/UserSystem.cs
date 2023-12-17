
namespace TransportManagementSystem
{
    internal class UserSystem : UnitSystem
    {

        public override bool AddUnit(Unit unit)
        {
            if (unit is User user && IsLoginFree(user.Login)) base.AddUnit(unit);
            return false;
        }

        public override void ShowUnits()
        {
            Console.Clear();
            Console.WriteLine("Список доступных пользователей");
            Console.WriteLine();
            base.ShowUnits();
        }

        public bool IsLoginFree(string login)
        {
            return units.Find(x => ((User)x).HasLogin(login)) == null;
        }

        public User? LogIn()
        {
            string login, password;
            Console.Clear();
            Console.Write("Введите логин: ");
            login = Console.ReadLine()!;
            Console.Write("Введите пароль: ");
            password = Console.ReadLine()!;
            Console.Clear();
            return (User?)units.Find(x => ((User)x).TryLogin(login, password));
        }

        public override void CreateUnit()
        {
            string login, password, fName, lName, pName, post;
            int age;
            Console.Clear();
            Console.WriteLine("Добавление нового пользователя");
            while (true)
            {
                login = Program.EnterString("Введите логин пользователя: ", "Логин должен содержать не менее 6 символов", 6);
                if (IsLoginFree(login))
                    break;
                else
                    Console.WriteLine("Логин занят. Выберите другой");
            }
            password = Program.EnterString("Введите пароль пользователя: ", "Пароль должен содержать не менее 6 символов", 6);
            fName = Program.EnterString("Введите имя пользователя: ", "Имя не может быть пустым", 1);
            lName = Program.EnterString("Введите фамилию пользователя: ", "Фамилия не может быть пустой", 1);
            pName = Program.EnterString("Введите отчество пользователя: ");
            while (true)
            {
                age = Program.EnterInt("Введите возраст пользователя: ");
                if (age < 18)
                    Console.WriteLine("Пользователю не может быть меньше 18 лет");
                else
                    break;
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
                    AddUnit(new Admin(login, password, fName, lName, pName, age));
                    break;
                }
                else if (post.Equals("2"))
                {
                    AddUnit(new Dispatcher(login, password, fName, lName, pName, age));
                    break;
                }
                else if (post.Equals("3"))
                {
                    AddUnit(new Driver(login, password, fName, lName, pName, age));
                    break;
                }
                else
                    Program.ErrorInput();
            }
            Console.Clear();
            Console.WriteLine("Пользователь добавлен");
        }

        public void ShowDrivers()
        {
            Console.Clear();
            Console.WriteLine("Список водителей");
            Console.WriteLine();
            int counter = 0;
            foreach (User user in units)
                if (user is Driver driver)
                {
                    driver.ShowUnit();
                    Console.WriteLine();
                    counter++;
                }
            if (counter == 0)
                Console.WriteLine("Список пуст");
            Console.WriteLine("Нажмите любую кнопку чтобы закрыть");
            Console.ReadKey();
            Console.Clear();
        }

        public Driver? FindDriver(int id)
        {
            if (FindUnit(id) is Driver driver) return driver;
            return null;
        }
    }
}
