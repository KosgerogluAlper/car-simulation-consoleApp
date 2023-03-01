using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Simulation
{
    internal class Cars
    {
        public Cars(string carsname, int price, int speed)
        {
            this.Carsname = carsname;
            this.Price = price;
            this.Speed = speed;
        }
        #region properties
        public string Carsname { get; set; }
        public int Price { get; set; }
        public int Speed { get; set; }
        public static List<Cars> cars = new List<Cars>();
        public static List<Cars> UserList = new List<Cars>();
        public static int money;
        #endregion
        public static void BaseCarsAdd()
        {
            Cars.cars.Clear();
            StreamReader sr = new StreamReader("../../Cartext.txt");
            money = int.Parse(sr.ReadLine());
            string data = sr.ReadLine();
            while (data != null)
            {
                string[] values = data.Split(',');
                Cars cars1 = new Cars(values[0], Convert.ToInt32(values[1]), Convert.ToInt32(values[2]));
                cars.Add(cars1);
                data = sr.ReadLine();
            }
            sr.Close();
        }
    }
}
