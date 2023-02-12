using Market1.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Market1.Service
{
    internal class Service
    {
 
        public string num { get; set; }
        private string Path = @"C:/Users/asadb/OneDrive/Рабочий стол/Market1/Market1/Market1/Data/Database/products.txt";
        private string Path2 = @"C:/Users/asadb/OneDrive/Рабочий стол/Market1/Market1/Market1/Data/Database/sold.txt";
        public Service()
        {
            while (true)
            {
            Read();
            }
        }
        
        public void Read()
        {
            Console.Write("Komanda raqamini kiriting: ");
            num = Console.ReadLine();
            switch (num)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    ShowProducts();
                    break;
                case "3":
                    BuyProduct();
                    break;
                case "4":
                    ShowSoldedProducts();
                    break;
                default:
                    Console.WriteLine("Bunday komanda mavjud emas");
                    break;
            }
        }
        private int ID()
        {
            Console.Write("Id = ");
            return Convert.ToInt32(Console.ReadLine());
        }
        private string NAME()
        {
            Console.Write("Name = ");
            return Console.ReadLine();
        }
        private int PRICE()
        {
            Console.Write("Price = ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public void AddProduct()
        {
            Product product = new Product(id: ID(), name: NAME(), price: PRICE());
        }
        public void ShowProducts()
        {
            string[] products = File.ReadAllLines(Path);
            foreach(string i in products)
            {
                Console.WriteLine(i);
            }
        }
        public void BuyProduct()
        {
            Console.WriteLine("Mavjud maxsulotlar");
            string[] products = File.ReadAllLines(Path);
            List<string[]> els = new List<string[]>();
            foreach(string i in products)
            {
                var el = i.Split(",");
                foreach(string r in el)
                {
                    Console.WriteLine(r);
                }
                els.Add(el);
            }
            Console.Write("Sotib olish uchun ID sini kiriting:");
            string idishnik = Console.ReadLine();

            foreach (string[] arr in els)
            {
                string idsh = "Id" + "=" + idishnik;
                if (arr[0] == idsh)
                {
                    string[] ar4 = arr[4].Split("=");
                    int arr4 = Convert.ToInt32(ar4[1])+1;
                    string soldText = arr[0] + " " + arr[1] + " " + arr[2] + " " + arr[3] + " " + " " + "Sold=" + arr4 + "\n";
                    File.AppendAllText(Path2, soldText);
                }
            }
        }
        public void ShowSoldedProducts()
        {
            string[] produ = File.ReadAllLines(Path2);
            foreach (string i in produ)
            {
                Console.WriteLine(i);
            }
        }
    }
}
