using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Simulation
{
    internal class BaseClass
    {



        public BaseClass()
        {
            UserCarsDataAdd();
            Cars.BaseCarsAdd();
        }
        public void Showmenu()
        {
            Console.WriteLine("Main Menu\n");
            Console.WriteLine("1-Garage\n2-Race\n3-Buy Car\n4-Budget Manage\n5-Add Cars to database");
            Console.Write("6-Reset added cars\n7-Reset alldata\n8-Guide\n9-Exit\nYour Choose :");
        }
        public static void LineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        public static void LineChanger(int newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText.ToString();
            File.WriteAllLines(fileName, arrLine);
        }
        public void Showcarlist(int a)
        {
            int i = 1;
            if (a == 1)
            {
                foreach (var item in Cars.UserList)
                {
                    Console.WriteLine(i + "- " + "Model Name :" + item.Carsname + "  Speed :" + item.Speed + "  Price :" + item.Price);
                    i++;
                }
            }
            else
            {
                foreach (var item in Cars.UserList)
                {
                    Console.WriteLine(i + "- " + item.Carsname);
                    i++;
                }
                Console.WriteLine();
            }
        }
        public int Convertt(int a, string b)
        {
            try
            {
                a = Convert.ToInt32(b);
            }
            catch
            {
                a = 999;
            }


            return a;
        }
        public void DeleteLine(string linetodelete)
        {
            List<string> quotelist = File.ReadAllLines("../../UserCars.txt").ToList();
            int index = quotelist.IndexOf(linetodelete);
            quotelist.RemoveAt(index);
            File.WriteAllLines("../../UserCars.txt", quotelist.ToArray());
        }
        public void WriteBasedata(string name, string speed, string price)
        {
            using (StreamWriter w = File.AppendText("../../Cartext.txt"))
            {
                w.WriteLine(name + "," + price + "," + speed);
                w.Close();
            }
        }
        public void BuymenuCarsList(int i, int number)
        {
            Console.WriteLine(number + "- " + Cars.cars[i].Carsname + " Speed:" + Cars.cars[i].Speed + " Price:" + Cars.cars[i].Price + "\n\n");
        }
        public static void UserCarWrite(int i)
        {
            using (StreamWriter w = File.AppendText("../../UserCars.txt"))
            {
                w.WriteLine(Cars.cars[i].Carsname + "," + Cars.cars[i].Price + "," + Cars.cars[i].Speed);
                w.Close();
            }
        }
        void UserCarsDataAdd()
        {
            StreamReader sr = new StreamReader("../../UserCars.txt");
            string data = sr.ReadLine();
            while (data != null)
            {
                string[] values = data.Split(',');
                Cars cars2 = new Cars(values[0], Convert.ToInt32(values[1]), Convert.ToInt32(values[2]));
                Cars.UserList.Add(cars2);
                data = sr.ReadLine();
            }
            sr.Close();
        }


















    }
}
