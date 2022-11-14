using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio1_1
{
    internal class Paese
    {
        int count = 0;
        public Paese(string nome,int numeroAbitanti)
        {
            Nome = nome;
            NumeroAbitanti = numeroAbitanti;
        }
        public string Nome { get; set; }
        public int NumeroAbitanti { get; set; }
       
        Citizen[] citizens = new Citizen[5];
        public void Add(Citizen citizen)
        {
            /* for(int i = 0; i < citizens.Length; i++)
             {
                 if (citizens[i] == null)
                 {
                     citizens[i] = citizen;
                     break;
                 }
             }*/
            
            if (count < citizens.Length) 
            { 
                citizens[count] = citizen; 
                count++; 
            }
        }
        
        public void Remove(string id)
        {
            bool citizenId = false;
           for(int i = 0; i < citizens.Length; i++)
            {
                if (citizens[i] != null && citizens[i].ID == id)
                {
                    string removeQuestion1 = "Y";
                    string removeQuestion2 = "N";
                    Console.Write($"Your Id is ({id}),if you want really remove it you have to insert Y, if no insert N : ");
                    string removeQuestion = Console.ReadLine();
                    if (removeQuestion!=removeQuestion1&&removeQuestion!=removeQuestion2)
                    {
                        Console.WriteLine("Sorry you have just insert capsLock Y or CapsLock N,please try again.");
                        Console.ReadKey();
                        return;
                        
                    }
                    else if (removeQuestion ==removeQuestion1)
                    {
                        citizens[i] = null;
                        citizenId = true;
                        return;
                    }
                    else 
                    {
                        Console.WriteLine($"Thank you for staying with us , now you can continue with your ID ({id}), please press any key to back to menu.");
                        Console.ReadKey();
                        return;
                    }
                   
                }
            }
            if (citizenId == false)
            {
                Console.WriteLine($"this ID ({id}) was not found ,please try again.");
                Console.ReadKey();
            }
            //var index=Array.IndexOf(citizens, id);
            //citizens[index] = null;

        }
        public int AbitantiTotale
        {
            get
            {
                int abitantiTotale = 0;
                
                for(int i = 0; i < citizens.Length; i++)
                {
                   if (citizens[i] != null)
                   {
                      abitantiTotale++;
                   }
                }
                return abitantiTotale;
            }
        }
        public void GetdateFromInput()
        {
           
            Console.WriteLine("((Date of Birth)) ");
            Console.WriteLine("-------------------");
            Console.Write("Year: ");
            int birthdayYear = int.Parse(Console.ReadLine());
            Console.Write("Month: ");
            int birthdayMonth = int.Parse(Console.ReadLine());
            Console.Write("Day: ");
            int birthdayDay = int.Parse(Console.ReadLine());
            DateTime birthday = new DateTime(birthdayYear, birthdayMonth, birthdayDay);
            Console.WriteLine();
            Console.Write("Data Di Nascita: ");
            var dataNascita = birthday.ToString("yyyy-MM-dd");
            Console.WriteLine(dataNascita);
            DateTime today = DateTime.Now;
            int ageYear=today.Year-birthday.Year;
            if (ageYear >= 18 )
            {
                Console.WriteLine($"you are {ageYear} years old and you are eligible then you can continue...");
                Citizen citizen = new Citizen();
                Console.Write("Name: ");
                citizen.Name = Console.ReadLine();
                Console.Write("Last Name: ");
                citizen.LastName = Console.ReadLine();
                Console.Write("ID: ");
                citizen.ID = Console.ReadLine();
                Add(citizen);
            }
            else
            {
                Console.WriteLine($"you are {ageYear} years old and you are not eligible");
                int waitingMonth = (12 - today.Month) + birthdayMonth;
                int waitingDay = ((waitingMonth-1)*31)+(31 - today.Day) + birthdayDay;
                
                int waitingYear = 18 - ageYear;
                if (waitingYear <= 0)
                {
                    Console.WriteLine($"you have to wait for {waitingDay} day or {waitingMonth} month for celebrating your birthday and then you can register.");
                }
                else
                {
                    Console.WriteLine($"you have to wait for {waitingDay} day or {waitingMonth} month and {waitingYear} year for celebrating your birthday and then you can register.");
                }
               
                Console.WriteLine("Press any key to back to menu.");
                Console.ReadKey();
            }
            //if (ageYear < 18 && today.Month<birthdayMonth && today.Day<birthdayDay)
            //{
            //    Console.WriteLine($"you are {ageYear} years old and you are not eligible");
            //    int waitingDay = (31- today.Day) + birthdayDay;
            //    int waitingMonth = (12-today.Month)+birthdayMonth;
            //    int waitingYear = 18-ageYear;
            //    Console.WriteLine($"you have to wait for {waitingDay} day , {waitingMonth} month , {waitingYear} year for celebrating your birthday and then you can register.");
            //    Console.WriteLine("Press any key to back to menu.");
            //    Console.ReadKey();  
            //}
            //else
            //{
            //    Console.WriteLine($"you are {ageYear} years old and you are eligible then you can continue...");
            //    Citizen citizen = new Citizen();
            //    Console.Write("Name: ");
            //    citizen.Name = Console.ReadLine();
            //    Console.Write("Last Name: ");
            //    citizen.LastName = Console.ReadLine();
            //    Console.Write("ID: ");
            //    citizen.ID = Console.ReadLine();
            //    Add(citizen);  
            //} 
        }
    }
}
