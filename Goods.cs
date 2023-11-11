using InputKeyboard;
namespace Lab_10lib
{
    // Суммарная стоимость товара заданного наименования.

    // Количество товара заданного наименования

    // Самая дорогая и самая дешевая игрушка в магазине(наименование и стоимость).

    public class Goods : IExecutable
    {
        double price;
        double weight;

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
        }

        public Goods() => RandomInit();

        // Вывод информации (виртуальный метод)
        public virtual void Show()
        {
            Console.WriteLine($"Товар: {Name}\n" +
                              $"Цена: {Price}\n" +
                              $"Вес: {Weight}");

        }

        // Вывод информации (без виртуального метода)
        public void SelfShow()
        {
            Console.WriteLine($"Товар: {Name}\n" +
                              $"Цена: {Price}\n" +
                              $"Вес: {Weight}");

        }

        // Инициализация
        public virtual void Init()
        {
            Console.WriteLine("Введите название товара: ");
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
        }

        public override bool Equals(object? obj)
        {
            if (obj is Goods)
            {
                Goods other = (Goods)obj;
                return Name == other.Name && Price == other.Price;
            }
            return false; 
            
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }


    }
}