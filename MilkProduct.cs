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
        private double fatContent;
        public double FatСontent
        {
            get => fatContent;
            set
            {
                if (value < 0)
                    Console.WriteLine("Жирность не может быть меньше 0");
                else
                    fatContent = value;
            }
        }
        public MilkProduct(string name, double price, double weight, DateTime expirationDate, double fatContent) 
            : base(name, price, weight, expirationDate)
        {
            FatСontent = fatContent;
        }

        public MilkProduct() => RandomInit();

        public override string GetString()
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
            FatСontent = EnterKeybord.TypeDouble("Введите жирность: ", 0, 100);

        }
        public override void RandomInit()
        {
            base.RandomInit();
            var rnd = new Random();
            FatСontent = Math.Round(rnd.NextDouble() * 100, 2);
        }

        public override object Clone()
        {
            var newProduct = (MilkProduct)this.MemberwiseClone();
            newProduct.Tags = new List<string>(Tags);
            return newProduct;
        }

        public override MilkProduct ShallowCopy()
        {
            return (MilkProduct)MemberwiseClone();
        }

    }
}
