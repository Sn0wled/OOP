namespace UserInterface
{
    using TransportManagementSystem;
    // Класс определяет, как программа взаимодейтсвует с пользователем
    // Методы подразделяются на:
    // 1. Взаимодействующие только с пользователем
    // 2. Выводит информацию, хранящуюся в системе
    static internal class Menu
    {
        // Выводит в консоль данные юнита
        static public void ShowUnit(Unit unit)
        {
            if (unit is WayPoint wayPoint)
            {
                Console.WriteLine($"Название: {wayPoint.Name}");
                Console.WriteLine($"Описание: {wayPoint.Description}");
                Console.WriteLine("Координаты");
                ShowCoordinates(wayPoint.Coords);
                string state = wayPoint.Checkbox == true ? "Пройдена" : "Не пройдена";
                Console.WriteLine($"Состояние: {state}");
                return;
            }
            Console.WriteLine($"ID: {unit.ID}");
            if (unit is User user)
            {
                Console.WriteLine($"Имя: {user.FName}");
                Console.WriteLine($"Фамилия: {user.LName}");
                Console.WriteLine($"Отчество: {user.PName}");
                Console.WriteLine($"Возраст: {user.Age}");
                if (unit is Admin)
                {
                    Console.WriteLine("Должность: Администратор");
                }
                else if (unit is Dispatcher)
                {
                    Console.WriteLine("Должность: Диспетчер");
                }
                else if (unit is Driver driver)
                {
                    Console.WriteLine("Должность: Водитель");
                    string state = driver.Route is null ? "Свободен" : "Занят";
                    string tStatus = driver.Transport is null ? "Нет" : "Есть";
                    Console.WriteLine($"Статус: {state}");
                    Console.WriteLine($"Транспорт: {tStatus}");
                }
            }
            else if (unit is Point point)
            {
                Console.WriteLine($"Название: {point.Name}");
                Console.WriteLine($"Описание: {point.Description}");
                Console.WriteLine("Координаты");
                ShowCoordinates(point.Coords);
            }
            else if (unit is Transport transport)
            {
                Console.WriteLine($"Модель: {transport.Model}");
                Console.WriteLine($"Координаты");
                ShowCoordinates(transport.Coords);
                string sState = transport.HasDriver ? "Занят" : "Свободен";
                Console.WriteLine($"Состояние: {sState}");
            }
        }

        // Выводит в консоль список юнитов системы
        static public void ShowUnits(UnitSystem us)
        {
            Console.Clear();
            if (us is PointsSystem)
            {
                Console.WriteLine("Список доступных пунктов");
            }
            else if (us is RouteSystem)
            {
                Console.WriteLine("Список доступных маршрутов");
            }
            else if (us is TransportSystem)
            {
                Console.WriteLine("Список доступного транспорта");
            }
            else if (us is UserSystem)
            {
                Console.WriteLine("Список пользователей");
            }
            Console.WriteLine();
            if (us.IsEmpty())
            {
                Console.WriteLine("Список пуст");
            }
            else
            {
                foreach (Unit unit in us)
                {
                    ShowUnit(unit);
                    Console.WriteLine();
                }
            }
        }

        static public void ShowRoute(Route route)
        {
            Console.Clear();
            Console.WriteLine("Маршрут");
            ShowUnit(route);
            Console.WriteLine();
            if (route.IsEmpty())
            {
                Console.WriteLine("Список пуст");
            }
            else
            {
                foreach (Unit unit in route)
                {
                    ShowUnit(unit);
                    Console.WriteLine();
                }
            }
        }

        // выводит в консоль координаты
        static public void ShowCoordinates(Coordinates coords)
        {
            Console.WriteLine($"Широта: {coords.Latitude}, Долгота: {coords.Longitude}");
        }

        // Меню для входа
        public static void LogInMenu(out string login, out string password)
        {
            Console.Clear();
            Console.Write("Введите логин: ");
            login = Console.ReadLine()!;
            Console.Write("Введите пароль: ");
            password = Console.ReadLine()!;
        }

        // Выводит в консоль результат входа
        // Для этого методу нужно передать этот результат
        public static void LogInResult(bool result)
        {
            if (result) Console.WriteLine("Вы успешно вошли");
            else Console.WriteLine("Неправильный логин или пароль");
        }

        // вспомогательный метод для ввода целого числа
        public static int EnterInt(string message)
        {
            Console.WriteLine(message);
            string sNum = Console.ReadLine()!;
            int num;
            while (!int.TryParse(sNum, out num))
            {
                Console.WriteLine("Введено не целое число");
                Console.WriteLine(message);
                sNum = Console.ReadLine()!;
            }
            return num;
        }

        // вспомогательный метод для ввода вещественного числа
        public static double EnterDouble(string message)
        {
            Console.WriteLine(message);
            string sNum = Console.ReadLine()!;
            double num;
            while (!double.TryParse(sNum, out num))
            {
                Console.WriteLine("Введено не число");
                Console.WriteLine(message);
                sNum = Console.ReadLine()!;
            }
            return num;
        }

        // вспомогательный метод для ввода строк
        static string EnterString(string message, string? errMessage = null, int minChars = 0)
        {
            string result;
            while (true)
            {
                Console.Write(message);
                result = Console.ReadLine()!;
                if (result.Length < minChars)
                {
                    Console.WriteLine(errMessage);
                }
                else return result;
            }
        }

        // Сообщение приветственного экрана
        public static string WelcomeScreenMessage()
        {
            Console.WriteLine("1. Войти");
            Console.WriteLine("0. Закрыть программу");
            return Console.ReadLine()!;
        }

        public static void ErrorInput()
        {
            Console.WriteLine("Выбранного варианта нет");
        }

        // Меню администратора
        public static string AdminMenu()
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
            return Console.ReadLine()!;
        }

        // Меню димпетчера
        public static void DispatcherMenu()
        {

        }

        // Меню Водителя
        public static void DriverMenu()
        {

        }

        public static User CreateUser(UserSystem us)
        {
            string login, password, fName, lName, pName, post;
            int age;
            Console.Clear();
            Console.WriteLine("Добавление нового пользователя");
            while (true)
            {
                login = EnterString("Введите логин пользователя: ", "Логин должен содержать не менее 6 символов", 6);
                if (us.IsLoginFree(login))
                    break;
                else
                    Console.Write("Логин занят. Введите другой: ");
            }
            password = EnterString("Введите пароль пользователя: ", "Пароль должен содержать не менее 6 символов", 6);
            fName = EnterString("Введите имя пользователя: ", "Имя не может быть пустым", 1);
            lName = EnterString("Введите фамилию пользователя: ", "Фамилия не может быть пустой", 1);
            pName = EnterString("Введите отчество пользователя: ");
            while (true)
            {
                age = EnterInt("Введите возраст пользователя: ");
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
                    return new Admin(login, password, fName, lName, pName, age);
                else if (post.Equals("2"))
                    return new Dispatcher(login, password, fName, lName, pName, age);
                else if (post.Equals("3"))
                    return new Driver(login, password, fName, lName, pName, age);
                else
                    ErrorInput();
            }
        }

        public static Transport CreateTransport()
        {
            string model = EnterString("Введите название модели транспорта: ", "Название не может быть пустым", 1);
            return new Transport(model);
        }

        public static Coordinates CreateCoords()
        {
            double latitude, longitude;
            Console.WriteLine("Введите координаты");
            latitude = EnterDouble("Введите широту: ");
            longitude = EnterDouble("Введите долготу: ");
            return new Coordinates(longitude, latitude);
        }

        public static Point CreatePoint()
        {
            string name, description;
            name = EnterString("Введите название точки: ");
            description = EnterString("Введите описание точки: ");
            Coordinates coords = CreateCoords();
            return new Point(coords, name, description);

        }

        public static User? SelectUser(UserSystem us)
        {
            int id = Menu.EnterInt("Введите id пользователя");
            User? user = (User?)us.FindUnit(id);
            if (user == null)
                Console.WriteLine("Пользователь с данным id не найден");
            return user;
        }

        public static string ActionsOnUser(User user)
        {
            Console.Clear();
            Console.WriteLine("Пользователь:");
            ShowUnit(user);
            Console.WriteLine();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Удалить пользователя");
            Console.WriteLine("2. Изменить данные пользователя");
            Console.WriteLine("0. Вернуться назад");
            return Console.ReadLine()!;
        }

        public static string ChangeUserData(User user)
        {
            Console.Clear();
            ShowUnit(user);
            Console.WriteLine($"Логин: {user.Login}");
            Console.WriteLine($"Пароль: {user.Password}");
            Console.WriteLine();
            Console.WriteLine("Выберите действие над пользователем:");
            Console.WriteLine("1. Изменить имя");
            Console.WriteLine("2. Изменить фамилию");
            Console.WriteLine("3. Изменить отчество");
            Console.WriteLine("4. Изменить возраст");
            Console.WriteLine("5. Изменить пол");
            Console.WriteLine("6. Изменить логин");
            Console.WriteLine("7. Изменить пароль");
            Console.WriteLine("0. Вернуться назад");
            return Console.ReadLine()!;
        }
    }
}
