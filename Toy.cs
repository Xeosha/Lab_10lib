using InputKeyboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10lib
{
    public class Toy : Goods, IInit, ICloneable, IComparable
    {
        public int AgeRestriction { get; set; }
        public Toy(string? name, double price, double weight, int ageRestriction) 
            : base(name, price, weight)
        {
            AgeRestriction = ageRestriction;
        }

        public Toy() => RandomInit();

        protected override string GetString()
        {
            return base.GetString() + $"\nВозрастное ограничение: {AgeRestriction}";
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
                              $"Возрастное ограничение: {AgeRestriction}"
                              );
            var tagsRow = string.Join(", ", Tags);

            Console.WriteLine("Теги: " + tagsRow);
        }

        public override void Init()
        {
            base.Init();
            AgeRestriction = EnterKeybord.TypeInteger("Введите возрастное ограничение: ", 0, 18);

        }
        public override void RandomInit()
        { 
            base.RandomInit();
            var rnd = new Random();
            AgeRestriction = rnd.Next(0, 18);
        }

        public override object Clone()
        {
            return new Toy(Name, Price, Weight, AgeRestriction);
        }
        public override Toy ShallowCopy()
        {
            return (Toy)MemberwiseClone();
        }
    }
}
