using System;

namespace Person
{
    public class Client
    {

        public string Name { get; set; }
        public uint Age { get; set; } //беззнаковое целое число
        public double Balance { get; set; }

        public Client(string name, uint age, double balance)
        {
            Name = name;
            Age = age;
            Balance = balance;
        }

        public void GetInfo() // метод вывода на экран информации о пользователе
        {
            Console.WriteLine($"Имя: {Name}  Возраст: {Age} Баланс: { Balance}");
        }
        public void TopUpBalance()// метод реализующий пополнение счета клиента
        {
            Console.Clear();
            try  // обработка исключения на переполнение суммы
            {
                Console.WriteLine("Введите сумму для пополнения:");
                Balance += Convert.ToInt16(Console.ReadLine());
            }
            catch   //если введеная сумма не помещается в тип инт ,выполняется блок catch
            {
                Console.WriteLine("Введите сумму поменьше");
                Console.ReadLine();
            }
        }
        public static void Registration()// метод реализующий регистрацию клиента
        {
            Console.Clear();
            Console.WriteLine("Введите Ваш логин:");
            string name = Console.ReadLine();

            Console.WriteLine("Введите Ваш возрост,18+:");

            uint age = Convert.ToUInt16(Console.ReadLine());
            while (age < 18 | age > 100) //ограничение по возросту от 18 до 100
            {
                Console.WriteLine("Введите Ваш возрост:"); //запрос на ввод нужного возроста
                age = Convert.ToUInt16(Console.ReadLine());
            }
            Client User = new Client(name, age, 0);
            ClientInterface(User);
        }

        public static void ClientInterface(Client User) //метод работы с клиентом
        {
            Console.Clear();// очистка консоли
            Console.WriteLine("Приветствуем в нашем Магазине! Выберите действие" + "\n");  //вывод текста на экран
            Console.WriteLine("1-Мой профиль;" + "\r\n" + "2-Пополнение баланса" + "\r\n" + "3-Магазин" + "\r\n" + "4-Мои покупки" + "\r\n" + "5-Выход");
            int choice = Convert.ToInt16(Console.ReadLine()); //запись значения выбора в переменную типа инт
            switch (choice)
            {
                case 1:
                    User.GetInfo();
                    Console.ReadLine();
                    ClientInterface(User);
                    break;
                case 2:
                    User.TopUpBalance();
                    ClientInterface(User);
                    break;
                case 3:
                    Shopping.Magazin.MagazinInterface(User);
                    ClientInterface(User);
                    break;
                case 5:
                    Environment.Exit(0);// закрытие консоли
                    break;
                default:
                    Console.WriteLine("Не корректный ввод данных");
                    break;
            }

        }
    }

}
