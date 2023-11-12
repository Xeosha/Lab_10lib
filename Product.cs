using InputKeyboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10lib
{
    public class Product : Goods, IInit, ICloneable, IComparable
    {
        public DateTime ExpirationDate { get; set; }

        public Product(string? name, double price, double weight, DateTime expirationDate) 
            : base(name, price, weight)
        {
            ExpirationDate = expirationDate;
        }

        public Product() => RandomInit();

        protected override string GetString()
        {
            return base.GetString() + $"\nСрок годности кончается: {ExpirationDate}";
        }
        public override void Show()
        {
            Console.WriteLine(GetString());
        }

        public new void SelfShow()
        {
            Console.WriteLine($"Название товара: {Name}\n" +
                              $"Цена: {Price}\n" +
                              $"Вес: {Weight}\n" +
                              $"Срок годности кончается: {ExpirationDate}"
                              );

        }

        public override void Init() 
        {
            base.Init();
            Console.WriteLine("Ввдеите срок годности: ");
            var year = EnterKeybord.TypeInteger("Введите год: ", 0, 365);
            var hour = EnterKeybord.TypeInteger("Введите час: ", 0, 24);
            var minute = EnterKeybord.TypeInteger("Введите минуты: ", 0, 60);
            var second = EnterKeybord.TypeInteger("Введите секунды: ", 0, 60);
            ExpirationDate = DateTime.Now + new TimeSpan(year, hour, minute, second);

        }
        public override void RandomInit()
        {
            base.RandomInit();      

            var random = new Random();

            var randomTimeSpan = new TimeSpan(random.Next(0, 365), random.Next(0, 24), random.Next(0, 60), random.Next(0, 60));

            DateTime currentDateTime = DateTime.Now;

            ExpirationDate = currentDateTime + randomTimeSpan;
        }
        public override object Clone()
        {
            return new Product(Name, Price, Weight, ExpirationDate);
        }

        public override Product ShallowCopy()
        {
            return (Product)MemberwiseClone();
        }
      
    }
}
