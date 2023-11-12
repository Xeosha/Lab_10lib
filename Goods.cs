using InputKeyboard;
using System.Net.Http.Headers;

namespace Lab_10lib
{
    // Суммарная стоимость товара заданного наименования.

    // Количество товара заданного наименования

    // Самая дорогая и самая дешевая игрушка в магазине(наименование и стоимость).

    public class Goods : IInit, ICloneable, IComparable
    {
        double price;
        double weight;

        public List<string> Tags { get; set; } // для показа различия между поверх и полным копированием
        public string? Name { get; set; }
        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                    Console.WriteLine("Цена не может быть меньше 0");
                else
                    price = value;
            }
        }

        public double Weight
        {
            get => weight; 
            set
            {
                if (value < 0)
                    Console.WriteLine("Вес не может быть меньше 0");
                else
                    weight = value;
            }
        }

        public Goods(string? name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
            Tags = new List<string>();
        }

        public Goods() => RandomInit();

        protected virtual string GetString()
        {
            return $"Название товара: {Name}\n" +
                    $"Цена: {Price}\n" +
                    $"Вес: {Weight}";
        }

        // Вывод информации (виртуальный метод)
        public virtual void Show()
        {
            Console.WriteLine(GetString());
        }

        // Вывод информации (без виртуального метода)
        public void SelfShow()
        {
            Console.WriteLine($"Название товара: {Name}\n" +
                              $"Цена: {Price}\n" +
                              $"Вес: {Weight}");

        }

        // Инициализация
        public virtual void Init()
        {
            Console.Write("Введите название товара: ");
            Name = Console.ReadLine();

            Price = EnterKeybord.TypeDouble("Введите цену: ");

            Weight = EnterKeybord.TypeDouble("Введите вес: ");
        }

        // Рандом
        public virtual void RandomInit()
        {
            var rnd = new Random(); 
            Name = "Товар_" + rnd.Next(1, 10);
            Price = Math.Round(rnd.NextDouble() * 100, 2);
            Weight = Math.Round(rnd.NextDouble() * 100, 2);
            Tags = new List<string>();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Goods other)
            {
                return Name == other.Name && Price == other.Price && Weight == other.Weight;
            }
            return false; 
            
        }

        public override int GetHashCode()
        {
            return ToString() != null ? GetHashCode() : 0;
        }

        public virtual object Clone()
        {
            var newGoods = new Goods("Клон_" + Name, Price, Weight);
            // We need to create new instances of any objects or arrays in Goods.
            newGoods.Tags = new List<string>(Tags);
            return newGoods;
        }

        public virtual Goods ShallowCopy()
        {
            return (Goods)this.MemberwiseClone();
        }

        public int CompareTo(object? obj)
        {
            if (obj is null) return 1;
            else
            {
                var other = (Goods)obj;

                if (String.Compare(Name, other.Name) > 0)
                    return 1;
                else if (String.Compare(Name, other.Name) < 0)
                    return -1;
                if (Price > other.Price)
                    return 1;
                 else if(Price < other.Price)
                    return -1;
                if (Weight > other.Weight)
                    return 1;
                if (Weight < other.Weight)
                    return -1;
                return 0;
            }
        }

        public override string ToString()
        {
            return base.ToString() + ":\n" + GetString();
        }

    }
}