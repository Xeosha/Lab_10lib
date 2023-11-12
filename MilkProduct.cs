using InputKeyboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10lib
{
    public class MilkProduct : Product, IInit, ICloneable, IComparable
    {
        double FatСontent { get; set; }
        public MilkProduct(string? name, double price, double weight, DateTime expirationDate, double fatContent) 
            : base(name, price, weight, expirationDate)
        {
            FatСontent = fatContent;
        }

        public MilkProduct() => RandomInit();

        protected override string GetString()
        {
            return base.GetString() + $"\nЖирность: {FatСontent}";
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
                              $"Срок годности кончается через: {ExpirationDate}\n" +
                              $"Жирность: {FatСontent}"
                              );
            var tagsRow = string.Join(", ", Tags);

            Console.WriteLine("Теги: " + tagsRow);
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

        public override object Clone()
        {
            return new MilkProduct(Name, Price, Weight, ExpirationDate, FatСontent);
        }

        public override MilkProduct ShallowCopy()
        {
            return (MilkProduct)MemberwiseClone();
        }

    }
}
