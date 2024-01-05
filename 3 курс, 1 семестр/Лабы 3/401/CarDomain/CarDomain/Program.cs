using System;
using System.Reflection;
using System.Security.Permissions;

namespace CarDomain
{
    internal class Program
    {
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        static void Main(string[] args)
        {
            Assembly a;
            try
            {
                a = Assembly.Load(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            AppDomain ad = AppDomain.CurrentDomain;
            Assembly[] loaded = ad.GetAssemblies();
            foreach (Assembly assembly in loaded)
            {
                Console.WriteLine(assembly.FullName);
            }

            Type[] myTypes = a.GetTypes();
            BindingFlags flags = (
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.DeclaredOnly);
            foreach (Type item in myTypes)
            {
                MethodInfo[] mi = item.GetMethods(flags);
                foreach (MethodInfo mi2 in mi)
                {
                    Console.WriteLine(mi2);
                }
            }

            Console.WriteLine();
            Type mv = a.GetType("carlib.MiniVan");
            object obj = Activator.CreateInstance(mv);
            MethodInfo mvmi = mv.GetMethod("TurboBoost");
            mvmi.Invoke(obj, null);

            Console.WriteLine();
            AppDomain dm = AppDomain.CreateDomain("CARS");
            dm.ExecuteAssembly("cars.exe");
            AppDomain.Unload(dm);
        }
    }
}
