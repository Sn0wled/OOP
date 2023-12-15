using System.ComponentModel.Design;

namespace TransportManagementSystem
{
    internal abstract class User : Person
    {
        public int id;
        protected string login;
        protected string password;
        public User(int id, string login, string password, string fName, string lName, string pName, int age, Gender gender)
            : base(fName, lName, pName, age, gender)
        {
            this.id = id;
            this.login = login;
            this.password = password;
        }
        public bool LogIn(string login, string password) => login == this.login && password == this.password;
        public void ChangeLogin(string login) => this.login = login;
        public string ChangePasword(string password) => this.password = password;
        public abstract void Menu(TransportManagementSystem tMS);
        public virtual void ShowInfo()
        {
            Console.WriteLine();
            string gender = base.gender == Gender.Male ? "м" : "ж";
            string post = this is Admin ? "Администратор" : "Unknown";
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Имя: {fName}");
            Console.WriteLine($"Фамилия: {lName}");
            Console.WriteLine($"Отчество: {pName}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"Пол: {gender}");
        }
        public void ChangeData()
        {
            string s;
            while (true)
            {
                Console.WriteLine("Выберите действие над пользователем:");
                Console.WriteLine("1. Изменить имя");
                Console.WriteLine("2. Изменить фамилию");
                Console.WriteLine("3. Изменить отчество");
                Console.WriteLine("4. Изменить возраст");
                Console.WriteLine("5. Изменить пол");
                Console.WriteLine("6. Изменить логин");
                Console.WriteLine("7. Изменить пароль");
                Console.WriteLine("0. Вернуться назад");
                s = Console.ReadLine()!;
                string temp = "";
                int newAge = 0;
                switch (s)
                {
                    case "1":
                        Console.Write("Введите новое имя: ");
                        temp = Console.ReadLine()!;
                        fName = temp;
                        break;
                    case "2":
                        Console.Write("Введите новую фамилию: ");
                        temp = Console.ReadLine()!;
                        lName = temp;
                        break;
                    case "3":
                        Console.Write("Введите новое отчество: ");
                        temp = Console.ReadLine()!;
                        pName = temp;
                        break;
                    case "4":
                        Console.Write("Введите новый возраст: ");
                        temp = Console.ReadLine()!;
                        if (int.TryParse(temp, out newAge))
                            age = newAge;
                        else
                            Console.WriteLine("Неверный ввод");
                        break;
                    case "5":
                        Console.Write("Введите новый пол: ");
                        temp = Console.ReadLine()!;
                        if (temp.Equals("ж"))
                            gender = Gender.Female;
                        else if (temp.Equals("м"))
                            gender = Gender.Male;
                        else
                            Console.WriteLine("Неверный ввод");
                        break;
                    case "6":
                        Console.Write("Введите новый логин: ");
                        temp = Console.ReadLine()!;
                        login = temp;
                        break;
                    case "7":
                        Console.Write("Введите новый пароль: ");
                        temp = Console.ReadLine()!;
                        password = temp;
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }
        public bool HasID(int id) => this.id == id;
        public bool CheckLogin(string login)
        {
            return login == this.login;
        }
    }
}
