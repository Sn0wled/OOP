using System;

internal class Program
{
    static void Main()
    { // Создаем домен
        AppDomain domain = AppDomain.CreateDomain("DomainHW");
        // загружаем и исполняем
        domain.ExecuteAssembly(@"C:\HW.exe");
        // выгружаем
        AppDomain.Unload(domain);
    }
}


