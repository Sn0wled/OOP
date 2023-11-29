using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class EmployeeHelper
{
    private string helpString;
    public EmployeeHelper() { }
    public EmployeeHelper(string helpString)
    {
        this.helpString = helpString;
    }  
}
class Employee
{
    protected static string company_name;
    static Employee( ) {
        company_name = "ОТИ МИФИ";
    }
    public string GetCompanyName( ) {
        return company_name;
    }
    protected string fullName;
    protected short empID;
    protected double currPay;
    protected EmployeeHelper helper;
    public Employee(string fullName, short empID, double currPay)
    {
        this.fullName = fullName;
        this.empID = empID;
        this.currPay = currPay;
    }
    public Employee() { }
    public void GiveBonus(double amount)
    {
        currPay += amount;
    }
    public virtual void DisplayStats()
    {
        Console.WriteLine("\nИмя: {0}", fullName);
        Console.WriteLine("Зарплата: {0}", currPay);
        Console.WriteLine("Табельный номер: {0}", empID);
    }
    public string Name
    {
        get { return fullName; }
        set { fullName = value; }
    }
    public double Salary
    {
        get { return currPay; }
        set { currPay = value; }
    }
    public short ID
    {
        get { return empID; }
    }
    public static string Company {
        get {
            return company_name;
        }
    }
}

class Manager : Employee {
    private ulong numberOfOpoints;
    public ulong OptionsNumber {
        get {
            return numberOfOpoints;
        }
        set {
            numberOfOpoints = value;
        }
    }
    public Manager() { }
    public Manager(short empID) {
        this.empID=empID;
    }
    public Manager(string name, short id, double pay, ulong p)
        :base(name, id, pay) {
        numberOfOpoints = p;
    }
    public override void DisplayStats( ) {
        base.DisplayStats();
        Console.WriteLine("Опционов: {0}", numberOfOpoints);
    }
}

class Salesman : Employee {
    private ulong numberOfSels;
    public Salesman() { }
    public Salesman(string name, short id, double pay, ulong p)
        : base(name, id, pay) {
        numberOfSels = p;
    }
    public override void DisplayStats( ) {
        base.DisplayStats();
        Console.WriteLine("Продаж: {0}", numberOfSels);
    }
}

sealed class POINTSalesman : Salesman {
    public POINTSalesman() { }
    public POINTSalesman(string name, short id, double pay, ulong p) 
        : base(name, id, pay, p) {
    }
}

namespace SharpClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee("Bill", 100, 30000.0);
            e.GiveBonus(500.0);
            e.DisplayStats();
            Employee e2;
            e2 = new Employee("Mary", 101, 36000.0);
            e2.GiveBonus(1000.0);
            e2.DisplayStats();
            e2.Name = "Ann";
            e2.DisplayStats();
            Console.WriteLine("Табельный номер e2: {0}", e2.ID);
            Console.WriteLine("Метод: {0}", e.GetCompanyName());
            Console.WriteLine("Свойство: {0}", Employee.Company);
            Manager m = new Manager(102);
            m.Name = "John";
            m.Salary = 60000.0;
            //((Employee)m).DisplayStats();
            m.DisplayStats();
            Manager m2 = new Manager("Sam", 103, 40000, 20);
            m2.DisplayStats();
            Salesman s = new Salesman("Stan", 201, 20000, 10);
            s.DisplayStats();
            POINTSalesman points = new POINTSalesman("WhoAmI", 301, 10000, 8);
            points.DisplayStats();
        }
    }
}
