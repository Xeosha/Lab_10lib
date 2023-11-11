using InputKeyboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10lib
{
    public class Product : Goods, IExecutable
    {
        public DateTime ExpirationDate { get; set; }

        public Product(string name, double price, double weight, DateTime expirationDate) : base(name, price, weight)
        {
            ExpirationDate = expirationDate;
        }

        public Product() => RandomInit();

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Срок годности кончается: {ExpirationDate}");
        }

        public new void SelfShow()
        {
            Console.WriteLine($"Товар: {Name}\n" +
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

    }
}
