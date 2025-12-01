using System;
using System.Collections.Generic;

namespace Mozgunova
{
    public class TouristUser
    {
        public string FullName;
        public int Age;
        public string Country;
        public int Duration;
        public double Price;
        public string Status;

        public TouristUser(string fullName, int age, string country, int duration, double price)
        {
            FullName = fullName;
            Age = age;
            Country = country;
            Duration = duration;
            Price = price;
            Status = "забронирован";
        }

        public void PrintInfo()
        {
            Console.WriteLine($"ФИО: {FullName}");
            Console.WriteLine($"Возраст: {Age}");
            Console.WriteLine($"Страна поездки: {Country}");
            Console.WriteLine($"Длительность: {Duration} дней");
            Console.WriteLine($"Стоимость тура: {Price} руб.");
            Console.WriteLine($"Статус: {Status}");
        }

        public void SetStatus(string status)
        {
            Status = status;
        }
    }

    internal class Program
    {
        static List<TouristUser> tourists = new List<TouristUser>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nТУРИСТИЧЕСКОЕ АГЕНТСТВО");
                Console.WriteLine("1. Добавить туриста");
                Console.WriteLine("2. Показать всех туристов");
                Console.WriteLine("3. Поиск по ФИО");
                Console.WriteLine("4. Удалить туриста");
                Console.WriteLine("5. Изменить статус туриста");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": AddTourist(); break;
                    case "2": ShowTourists(); break;
                    case "3": FindTourist(); break;
                    case "4": DeleteTourist(); break;
                    case "5": ChangeStatus(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный пункт меню!"); break;
                }
            }
        }

        static string ReadText(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || HasDigits(input))
                    Console.WriteLine("Ошибка: ввод должен содержать только буквы.");
                else
                    return input;
            }
        }

        static bool HasDigits(string s)
        {
            foreach (char c in s)
                if (char.IsDigit(c)) return true;
            return false;
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int number))
                    return number;
                Console.WriteLine("Ошибка: введите целое число!");
            }
        }

        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double number))
                    return number;
                Console.WriteLine("Ошибка: введите число!");
            }
        }

        static void AddTourist()
        {
            string name = ReadText("Введите ФИО: ");
            int age = ReadInt("Введите возраст: ");
            string country = ReadText("Введите страну поездки: ");
            int duration = ReadInt("Длительность тура (дней): ");
            double price = ReadDouble("Стоимость тура: ");

            tourists.Add(new TouristUser(name, age, country, duration, price));
            Console.WriteLine("Турист добавлен!");
        }

        static void ShowTourists()
        {
            if (tourists.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            Console.WriteLine("Список туристов:");
            foreach (var t in tourists)
                t.PrintInfo();
        }

        static void FindTourist()
        {
            string name = ReadText("Введите ФИО: ").ToLower();
            var found = tourists.Find(t => t.FullName.ToLower() == name);
            if (found == null)
                Console.WriteLine("Турист не найден.");
            else
                found.PrintInfo();
        }

        static void DeleteTourist()
        {
            string name = ReadText("Введите ФИО туриста для удаления: ").ToLower();
            var found = tourists.Find(t => t.FullName.ToLower() == name);
            if (found == null)
            {
                Console.WriteLine("Турист не найден!");
                return;
            }

            tourists.Remove(found);
            Console.WriteLine("Турист успешно удалён.");
        }

        static void ChangeStatus()
        {
            string name = ReadText("Введите ФИО туриста: ").ToLower();
            var found = tourists.Find(t => t.FullName.ToLower() == name);
            if (found == null)
            {
                Console.WriteLine("Турист не найден!");
                return;
            }

            Console.Write("Введите новый статус (забронирован / оплачен / отменён): ");
            string status = Console.ReadLine();
            found.SetStatus(status);
            Console.WriteLine("Статус обновлён!");
        }
    }
}

/*using System;
using System.Collections.Generic;

namespace Mozgunova
{
    public class JewelryCustomer
    {
        public string FullName;
        public string Phone;
        public string JewelryType;
        public string Material;
        public double Price;
        public double Discount;

        public JewelryCustomer(string fullName, string phone, string jewelryType, string material, double price, double discount)
        {
            FullName = fullName;
            Phone = phone;
            JewelryType = jewelryType;
            Material = material;
            Price = price;
            Discount = discount;
        }

        public double GetFinalPrice()
        {
            return Price - (Price * Discount / 100);
        }

        public void PrintInfo()
        {
            Console.WriteLine($"ФИО: {FullName}");
            Console.WriteLine($"Телефон: {Phone}");
            Console.WriteLine($"Украшение: {JewelryType}");
            Console.WriteLine($"Материал: {Material}");
            Console.WriteLine($"Цена: {Price} руб.");
            Console.WriteLine($"Скидка: {Discount}%");
            Console.WriteLine($"Итоговая стоимость: {GetFinalPrice()} руб.\n");
        }
    }

    internal class Program
    {
        static List<JewelryCustomer> customers = new List<JewelryCustomer>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nЮВЕЛИРНЫЙ МАГАЗИН");
                Console.WriteLine("1. Добавить покупателя");
                Console.WriteLine("2. Показать всех покупателей");
                Console.WriteLine("3. Поиск покупателя по телефону");
                Console.WriteLine("4. Удалить покупателя по телефону");
                Console.WriteLine("5. Рассчитать общую прибыль магазина");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": AddCustomer(); break;
                    case "2": ShowCustomers(); break;
                    case "3": FindCustomer(); break;
                    case "4": DeleteCustomer(); break;
                    case "5": CalculateProfit(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный выбор!"); break;
                }
            }
        }

        static string ReadText(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || HasDigits(input))
                    Console.WriteLine("Ошибка: ввод должен содержать только буквы.");
                else
                    return input;
            }
        }

        static bool HasDigits(string s)
        {
            foreach (char c in s)
                if (char.IsDigit(c)) return true;
            return false;
        }

        static string ReadPhone(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || !OnlyDigits(input))
                {
                    Console.WriteLine("Ошибка: телефон должен содержать только цифры.");
                    continue;
                }
                return input;
            }
        }

        static bool OnlyDigits(string s)
        {
            foreach (char c in s)
                if (!char.IsDigit(c)) return false;
            return true;
        }

        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double number))
                    return number;
                Console.WriteLine("Ошибка: введите корректное число!");
            }
        }

        static void AddCustomer()
        {
            string name = ReadText("Введите ФИО: ");
            string phone = ReadPhone("Введите телефон: ");
            string jewelry = ReadText("Тип украшения: ");
            string material = ReadText("Материал: ");
            double price = ReadDouble("Цена: ");
            double discount = ReadDouble("Скидка (%): ");

            customers.Add(new JewelryCustomer(name, phone, jewelry, material, price, discount));
            Console.WriteLine("Покупатель успешно добавлен!");
        }

        static void ShowCustomers()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            Console.WriteLine("СПИСОК ПОКУПАТЕЛЕЙ:");
            foreach (var c in customers)
                c.PrintInfo();
        }

        static void FindCustomer()
        {
            string phone = ReadPhone("Введите телефон для поиска: ");
            var found = customers.Find(c => c.Phone == phone);
            if (found == null)
                Console.WriteLine("Покупатель не найден.");
            else
                found.PrintInfo();
        }

        static void DeleteCustomer()
        {
            string phone = ReadPhone("Введите телефон покупателя для удаления: ");
            var found = customers.Find(c => c.Phone == phone);
            if (found == null)
            {
                Console.WriteLine("Покупатель не найден!");
                return;
            }

            customers.Remove(found);
            Console.WriteLine("Покупатель успешно удалён!");
        }

        static void CalculateProfit()
        {
            double sum = 0;
            foreach (var c in customers)
                sum += c.GetFinalPrice();
            Console.WriteLine($"Общая прибыль магазина: {sum} руб.\n");
        }
    }
}*/


/*
using System;
using System.Collections.Generic;

namespace Mozgunova
{
    public class SportCustomer
    {
        public string FullName;
        public int Age;
        public string Item;
        public string Size;
        public double Price;
        public string PaymentMethod;

        public SportCustomer(string fullName, int age, string item, string size, double price, string paymentMethod)
        {
            FullName = fullName;
            Age = age;
            Item = item;
            Size = size;
            Price = price;
            PaymentMethod = paymentMethod;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"ФИО: {FullName}");
            Console.WriteLine($"Возраст: {Age}");
            Console.WriteLine($"Товар: {Item}");
            Console.WriteLine($"Размер: {Size}");
            Console.WriteLine($"Цена: {Price} руб.");
            Console.WriteLine($"Оплата: {PaymentMethod}\n");
        }
    }

    internal class Program
    {
        static List<SportCustomer> customers = new List<SportCustomer>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nСПОРТИВНЫЙ МАГАЗИН");
                Console.WriteLine("1. Добавить покупателя");
                Console.WriteLine("2. Показать всех покупателей");
                Console.WriteLine("3. Поиск по возрасту");
                Console.WriteLine("4. Сортировка по стоимости покупки");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": AddCustomer(); break;
                    case "2": ShowCustomers(); break;
                    case "3": FindByAge(); break;
                    case "4": SortByPrice(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный выбор!"); break;
                }
            }
        }

        static string ReadText(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || HasDigits(input))
                    Console.WriteLine("Ошибка: ввод должен содержать только буквы.");
                else
                    return input;
            }
        }

        static bool HasDigits(string s)
        {
            foreach (char c in s)
                if (char.IsDigit(c)) return true;
            return false;
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int number))
                    return number;
                Console.WriteLine("Ошибка: введите целое число!");
            }
        }

        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double number))
                    return number;
                Console.WriteLine("Ошибка: введите число!");
            }
        }

        static void AddCustomer()
        {
            string name = ReadText("Введите ФИО: "); 
            int age = ReadInt("Введите возраст: ");  
            string item = ReadText("Выбранный товар (кроссовки, футболка, шорты...): "); 
            Console.Write("Размер: ");
            string size = Console.ReadLine(); 
            double price = ReadDouble("Цена: "); 
            string payment = ReadText("Способ оплаты (наличные/карта): "); 

            customers.Add(new SportCustomer(name, age, item, size, price, payment));
            Console.WriteLine("Покупатель успешно добавлен!");
        }

        static void ShowCustomers()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            Console.WriteLine("Список покупателей:");
            foreach (var c in customers)
                c.PrintInfo();
        }

        static void FindByAge()
        {
            int age = ReadInt("Введите возраст для поиска: ");
            var found = customers.FindAll(c => c.Age == age);
            if (found.Count == 0)
                Console.WriteLine("Покупатели с таким возрастом не найдены.");
            else
            {
                Console.WriteLine($"Покупатели возрастом {age}:");
                foreach (var c in found)
                    c.PrintInfo();
            }
        }

        static void SortByPrice()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            customers.Sort((a, b) => a.Price.CompareTo(b.Price));
            Console.WriteLine("Список отсортирован по стоимости (по возрастанию).");
        }
    }
}*/


/*using System;
using System.Collections.Generic;

namespace Mozgunova
{
    public class BuildingItem
    {
        public string Name;
        public string Category;
        public double Price;
        public int Quantity;
        public int MinQuantity;

        public BuildingItem(string name, string category, double price, int quantity, int minQuantity)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
            MinQuantity = minQuantity;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Категория: {Category}");
            Console.WriteLine($"Цена: {Price} руб./шт");
            Console.WriteLine($"Количество на складе: {Quantity}");
            Console.WriteLine($"Минимальный остаток: {MinQuantity}\n");
        }

        public void Purchase(int count)
        {
            if (count <= 0)
            {
                Console.WriteLine("Количество должно быть больше 0.");
                return;
            }

            if (count > Quantity)
            {
                Console.WriteLine("На складе нет такого количества!");
                return;
            }

            Quantity -= count;
            Console.WriteLine($"Покупка успешна. Остаток товара: {Quantity}");

            CheckStock();
        }

        public void CheckStock()
        {
            if (Quantity < MinQuantity)
            {
                Console.WriteLine($"Товар \"{Name}\" почти закончился! Остаток: {Quantity} шт.");
            }
        }
    }

    internal class Program
    {
        static List<BuildingItem> items = new List<BuildingItem>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nСТРОИТЕЛЬНЫЙ МАГАЗИН");
                Console.WriteLine("1. Добавить товар");
                Console.WriteLine("2. Удалить товар");
                Console.WriteLine("3. Просмотреть все товары");
                Console.WriteLine("4. Поиск по названию");
                Console.WriteLine("5. Покупка товара");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": AddItem(); break;
                    case "2": DeleteItem(); break;
                    case "3": ShowItems(); break;
                    case "4": FindItem(); break;
                    case "5": BuyItem(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный пункт меню!"); break;
                }
            }
        }

        static string ReadText(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Ошибка: поле не может быть пустым.");
                else
                    return input;
            }
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int number))
                    return number;
                Console.WriteLine("Ошибка: введите целое число!");
            }
        }

        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double number))
                    return number;
                Console.WriteLine("Ошибка: введите число!");
            }
        }

        static void AddItem()
        {
            string name = ReadText("Название товара: ");
            string category = ReadText("Категория (инструмент, отделка, сантехника…): ");
            double price = ReadDouble("Цена за единицу: ");
            int quantity = ReadInt("Количество на складе: ");
            int min = ReadInt("Минимальный остаток: ");

            items.Add(new BuildingItem(name, category, price, quantity, min));
            Console.WriteLine("Товар добавлен!");
        }

        static void DeleteItem()
        {
            string name = ReadText("Введите название товара для удаления: ");
            var found = items.Find(i => i.Name.ToLower() == name.ToLower());
            if (found == null)
            {
                Console.WriteLine("Товар не найден!");
                return;
            }
            items.Remove(found);
            Console.WriteLine("Товар удалён!");
        }

        static void ShowItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Список товаров пуст.");
                return;
            }
            Console.WriteLine("Список товаров:");
            foreach (var item in items)
                item.PrintInfo();
        }

        static void FindItem()
        {
            string name = ReadText("Введите название товара: ");
            var found = items.Find(i => i.Name.ToLower() == name.ToLower());
            if (found == null)
            {
                Console.WriteLine("Товар не найден!");
                return;
            }
            found.PrintInfo();
        }

        static void BuyItem()
        {
            string name = ReadText("Введите название товара: ");
            var found = items.Find(i => i.Name.ToLower() == name.ToLower());
            if (found == null)
            {
                Console.WriteLine("Товар не найден!");
                return;
            }
            int count = ReadInt("Введите количество для покупки: ");
            found.Purchase(count);
        }
    }
}*/



/*using System;
using System.Collections.Generic;

namespace Mozgunova
{
    public class ShelterAnimal
    {
        public string Name;
        public string Species;
        public int Age;
        public bool Vaccinated;
        public DateTime ArriveDate;
        public string Status;

        public ShelterAnimal(string name, string species, int age, bool vaccinated, DateTime arriveDate)
        {
            Name = name;
            Species = species;
            Age = age;
            Vaccinated = vaccinated;
            ArriveDate = arriveDate;
            Status = "в приюте";
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Кличка: {Name}");
            Console.WriteLine($"Вид: {Species}");
            Console.WriteLine($"Возраст: {Age} лет");
            Console.WriteLine($"Прививки: {(Vaccinated ? "да" : "нет")}");
            Console.WriteLine($"Дата поступления: {ArriveDate.ToShortDateString()}");
            Console.WriteLine($"Статус: {Status}\n");
        }
    }

    internal class Program
    {
        static List<ShelterAnimal> animals = new List<ShelterAnimal>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nПРИЮТ ДЛЯ ЖИВОТНЫХ");
                Console.WriteLine("1. Добавить животное");
                Console.WriteLine("2. Показать всех животных");
                Console.WriteLine("3. Фильтрация животных без прививок");
                Console.WriteLine("4. Поиск по кличке");
                Console.WriteLine("5. Изменить статус (забрали домой)");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": AddAnimal(); break;
                    case "2": ShowAnimals(); break;
                    case "3": ShowUnvaccinated(); break;
                    case "4": FindByName(); break;
                    case "5": ChangeStatus(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный выбор!"); break;
                }
            }
        }

        static string ReadText(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || HasDigits(input))
                    Console.WriteLine("Ошибка: поле должно содержать только буквы.");
                else
                    return input;
            }
        }

        static bool HasDigits(string s)
        {
            foreach (char c in s)
                if (char.IsDigit(c)) return true;
            return false;
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int number))
                    return number;
                Console.WriteLine("Ошибка: введите целое число!");
            }
        }

        static DateTime ReadDate(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                    return date;
                Console.WriteLine("Ошибка: введите дату в формате гггг-мм-дд!");
            }
        }

        static void AddAnimal()
        {
            string name = ReadText("Кличка: ");
            string species = ReadText("Вид животного (кот, собака...): ");
            int age = ReadInt("Возраст: ");
            Console.Write("Есть прививки? (да/нет): ");
            bool vaccinated = Console.ReadLine().Trim().ToLower() == "да";
            DateTime date = ReadDate("Дата поступления (гггг-мм-дд): ");

            animals.Add(new ShelterAnimal(name, species, age, vaccinated, date));
            Console.WriteLine("Животное успешно добавлено!");
        }

        static void ShowAnimals()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            Console.WriteLine("Список всех животных:");
            foreach (var a in animals)
                a.PrintInfo();
        }

        static void ShowUnvaccinated()
        {
            var list = animals.FindAll(a => !a.Vaccinated);
            if (list.Count == 0)
                Console.WriteLine("Все животные имеют прививки.");
            else
            {
                Console.WriteLine("Животные без прививок:");
                foreach (var a in list)
                    a.PrintInfo();
            }
        }

        static void FindByName()
        {
            string name = ReadText("Введите кличку: ");
            var found = animals.Find(a => a.Name.ToLower() == name.ToLower());
            if (found == null)
                Console.WriteLine("Животное не найдено.");
            else
                found.PrintInfo();
        }

        static void ChangeStatus()
        {
            string name = ReadText("Введите кличку животного: ");
            var found = animals.Find(a => a.Name.ToLower() == name.ToLower());
            if (found == null)
            {
                Console.WriteLine("Животное не найдено!");
                return;
            }

            if (found.Status == "забрали домой")
            {
                Console.WriteLine("Это животное уже забрали домой.");
                return;
            }

            found.Status = "забрали домой";
            Console.WriteLine("Статус обновлён: животное забрали домой.");
        }
    }
}*/


/*using System;
using System.Collections.Generic;

namespace Mozgunova
{
    public class TaxiCar
    {
        public string Brand;       
        public string Model;        
        public int Year;            
        public double Mileage;      
        public string Status;       
        public string Driver;       

        public TaxiCar(string brand, string model, int year, double mileage, string driver)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Mileage = mileage;
            Driver = driver;
            Status = "в работе";
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Марка: {Brand}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Год выпуска: {Year}");
            Console.WriteLine($"Пробег: {Mileage} км");
            Console.WriteLine($"Состояние: {Status}");
            Console.WriteLine($"Водитель: {Driver}");
        }

        public void SetStatus(string status)
        {
            if (status.ToLower() == "работает" || status.ToLower() == "в работе")
                Status = "в работе";
            else
                Status = "на ремонте";
        }

        public void AddMileage(double km)
        {
            if (km < 0)
            {
                Console.WriteLine("Пробег не может уменьшаться.");
                return;
            }

            Mileage += km;
            Console.WriteLine($"Пробег обновлён. Текущий пробег: {Mileage} км");
        }
    }

    internal class Program
    {
        static List<TaxiCar> cars = new List<TaxiCar>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nТАКСОПАРК");
                Console.WriteLine("1. Добавить автомобиль");
                Console.WriteLine("2. Показать все автомобили");
                Console.WriteLine("3. Изменить состояние автомобиля");
                Console.WriteLine("4. Обновить пробег");
                Console.WriteLine("5. Поиск автомобиля по водителю");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": AddCar(); break;
                    case "2": ShowCars(); break;
                    case "3": ChangeStatus(); break;
                    case "4": UpdateMileage(); break;
                    case "5": FindByDriver(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный выбор!"); break;
                }
            }
        }

        static void AddCar()
        {
            Console.Write("Марка: ");
            string brand = Console.ReadLine();

            Console.Write("Модель: ");
            string model = Console.ReadLine();

            Console.Write("Год выпуска: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Пробег: ");
            double mileage = double.Parse(Console.ReadLine());

            Console.Write("Водитель: ");
            string driver = Console.ReadLine();

            cars.Add(new TaxiCar(brand, model, year, mileage, driver));
            Console.WriteLine("Автомобиль добавлен!");
        }

        static void ShowCars()
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("Таксопарк пуст.");
                return;
            }

            Console.WriteLine("Список автомобилей:");
            foreach (var c in cars)
                c.PrintInfo();
        }

        static void ChangeStatus()
        {
            Console.Write("Введите водителя (чья машина): ");
            string driver = Console.ReadLine();

            var found = cars.Find(c => c.Driver.ToLower() == driver.ToLower());

            if (found == null)
            {
                Console.WriteLine("Автомобиль не найден.");
                return;
            }

            Console.Write("Введите новое состояние (работает / ремонтируется): ");
            string status = Console.ReadLine();

            found.SetStatus(status);
            Console.WriteLine("Состояние обновлено!");
        }

        static void UpdateMileage()
        {
            Console.Write("Введите водителя: ");
            string driver = Console.ReadLine();

            var found = cars.Find(c => c.Driver.ToLower() == driver.ToLower());

            if (found == null)
            {
                Console.WriteLine("Автомобиль не найден.");
                return;
            }

            Console.Write("На сколько км увеличить пробег: ");
            double km = double.Parse(Console.ReadLine());

            found.AddMileage(km);
        }

        static void FindByDriver()
        {
            Console.Write("Введите имя водителя: ");
            string driver = Console.ReadLine();

            var found = cars.Find(c => c.Driver.ToLower() == driver.ToLower());

            if (found == null)
            {
                Console.WriteLine("Автомобиль не найден.");
                return;
            }

            found.PrintInfo();
        }
    }
}*/



