using InputKeyboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10lib
{
    public class Toy : Goods, IExecutable
    {
        public int AgeRestriction { get; set; }
        public Toy(string name, double price, double weight, int ageRestriction) : base(name, price, weight)
        {
            AgeRestriction = ageRestriction;
        }

        public Toy() => RandomInit();

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Возрастное ограничение: {AgeRestriction}");
        }

        public new void SelfShow()
        {
            Console.WriteLine($"Товар: {Name}\n" +
                              $"Цена: {Price}\n" +
                              $"Вес: {Weight}\n" +
                              $"Возрастное ограничение: {AgeRestriction}"
                              );
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
    }
}
