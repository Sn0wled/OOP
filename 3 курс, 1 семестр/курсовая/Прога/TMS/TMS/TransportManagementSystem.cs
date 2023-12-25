namespace TransportManagementSystem;
public class TransportManagementSystem
{

    public TransportManagementSystem()
    {
        vSystem = new();
        aSystem = new();
        tSystem = new();
        currentUser = null;
    }

    private readonly VehicleSystem vSystem;

    private readonly AuthorizationSystem aSystem;

    private readonly TransportationSystem tSystem;

    private User? currentUser;

    public void StartMenu()
    {
        string s;
        do
        {
            Console.WriteLine("Выберите действие:\n" +
                "1. Войти в систему\n" +
                "2. Зарегистрироваться\n" +
                "3. Показать список пользователей\n" +
                "0. Закрыть программу");
            s = Console.ReadLine()!;
            Console.Clear();
            switch(s)
            {
                case "0":
                    return;
                case "1":
                    Authorization();
                    break;
                case "2":
                    Registration();
                    break;
                case "3":
                    ShowUsers();
                    break;
                default:
                    Console.WriteLine("Такого варианта нет");
                    break;
            }
        } while (s != "0");
    }

    protected void Registration()
    {
        Console.Write("Введите ваше имя: ");
        string name = Console.ReadLine()!;
        Console.WriteLine("Выберите роль:\n" +
            "1. Диспетчер\n" +
            "2. Водитель");
        User? newUser = null;
        while (newUser == null)
        {
            string s = Console.ReadLine()!;
            switch (s)
            {
                case "1":
                    newUser = new Dispatcher(name);
                    break;
                case "2":
                    newUser = new Driver(name);
                    break;
                default:
                    Console.WriteLine("Такого варианта нет");
                    break;
            }
        }
        Console.Clear();
        Console.WriteLine($"Вы зарегистрированы. Ваш id - {aSystem.AddObject(newUser)}");
    }

    protected void ShowUsers()
    {
        aSystem.ShowObjects();
    }

    protected void Authorization()
    {
        Console.Write("Введите ваш id: ");
        int id = Programm.ReadInt();
        currentUser = (User?)aSystem.FindObject(id);
        Console.Clear();
        if (currentUser == null)
        {
            Console.WriteLine("Данный пользователь не найден");
        }
        else
        {
            Console.WriteLine("Вы успешно вошли");
            Menu();
        }
    }

    protected void Menu()
    {
        if (currentUser == null)
        {
            Console.WriteLine("Вы не вошли в систему");
            return;
        }
        else if (currentUser is Dispatcher)
        {
            DispatcherMenu();
        }
        else if (currentUser is Driver)
        {
            DriverMenu();
        }
    }

    protected void DispatcherMenu()
    {
        string s;
        do
        {
            Console.WriteLine("Меню Диспетчера:\n");
            Console.WriteLine("Ваши данные:");
            currentUser!.ShowObject();
            Console.WriteLine("\nВыберите действие\n" +
                "1. Посмотреть списки\n" +

                "2. Создать перевозку\n" +
                "3. Редактировать перевозку\n" +
                "4. Запустить перевозку\n" +
                "5. Удалить перевозку\n" +
                "6. Прервать перевозку\n" +

                "7. Другие функции\n" +
                "0. Выйти");
            s = Console.ReadLine()!;
            Console.Clear();
            switch (s)
            {
                case "0":
                    return;
                case "1":
                    ShowLists();
                    break;
                case "2":
                    CreateTransportation();
                    break;
                case "3":
                    EditTransportation();
                    break;
                case "4":
                    StartTransportation();
                    break;
                case "5":
                    DelTransportation();
                    break;
                case "6":
                    CancelTransportation();
                    break;
                case "7":
                    OtherFuntioncs();
                    break;
                default:
                    Console.WriteLine("Такого варианта нет");
                    break;
            }
        } while (s != "0");
        
    }

    protected void ShowLists()
    {
        string s;
        do
        {
            Console.WriteLine("Просмотр списоков\n");
            Console.WriteLine("Выберите список:\n" +
                "1. Список перевозок\n" +
                "2. Список транспорта\n" +
                "3. Список водителей\n" +
                "0. Вернуться назад");
            s = Console.ReadLine()!;
            Console.Clear();
            switch (s)
            {
                case "0":
                    break;
                case "1":
                    tSystem.ShowObjects();
                    break;
                case "2":
                    vSystem.ShowObjects();
                    break;
                case "3":
                    aSystem.ShowDrivers();
                    break;
                default:
                    Console.WriteLine("Такого варианта нет");
                    break;
            }
        } while (s != "0");
    }

    protected void CreateTransportation()
    {
        Console.Write("Введите название перевозки: ");
        string name = Console.ReadLine()!;
        Console.Clear();
        Transportation transportation = new(name);
        int id = tSystem.AddObject(transportation);
        Console.WriteLine($"Перевозка создана. Её id: {id}\n");
    }

    protected void EditTransportation()
    {
        Console.Write("Введите id перевозки: ");
        int id = Programm.ReadInt();
        Transportation? transportation = tSystem.FindObject(id) as Transportation;
        if (transportation is not null)
        {
            string s;
            do
            {
                Console.WriteLine("Редактирование перевозки\n");
                transportation.ShowObject();
                Console.WriteLine("\nВыберите действие\n" +
                    "1. Добавить перевозку в прямом сообщении");
                if (!transportation.IsEmpty())
                {
                    Console.WriteLine("2. Удалить последнюю перевозку в прямом сообщении");
                }
                Console.WriteLine("0. Вернуться назад");
                s = Console.ReadLine()!;
                Console.Clear();
                switch (s)
                {
                    case "0":
                        return;
                    case "1":
                        AddToTransportation(transportation);
                        break;
                    case "2":
                        transportation.DelLastDT();
                        break;
                    default:
                        Console.WriteLine("Такого варианта нет");
                        break;
                }
            } while (s != "0");
        }
        else
        {
            Console.WriteLine("Перевозка с данным id не найдена");
        }
        Console.WriteLine();
    }

    protected void AddToTransportation(Transportation transportation)
    {
        if (transportation.Status == Status.Finished || transportation.Status == Status.Canceled)
        {
            Console.WriteLine("Перевозка уже завершена или отменена");
        }
        else
        {
            // определение исполняющего транспорта
            Console.Write("Введите id транспортного средства: ");
            int? id = Programm.ReadInt();
            Vehicle? veh = (Vehicle?)vSystem.FindObject((int)id);
            Console.Clear();

            if (veh != null)
            {
                id = tSystem.HasTransportationWithVeh(veh, transportation.ID);
                if (id == null)
                {
                    double latitude, longitude;
                    string name;
                    // определение начальной точки
                    Point? start = transportation.GetLastPoint();
                    if (start is null)
                    {
                        Console.WriteLine("Введите начальную точку: ");
                        Console.Write("Введите широту: ");
                        latitude = Programm.ReadReal();
                        Console.Write("Введите долготу: ");
                        longitude = Programm.ReadReal();
                        Console.Write("Введите название точки: ");
                        name = Console.ReadLine()!;
                        Console.Clear();
                        start = new Point(new Coordinates(longitude, latitude), name);
                    }

                    // определение конечной точки
                    Point end;
                    Console.WriteLine("Введите конечную точку: ");
                    Console.Write("Введите широту: ");
                    latitude = Programm.ReadReal();
                    Console.Write("Введите долготу: ");
                    longitude = Programm.ReadReal();
                    Console.Write("Введите название точки: ");
                    name = Console.ReadLine()!;
                    Console.Clear();
                    end = new Point(new Coordinates(longitude, latitude), name);

                    // добавление
                    transportation.AddToEndDT(new DirectTransportation(start, end, veh, transportation));
                    Console.WriteLine("Перевозка в прямом сообщении добавлена");
                }
                else
                {
                    Console.WriteLine($"Данный транспорт присутствует в другой перевозке с id {id}");
                }
            }
            else
            {
                Console.WriteLine("Транспортное средство с данным id не найден");
            }
        }
        Console.WriteLine();
    }

    protected void StartTransportation()
    {
        Console.Write("Введите id перевозки: ");
        int id = Programm.ReadInt();
        Console.Clear();
        Transportation? transportation = tSystem.FindObject(id) as Transportation;
        if (transportation is not null)
        {
            if (transportation.Status != Status.NotStarted)
            {
                Console.WriteLine("Перевозка уже была начата");
            }
            else
            {
                transportation.StartTransportation();
                Console.WriteLine("Перевозка начата");
            }
        }
        else
        {
            Console.WriteLine("Перевозка с данным id не найдена");
        }
        Console.WriteLine();
    }

    protected void DelTransportation()
    {
        Console.Write("Введите id перевозки: ");
        int id = Programm.ReadInt();
        Console.Clear();
        Transportation? transportation = tSystem.FindObject(id) as Transportation;
        if (transportation is not null)
        {
            if (transportation.Status == Status.Started)
            {
                Console.WriteLine("Перевозка еще не завершена");
            }
            else
            {
                tSystem.DelObject(id);
                Console.WriteLine("Перевозка удалена");
            }
        }
        else
        {
            Console.WriteLine("Перевозка с данным id не найдена");
        }
        Console.WriteLine();
    }

    protected void CancelTransportation()
    {
        Console.Write("Введите id перевозки: ");
        int id = Programm.ReadInt();
        Console.Clear();
        Transportation? transportation = tSystem.FindObject(id) as Transportation;
        if (transportation is not null)
        {
            if (transportation.Cancel())
            {
                Console.WriteLine("Перевозка отменена");
            }
            else
            {
                Console.WriteLine("Перевозка уже завершена или еще не начата"); ;
            }
        }
        else
        {
            Console.WriteLine("Перевозка с данным id не найдена");
        }
        Console.WriteLine();
    }

    protected void OtherFuntioncs()
    {
        string s;
        do
        {
            Console.WriteLine("\nВыберите действие\n" +
                "1. Добавить трансортное средство\n" +
                "2. Удалить транспортное средство\n" +
                "3. Назначить водителю транспортное средство\n" +
                "4. Отнять у водителя транспортное средство\n" +
                "0. Назад");
            s = Console.ReadLine()!;
            Console.Clear();
            switch (s)
            {
                case "0":
                    return;
                case "1":
                    AddVehicle();
                    break;
                case "2":
                    DelVehicle();
                    break;
                case "3":
                    SetVehicleForDriver();
                    break;
                case "4":
                    UnsetVehicleForDriver();
                    break;
                default:
                    Console.WriteLine("Такого варианта нет");
                    break;
            }
        } while (s != "0");
    }

    protected void AddVehicle()
    {
        Console.Write("Введите модель добавляемого транспортного средства: ");
        string name = Console.ReadLine()!;
        Console.WriteLine("Выберите тип добавляемого транспортного средства:\n" +
            "1. Водный транспорт\n" +
            "2. Автомобиль\n" +
            "3. Железнодорожный транспорт\n" +
            "4. Воздушное судно");
        Vehicle? veh = null;
        while (veh is null)
        {
            string s = Console.ReadLine()!;
            switch (s)
            {
                case "1":
                    veh = new WaterVehicle(name);
                    break;
                case "2":
                    veh = new Automobile(name);
                    break;
                case "3":
                    veh = new RailwayVehicle(name);
                    break;
                case "4":
                    veh = new Aircraft(name);
                    break;
                default:
                    Console.WriteLine("Такого варианта нет");
                    break;
            }
        }
        int id = vSystem.AddObject(veh);
        Console.WriteLine($"Транспорт добавлен. Его id: {id}\n");
    }

    protected void DelVehicle()
    {
        Console.Write("Введите id транспортного средства: ");
        int id = Programm.ReadInt();
        Vehicle? veh = (Vehicle?)vSystem.FindObject(id);
        Console.Clear();
        if (veh != null)
        {
            int? tID;
            tID = tSystem.HasTransportationWithVeh(veh);
            if (tID != null)
            {
                Console.WriteLine($"Данный транспорт присутствует в перевозке с id {tID}");
            }
            else
            {
                vSystem.DelObject(id);
                Console.WriteLine("Транспортное средство удалено");
            }
        }
        else
        {
            Console.WriteLine("Транспортное средство с данным id не найдено");
        }
        Console.WriteLine();
    }

    protected void SetVehicleForDriver()
    {
        Console.Write("Введите id водителя: ");
        int id = Programm.ReadInt();
        User? user = (User?)aSystem.FindObject(id);
        Console.Clear();
        if (user is Driver driver)
        {
            if (driver.Vehicle != null)
            {
                Console.WriteLine("У данного водителя уже есть транспортное средство");
            }
            else
            {
                Console.Write("Введите id транспортного средства: ");
                id = Programm.ReadInt();
                Vehicle? veh = (Vehicle?)vSystem.FindObject(id);
                Console.Clear();
                if (veh == null)
                {
                    Console.WriteLine("Транспортное средство с данным id не найдено");
                }
                 else if (veh.Driver != null)
                {
                    Console.WriteLine("У данного транспортного средства уже есть водитель");
                }
                else
                {
                    veh.Driver = driver; ;
                    driver.Vehicle = veh;
                    Console.WriteLine("Транспортное средство назначено");
                }
            }
        }
        else
        {
            Console.WriteLine("Водитель с данным id не найден");
        }
        Console.WriteLine();
    }

    protected void UnsetVehicleForDriver()
    {
        Console.Write("Введите id водителя: ");
        int id = Programm.ReadInt();
        User? user = (User?)aSystem.FindObject(id);
        Console.Clear();
        if (user is Driver d)
        {
            Vehicle? veh = d.Vehicle;
            if (veh != null)
            {
                int? tID;
                tID = tSystem.HasTransportationWithVeh(veh);
                if (tID != null)
                {
                    Console.WriteLine($"Данный транспорт присутствует в перевозке с id {tID}");
                }
                else
                {
                    d.Vehicle = null;
                    veh.Driver = null;
                    Console.WriteLine("Транспорт отнят");
                }
            }
            else
            {
                Console.WriteLine("У данного водителя нет транспортного средства");
            }
        }
        else
        {
            Console.WriteLine("Водитель с данным id не найден");
        }
        Console.WriteLine();
    }

    protected void DriverMenu()
    {
        do
        {
            Console.WriteLine("Меню водителя:\n");
            Console.WriteLine("Ваши данные:");
            currentUser!.ShowObject();
            Console.WriteLine("\nВыберите действие");
            Vehicle? userVeh = ((Driver)currentUser).Vehicle;
            if (userVeh != null)
            {
                Console.WriteLine("1. Переместиться");
                if (userVeh.DTransportation != null)
                {
                    Console.WriteLine("2. Посмотреть задание");
                }
            }
            Console.WriteLine("0. Выйти");
            string s = Console.ReadLine()!;
            Console.Clear();
            switch (s)
            {
                case "1":
                    if (userVeh != null)
                    {
                        Move();
                    }
                    break;
                case "2":
                    if (userVeh?.DTransportation != null)
                    {
                        userVeh.DTransportation.ShowInfo();
                    }
                    else
                    {
                        goto case "0";
                    }
                    break;
                case "0":
                    currentUser = null;
                    return;
                default:
                    Console.WriteLine("Такого варианта нет");
                    break;
            }
        } while (currentUser != null);
    }
    protected void Move()
    {
        if (currentUser is Driver d)
        {
            Console.Write("Введите широту: ");
            double latitude = Programm.ReadReal();
            Console.Write("Введите долготу: ");
            double longitude = Programm.ReadReal();
            Console.Clear();
            d.Move(longitude, latitude);
        }
    }
}