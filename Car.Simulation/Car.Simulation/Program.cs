using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Car.Simulation
{
    internal class Program
    {
        static void Wait(int time)
        {
            System.Threading.Thread.Sleep(time);
        }
        static void Main()
        {
            string choose;
            BaseClass b1= new BaseClass();
            do
            {
                Console.Clear();
                b1.Showmenu();
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        {
                            if (Cars.UserList.Count == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Unfortunately you don't have car yet");
                                Console.WriteLine("You can buy cars 'Buy Cars' in the Main Menu");
                                Wait(2000);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Your Garage \nYou owned cars are numbered\n\n");
                                b1.Showcarlist(2);
                                Console.Write("\n\nSelect your car number or back press 'f' :");
                                string choose1 = Console.ReadLine();
                                choose1 = choose1.ToUpper();
                                if (choose1 == "F")
                                {
                                    break;
                                }
                                else
                                {
                                    int carnumber = 0;
                                    carnumber = (b1.Convertt(carnumber, choose1))-1;

                                    if (carnumber < Cars.UserList.Count)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Current Money :{0}\n", Cars.money);
                                        Console.WriteLine("Model Name :" + Cars.UserList[carnumber].Carsname + "\nSpeed :" + Cars.UserList[carnumber].Speed + "\nPrice :" + Cars.UserList[carnumber].Price);
                                        Console.Write("\n\nIf you want to  upgrade this car engine, you must pay 10.000$ press Y-N :");
                                        string choose9 = Console.ReadLine();
                                        choose9 = choose9.ToUpper().ToUpper();
                                        if (choose9 == "Y")
                                        {
                                            if (Cars.money >= 10000)
                                            {
                                                Cars.UserList[carnumber].Speed += 10;
                                                string b = Cars.UserList[carnumber].Carsname + "," + Cars.UserList[carnumber].Speed + "," + Cars.UserList[carnumber].Price;
                                                Cars.money -= 10000;
                                                BaseClass.LineChanger(b, "../../UserCars.txt", carnumber + 1);
                                                Console.WriteLine("\nYour car is more powerful now\n");
                                                Console.WriteLine("The old speed " + (Cars.UserList[carnumber].Speed - 10));
                                                Console.WriteLine("Current speed " + Cars.UserList[carnumber].Speed);
                                                Console.WriteLine("Press random key to main menu ");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Your money isn't enough");
                                                Wait(2000);
                                                break;
                                            }
                                        }
                                        else if (choose9 == "N")
                                        {
                                            Console.WriteLine("You are directing main menu");
                                            Wait(1000);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("enter a valid value ");
                                            Wait(1000);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid value ");
                                        System.Threading.Thread.Sleep(1000);
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    case "2":
                        {
                            Race r = new Race();
                            Console.Clear();
                            Console.WriteLine("Welcome to drag race");
                            if (Cars.UserList.Count == 0)
                            {
                                Console.WriteLine("\n\nUnfortunately you don't have car yet\nYou can't join to drag race");
                                Wait(2000);
                            }
                            else
                            {
                                Console.WriteLine("\nYour Cars");
                                b1.Showcarlist(2);
                                Console.Write("\nNo turning back after selecting the car!\nAre you contunie Y/N :");
                                string choose2 = Console.ReadLine();
                                choose2 = choose2.ToUpper();
                                if (choose2 == "Y")
                                {
                                    int carnumber = 0;
                                    Console.Write("\nSelect your car number :");
                                    string c=Console.ReadLine();
                                    carnumber = (b1.Convertt(carnumber, c)) - 1;
                                    if (carnumber < Cars.UserList.Count)
                                    {
                                        int a, b;
                                        Console.WriteLine("Your Car Name is :" + Cars.UserList[carnumber].Carsname);
                                        Console.WriteLine("Your Car Speed is :" + Cars.UserList[carnumber].Speed + "\n\n");
                                        Wait(1000);
                                        Random rnd = new Random();
                                        int k = rnd.Next(0, Cars.cars.Count);
                                        Console.WriteLine("The name of the car you will race: {0}", Cars.cars[k].Carsname);
                                        System.Threading.Thread.Sleep(2000);
                                        Console.WriteLine("It's speed is {0}", Cars.cars[k].Speed);
                                        System.Threading.Thread.Sleep(1500);
                                        int luck = 50 + Math.Abs((int)((Cars.UserList[carnumber].Speed - Cars.cars[k].Speed) / 2));
                                        r.countdown();
                                        if (Cars.UserList[carnumber].Speed >= Cars.cars[k].Speed)
                                        {
                                            if (luck >= 146)
                                            {

                                                luck = 146;
                                                a = 145;
                                            }
                                            a = rnd.Next(luck, 146);
                                            b = rnd.Next(50, 146);
                                        }
                                        else
                                        {
                                            if (luck >= 146)
                                            {
                                                a = 146;
                                                luck = 146;
                                            }
                                            a = rnd.Next(50, 146);
                                            b = rnd.Next(luck, 146);
                                        }
                                        Console.WriteLine("\n\tTHE RACE İS STARTED\n\nYour result");
                                        r.Racing(a, b);
                                        Console.WriteLine("\n\nWhatever the result it was a good race\nYou should some rest");
                                        Console.WriteLine("\n\nPress random key to main menu");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("enter a valid value ");
                                        System.Threading.Thread.Sleep(2000);
                                    }
                                }
                                else if (choose2 == "N") { break; }
                                else
                                {
                                    Console.WriteLine("Please enter a valid value.. ");
                                    System.Threading.Thread.Sleep(1000);
                                }
                            }
                            break;
                        }
                    case "3":
                        {
                            string choose3;
                            int t, y, u;
                            Random rnd = new Random();
                            do
                            {
                                t = rnd.Next(0, Cars.cars.Count);
                                y = rnd.Next(0, Cars.cars.Count);
                                u = rnd.Next(0, Cars.cars.Count);
                            } while (t == y || y == u || t == u);
                            do
                            {
                                Console.Clear();
                                b1.BuymenuCarsList(t, 1);
                                b1.BuymenuCarsList(y, 2);
                                b1.BuymenuCarsList(u, 3);
                                Console.WriteLine("Your money :" + Cars.money);
                                Console.WriteLine("back press f");
                                Console.Write("Your Choose :");
                                choose3 = Console.ReadLine();
                                choose3 = choose3.ToUpper();
                                switch (choose3)
                                {
                                    case "1":
                                        {
                                            if (Cars.money >= Cars.cars[t].Price)
                                            {
                                                Cars.UserList.Add(Cars.cars[t]);
                                                Cars.money -= Cars.cars[t].Price;
                                               BaseClass.LineChanger(Cars.money, "../../Cartext.txt", 1);
                                                BaseClass.UserCarWrite(t);
                                                Console.Clear();
                                                Console.WriteLine("Purchased this car :)");
                                                Wait(1000);
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("\n \nyou don't have enough money");
                                                Wait(1000);
                                            }
                                            break;
                                        }
                                    case "2":
                                        {
                                            if (Cars.money >= Cars.cars[y].Price)
                                            {
                                                Cars.UserList.Add(Cars.cars[y]);
                                                Cars.money -= Cars.cars[y].Price;
                                                BaseClass.LineChanger(Cars.money, "../../Cartext.txt", 1);
                                                BaseClass.UserCarWrite(y);
                                                Console.Clear();
                                                Console.WriteLine("Purchased this car :)");
                                                Wait(1000);
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("\n \nyou don't have enough money");
                                                Wait(1000);
                                            }
                                            break;
                                        }
                                    case "3":
                                        {
                                            if (Cars.money >= Cars.cars[u].Price)
                                            {
                                                Cars.UserList.Add(Cars.cars[u]);
                                                Cars.money -= Cars.cars[u].Price;
                                                BaseClass.LineChanger(Cars.money, "../../Cartext.txt", 1);
                                                BaseClass.UserCarWrite(u);
                                                Console.Clear();
                                                Console.WriteLine("Purchased this car :)");
                                                Wait(1000);
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("\n \nyou don't have enough money");
                                                Wait(1000);
                                            }
                                            break;
                                        }
                                    default:
                                        if (choose3 == "F") break;
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Please enter a valid value ");
                                            Wait(500);
                                        }
                                        break;
                                }
                            } while (choose3 != "F");
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            Console.WriteLine("Your budget :" + Cars.money);
                            Console.Write("\nIf you want to increase your money can you sell your cars\nWould you like to sell cars Y/N :");
                            string choose4 = Console.ReadLine();
                            choose4 = choose4.ToUpper();
                            if (choose4 == "Y")
                            {
                                int chooseti = 0;
                                if (Cars.UserList.Count == 0)
                                {
                                    Console.WriteLine("\nUnfortunately you don't have car yet");
                                    Wait(1500);
                                    break;
                                }
                                Console.WriteLine("You owned cars are numbered \n");
                                b1.Showcarlist(1);
                                Console.Write("\n\nIf you don't want to sell press 'F'\nThe car you  want to sell is sold at a lower price than the market\nWhich car are you sell,enter car number:");
                                string chooset = Console.ReadLine();
                                chooset = chooset.ToUpper();
                                chooseti = (b1.Convertt(chooseti, chooset))-1;
                                if (chooseti < Cars.UserList.Count)
                                {

                                    Cars.money += Cars.UserList[chooseti].Price - 30000;
                                    int i = Cars.UserList[chooseti].Price - 30000;
                                    if (i >= 0)
                                    {
                                        BaseClass.LineChanger(Cars.money, "../../Cartext.txt", 1);
                                    }
                                    else
                                    {
                                        i = Cars.UserList[chooseti].Price;
                                    }
                                    string a = string.Concat(Cars.UserList[chooseti].Carsname + "," + Cars.UserList[chooseti].Price + "," + Cars.UserList[chooseti].Speed);
                                    Cars.UserList.RemoveAt(chooseti);
                                    b1.DeleteLine(a);
                                    Wait(500);
                                    Console.WriteLine("\nSOLD you earned :" + i + "\nCurrent Money :" + Cars.money);
                                    Console.WriteLine("press random key to main menu ");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nPlease enter a valid value");
                                    Wait(800);
                                    break;
                                }
                            }
                            else if (choose4 == "N")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nplase enter a valid value");
                                Wait(500);
                            }
                            break;
                        }
                    case "5":
                        {
                            Console.Clear();
                            Console.Write("This menu provide to add cars to the database \nAre you continue  Y/N :");
                            string choose5 = Console.ReadLine();
                            choose5 = choose5.ToUpper();
                            if (choose5 == "Y")
                            {
                                Console.Write("Car's name :");
                                string name = Console.ReadLine();
                                Console.Write("Car's Speed  :");
                                string speed = Console.ReadLine();
                                Console.Write("Car's Price  :");
                                string price = Console.ReadLine();

                                Console.Write("\n\nYour car's added database :) ");
                                b1.WriteBasedata(name, speed, price);
                                Cars.BaseCarsAdd();
                                Wait(2000);
                                break;
                            }
                            else if (choose5 == "N")
                            {
                                Console.Clear();
                                Console.WriteLine("You are directing  to the main menu..");
                                Wait(1000);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("please enter a valid value..");
                                Wait(1000);
                                break;
                            }
                        }
                    case "6":
                        {
                            Console.Clear();
                            Console.Write("This menu reset added cars your money and owned cars don't change\nAre you contunie Y/N :");
                            string choose6 = Console.ReadLine();
                            choose6 = choose6.ToUpper();
                            if (choose6 == "Y")
                            {
                                File.WriteAllLines("../../Cartext.txt", File.ReadAllLines("../../NewCarDatabase.txt"));
                                    BaseClass.LineChanger(Cars.money, "../../Cartext.txt", 1);
                                Cars.cars.Clear();
                                Cars.BaseCarsAdd();
                                Console.Write("\n\nYour database is resetting...");
                                Wait(1000);
                                Console.WriteLine("\nSuccesful");
                                Wait(500);
                                break;
                            }
                            else if (choose6 == "N")
                                break;
                            else
                            {

                                Console.WriteLine("please enter a valid value..");
                                Wait(500);
                                break;
                            }
                        }
                    case "7":
                        {
                            Console.Clear();
                            Console.Write("This menu reset all data include your owned money and cars\nAre you contunie Y/N :");
                            string choose7 = Console.ReadLine();
                            choose7 = choose7.ToUpper();
                            if (choose7 == "Y")
                            {
                                File.WriteAllText("../../UserCars.txt", "");
                                File.WriteAllLines("../../Cartext.txt", File.ReadAllLines("../../NewCarDatabase.txt"));
                                Cars.cars.Clear();
                                Cars.UserList.Clear();
                                Cars.BaseCarsAdd();
                                Console.Write("\n\nYour database is resetting...");
                                Wait(1000);
                                Console.WriteLine("\nSuccesful");
                                Wait(500);
                            }
                            else if (choose7 == "N")
                                break;
                            else
                            {

                                Console.WriteLine("please enter a valid value..");
                                Wait(500);
                                break;
                            }
                            break;
                        }
                    case "8":
                        {
                            Console.Clear();
                            Console.WriteLine("\t\t\t\t\t\tGUIDE MENU\n");
                            Console.WriteLine("This simulation benefit to budget management and risk control also you will find yourself in exciting races\n");
                            Console.WriteLine("How can I earn to money");
                            Console.WriteLine("-You can earn money by racind and sell your own cars\n");
                            Console.WriteLine("How can I modify my cars");
                            Console.WriteLine("-After you select your car in the 'Garage' and pay some money,you can make the engine more powerful\n");
                            Console.WriteLine("How can I sell my cars");
                            Console.WriteLine("-You can sell your cars 'Budget' in the main menu\n");
                            Console.WriteLine("Press random key to main menu");
                            Console.ReadKey();
                            break;
                        }
                    default:
                        if (choose == "9")
                        {
                            return;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("plase enter a valid value");
                            Wait(500);
                            break;
                        }
                }
            } while (choose != "9");
        }
    }
}
