using System;
using carlib;

namespace cars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SportsCar viper = new SportsCar("viper", 240, 40);
            viper.TurboBoost();
            MiniVan mv = new MiniVan();
            mv.TurboBoost();
            VWMiniVan vmv = new VWMiniVan();
            vmv.IsVersion();
        }
    }
}
