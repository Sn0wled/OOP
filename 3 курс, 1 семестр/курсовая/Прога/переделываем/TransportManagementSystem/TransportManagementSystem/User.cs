using System.ComponentModel.Design;

namespace TransportManagementSystem
{
    internal abstract class User : Unit
    {
        string login, password, fName, lName, pName;
        int age;
        public User(string login, string password, string fName, string lName, string pName, int age)
        {
            this.login = login;
            this.password = password;
            this.fName = fName;
            this.lName = lName;
            this.pName = pName;
            this.age = age;
        }
        public bool LogIn(string login, string password) => login == this.login && password == this.password;
        public void ChangeLogin(string login) { this.login = login; }
        public void ChangePasword(string password) { this.password = password; }
        public void ChangeFName(string fName) { this.fName = fName; }
        public void ChangeLName(string lName) { this.lName = lName; }
        public void ChangePName(string pName) { this.pName = pName; }
        public void ChangeAge(int age) { this.age = age; }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Имя: {fName}");
            Console.WriteLine($"Фамилия: {lName}");
            Console.WriteLine($"Отчество: {pName}");
            Console.WriteLine($"Возраст: {age}");
        }
        
        public bool HasLogin(string login)
        {
            return login == this.login;
        }
    }
}
