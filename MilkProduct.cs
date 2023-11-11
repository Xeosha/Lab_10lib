using InputKeyboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10lib
{
    public class MilkProduct : Product, IExecutable
    {
        double FatСontent { get; set; }
        public MilkProduct(string name, double price, double weight, DateTime expirationDate, double fatContent) : base(name, price, weight, expirationDate)
        {
            FatСontent = fatContent;
        }

        public MilkProduct() => RandomInit();

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Жирность: {FatСontent}");
        }

        public new void SelfShow()
        {
            Console.WriteLine($"Товар: {Name}\n" +
                              $"Цена: {Price}\n" +
                              $"Вес: {Weight}\n" +
                              $"Срок годности кончается через: {ExpirationDate}\n" +
                              $"Жирность: {FatСontent}"
                              );
        }
        public override void Init()
        {
            base.Init();
            FatСontent = EnterKeybord.TypeDouble("Введите жирность: ");
        }
        public override void RandomInit()
        {
            base.RandomInit();
            var rnd = new Random();
            FatСontent = Math.Round(rnd.NextDouble() * 100, 2);
        }
    }
}
