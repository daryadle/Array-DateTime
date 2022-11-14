using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Paese paese = new Paese("Italia", 59000000);
           
            while (true)
            {
                Console.Clear();
                Console.WriteLine("welcome ,( Total Citizen:" + paese.AbitantiTotale + " )");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("1. Add Citizen");
                Console.WriteLine("2. Remove Citizen");
                Console.WriteLine();
                Console.Write("Please insert Your option: ");
                string option = Console.ReadLine();
               
                switch (option)
                {
                    
                    case "1":
                        paese.GetdateFromInput();
                        break;
                    case "2":
                        Console.Write("ID: ");
                        string idToRemove = Console.ReadLine();
                        paese.Remove(idToRemove);
                        break;
                   
                }
              
            }
        }
    }
}
