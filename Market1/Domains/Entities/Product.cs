using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market1.Domains.Entities
{
    internal class Product
    {
        private string Path = @"C:/Users/asadb/OneDrive/Рабочий стол/Market1/Market1/Market1/Data/Database/products.txt";
        public Product(int id,string name,int price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            string ProductContent = $"Id={Id}, Name={Name}, Price={Price}, Date={dt}, Sold={Sold}\n";
            File.AppendAllText(Path, ProductContent);
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Sold = 0;
        public DateTime dt = DateTime.Now;
    }
}
