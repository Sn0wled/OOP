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
            Console.WriteLine("�������� ��������:\n" +
                "1. ����� � �������\n" +
                "2. ������������������\n" +
                "3. �������� ������ �������������\n" +
                "0. ������� ���������");
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
                    Console.WriteLine("������ �������� ���");
                    break;
            }
        } while (s != "0");
    }

    protected void Registration()
    {
        Console.Write("������� ���� ���: ");
        string name = Console.ReadLine()!;
        Console.WriteLine("�������� ����:\n" +
            "1. ���������\n" +
            "2. ��������");
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
                    Console.WriteLine("������ �������� ���");
                    break;
            }
        }
        Console.Clear();
        Console.WriteLine($"�� ����������������. ��� id - {aSystem.AddObject(newUser)}");
    }

    protected void ShowUsers()
    {
        aSystem.ShowObjects();
    }

    protected void Authorization()
    {
        Console.Write("������� ��� id: ");
        int id = Programm.ReadInt();
        currentUser = (User?)aSystem.FindObject(id);
        Console.Clear();
        if (currentUser == null)
        {
            Console.WriteLine("������ ������������ �� ������");
        }
        else
        {
            Console.WriteLine("�� ������� �����");
            Menu();
        }
    }

    protected void Menu()
    {
        if (currentUser == null)
        {
            Console.WriteLine("�� �� ����� � �������");
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
            Console.WriteLine("���� ����������:\n");
            Console.WriteLine("���� ������:");
            currentUser!.ShowObject();
            Console.WriteLine("\n�������� ��������\n" +
                "1. ���������� ������\n" +

                "2. ������� ���������\n" +
                "3. ������������� ���������\n" +
                "4. ��������� ���������\n" +
                "5. ������� ���������\n" +
                "6. �������� ���������\n" +

                "7. ������ �������\n" +
                "0. �����");
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
                    Console.WriteLine("������ �������� ���");
                    break;
            }
        } while (s != "0");
        
    }

    protected void ShowLists()
    {
        string s;
        do
        {
            Console.WriteLine("�������� ��������\n");
            Console.WriteLine("�������� ������:\n" +
                "1. ������ ���������\n" +
                "2. ������ ����������\n" +
                "3. ������ ���������\n" +
                "0. ��������� �����");
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
                    Console.WriteLine("������ �������� ���");
                    break;
            }
        } while (s != "0");
    }

    protected void CreateTransportation()
    {
        Console.Write("������� �������� ���������: ");
        string name = Console.ReadLine()!;
        Console.Clear();
        Transportation transportation = new(name);
        int id = tSystem.AddObject(transportation);
        Console.WriteLine($"��������� �������. Ÿ id: {id}\n");
    }

    protected void EditTransportation()
    {
        Console.Write("������� id ���������: ");
        int id = Programm.ReadInt();
        Transportation? transportation = tSystem.FindObject(id) as Transportation;
        if (transportation is not null)
        {
            string s;
            do
            {
                Console.WriteLine("�������������� ���������\n");
                transportation.ShowObject();
                Console.WriteLine("\n�������� ��������\n" +
                    "1. �������� ��������� � ������ ���������");
                if (!transportation.IsEmpty())
                {
                    Console.WriteLine("2. ������� ��������� ��������� � ������ ���������");
                }
                Console.WriteLine("0. ��������� �����");
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
                        Console.WriteLine("������ �������� ���");
                        break;
                }
            } while (s != "0");
        }
        else
        {
            Console.WriteLine("��������� � ������ id �� �������");
        }
        Console.WriteLine();
    }

    protected void AddToTransportation(Transportation transportation)
    {
        if (transportation.Status == Status.Finished || transportation.Status == Status.Canceled)
        {
            Console.WriteLine("��������� ��� ��������� ��� ��������");
        }
        else
        {
            // ����������� ������������ ����������
            Console.Write("������� id ������������� ��������: ");
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
                    // ����������� ��������� �����
                    Point? start = transportation.GetLastPoint();
                    if (start is null)
                    {
                        Console.WriteLine("������� ��������� �����: ");
                        Console.Write("������� ������: ");
                        latitude = Programm.ReadReal();
                        Console.Write("������� �������: ");
                        longitude = Programm.ReadReal();
                        Console.Write("������� �������� �����: ");
                        name = Console.ReadLine()!;
                        Console.Clear();
                        start = new Point(new Coordinates(longitude, latitude), name);
                    }

                    // ����������� �������� �����
                    Point end;
                    Console.WriteLine("������� �������� �����: ");
                    Console.Write("������� ������: ");
                    latitude = Programm.ReadReal();
                    Console.Write("������� �������: ");
                    longitude = Programm.ReadReal();
                    Console.Write("������� �������� �����: ");
                    name = Console.ReadLine()!;
                    Console.Clear();
                    end = new Point(new Coordinates(longitude, latitude), name);

                    // ����������
                    transportation.AddToEndDT(new DirectTransportation(start, end, veh, transportation));
                    Console.WriteLine("��������� � ������ ��������� ���������");
                }
                else
                {
                    Console.WriteLine($"������ ��������� ������������ � ������ ��������� � id {id}");
                }
            }
            else
            {
                Console.WriteLine("������������ �������� � ������ id �� ������");
            }
        }
        Console.WriteLine();
    }

    protected void StartTransportation()
    {
        Console.Write("������� id ���������: ");
        int id = Programm.ReadInt();
        Console.Clear();
        Transportation? transportation = tSystem.FindObject(id) as Transportation;
        if (transportation is not null)
        {
            if (transportation.Status != Status.NotStarted)
            {
                Console.WriteLine("��������� ��� ���� ������");
            }
            else
            {
                transportation.StartTransportation();
                Console.WriteLine("��������� ������");
            }
        }
        else
        {
            Console.WriteLine("��������� � ������ id �� �������");
        }
        Console.WriteLine();
    }

    protected void DelTransportation()
    {
        Console.Write("������� id ���������: ");
        int id = Programm.ReadInt();
        Console.Clear();
        Transportation? transportation = tSystem.FindObject(id) as Transportation;
        if (transportation is not null)
        {
            if (transportation.Status == Status.Started)
            {
                Console.WriteLine("��������� ��� �� ���������");
            }
            else
            {
                tSystem.DelObject(id);
                Console.WriteLine("��������� �������");
            }
        }
        else
        {
            Console.WriteLine("��������� � ������ id �� �������");
        }
        Console.WriteLine();
    }

    protected void CancelTransportation()
    {
        Console.Write("������� id ���������: ");
        int id = Programm.ReadInt();
        Console.Clear();
        Transportation? transportation = tSystem.FindObject(id) as Transportation;
        if (transportation is not null)
        {
            if (transportation.Cancel())
            {
                Console.WriteLine("��������� ��������");
            }
            else
            {
                Console.WriteLine("��������� ��� ��������� ��� ��� �� ������"); ;
            }
        }
        else
        {
            Console.WriteLine("��������� � ������ id �� �������");
        }
        Console.WriteLine();
    }

    protected void OtherFuntioncs()
    {
        string s;
        do
        {
            Console.WriteLine("\n�������� ��������\n" +
                "1. �������� ����������� ��������\n" +
                "2. ������� ������������ ��������\n" +
                "3. ��������� �������� ������������ ��������\n" +
                "4. ������ � �������� ������������ ��������\n" +
                "0. �����");
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
                    Console.WriteLine("������ �������� ���");
                    break;
            }
        } while (s != "0");
    }

    protected void AddVehicle()
    {
        Console.Write("������� ������ ������������ ������������� ��������: ");
        string name = Console.ReadLine()!;
        Console.WriteLine("�������� ��� ������������ ������������� ��������:\n" +
            "1. ������ ���������\n" +
            "2. ����������\n" +
            "3. ��������������� ���������\n" +
            "4. ��������� �����");
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
                    Console.WriteLine("������ �������� ���");
                    break;
            }
        }
        int id = vSystem.AddObject(veh);
        Console.WriteLine($"��������� ��������. ��� id: {id}\n");
    }

    protected void DelVehicle()
    {
        Console.Write("������� id ������������� ��������: ");
        int id = Programm.ReadInt();
        Vehicle? veh = (Vehicle?)vSystem.FindObject(id);
        Console.Clear();
        if (veh != null)
        {
            int? tID;
            tID = tSystem.HasTransportationWithVeh(veh);
            if (tID != null)
            {
                Console.WriteLine($"������ ��������� ������������ � ��������� � id {tID}");
            }
            else
            {
                vSystem.DelObject(id);
                Console.WriteLine("������������ �������� �������");
            }
        }
        else
        {
            Console.WriteLine("������������ �������� � ������ id �� �������");
        }
        Console.WriteLine();
    }

    protected void SetVehicleForDriver()
    {
        Console.Write("������� id ��������: ");
        int id = Programm.ReadInt();
        User? user = (User?)aSystem.FindObject(id);
        Console.Clear();
        if (user is Driver driver)
        {
            if (driver.Vehicle != null)
            {
                Console.WriteLine("� ������� �������� ��� ���� ������������ ��������");
            }
            else
            {
                Console.Write("������� id ������������� ��������: ");
                id = Programm.ReadInt();
                Vehicle? veh = (Vehicle?)vSystem.FindObject(id);
                Console.Clear();
                if (veh == null)
                {
                    Console.WriteLine("������������ �������� � ������ id �� �������");
                }
                 else if (veh.Driver != null)
                {
                    Console.WriteLine("� ������� ������������� �������� ��� ���� ��������");
                }
                else
                {
                    veh.Driver = driver; ;
                    driver.Vehicle = veh;
                    Console.WriteLine("������������ �������� ���������");
                }
            }
        }
        else
        {
            Console.WriteLine("�������� � ������ id �� ������");
        }
        Console.WriteLine();
    }

    protected void UnsetVehicleForDriver()
    {
        Console.Write("������� id ��������: ");
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
                    Console.WriteLine($"������ ��������� ������������ � ��������� � id {tID}");
                }
                else
                {
                    d.Vehicle = null;
                    veh.Driver = null;
                    Console.WriteLine("��������� �����");
                }
            }
            else
            {
                Console.WriteLine("� ������� �������� ��� ������������� ��������");
            }
        }
        else
        {
            Console.WriteLine("�������� � ������ id �� ������");
        }
        Console.WriteLine();
    }

    protected void DriverMenu()
    {
        do
        {
            Console.WriteLine("���� ��������:\n");
            Console.WriteLine("���� ������:");
            currentUser!.ShowObject();
            Console.WriteLine("\n�������� ��������");
            Vehicle? userVeh = ((Driver)currentUser).Vehicle;
            if (userVeh != null)
            {
                Console.WriteLine("1. �������������");
                if (userVeh.DTransportation != null)
                {
                    Console.WriteLine("2. ���������� �������");
                }
            }
            Console.WriteLine("0. �����");
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
                    Console.WriteLine("������ �������� ���");
                    break;
            }
        } while (currentUser != null);
    }
    protected void Move()
    {
        if (currentUser is Driver d)
        {
            Console.Write("������� ������: ");
            double latitude = Programm.ReadReal();
            Console.Write("������� �������: ");
            double longitude = Programm.ReadReal();
            Console.Clear();
            d.Move(longitude, latitude);
        }
    }
}