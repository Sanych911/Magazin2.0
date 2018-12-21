using System;
using System.Collections.Generic;

namespace Shopping
{
    public class Goods //класс товар
    {
        public string Name { get; set; }//Наименование
        public double Price { get; set; }//Цена
        public int Quantity { get; set; }//Количество

        public Goods(string name, double price, int quantity)

        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
    public class ShoppingCart //класс корзина
    {
        public string Name { get; set; } //Наименование
        public double Cost { get; set; } //Сумма покупки
        public int Quantity { get; set; } //Количество

        public ShoppingCart(string name, double cost, int quantity)
        {
            Name = name;
            Cost = cost;
            Quantity = quantity;
        }
    }
   
    public class Magazin 
    {

        public static void ShowInfoShoppingCar(List<ShoppingCart> purchase)//отображает добавленные в корзину товары
        {
            foreach (var i in purchase)
            Console.WriteLine($"Название: {i.Name}  Количество: { i.Quantity} Сумма покупки: { i.Cost}");
        }

        public static void ShowInfo(List<Goods>product)//Отображает товары магазина
        {
            foreach (var i in product)
            Console.WriteLine($"Название: {i.Name}  Количество: { i.Quantity} Цена: { i.Price}");
        }
    
        public static void MyGoods(List<Goods> product)//выставить свой лот на продажу
        {
            Console.Clear();// очистка консоли
            Console.WriteLine("Впишите название товара" + "\r\n");
            string choiceFirst = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введите количество товара" + "\r\n");
            int choiceSecond = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите цену товара за единицу" + "\r\n");
            double choiceThead = Convert.ToDouble(Console.ReadLine());
            product.Add(new Goods(choiceFirst, choiceThead, choiceSecond));
           
        }

        public static void Buy(List<Goods> product, List<ShoppingCart> purchase)//метод покупка
        {
            Console.Clear();// очистка консоли
            ShowInfo(product);

            Console.WriteLine("1-Впишите название товара" + "\r\n");
            string choiceFirst = Convert.ToString(Console.ReadLine());
            Console.WriteLine("1-Введите необходимое Вам количество " + "\r\n");
            int choiceSecond = Convert.ToInt16(Console.ReadLine());

            foreach (var i in product)
            {
                if (i.Name == choiceFirst & i.Quantity >= choiceSecond )
                {
                    i.Quantity = i.Quantity - choiceSecond;
                    purchase.Add(new ShoppingCart(i.Name, i.Price* choiceSecond , choiceSecond));
                }
            }
        }
        public static void Remove(List<ShoppingCart> purchase)// метод удаления товара из корзины
        {
            Console.Clear();
            ShowInfoShoppingCar(purchase);
            Console.WriteLine("\r\n" + "Напишите название товара" + "\n");
            string choiceFirst = Convert.ToString(Console.ReadLine());
            Console.WriteLine("1-Введите необходимое Вам количество для удаления" + "\r\n");
            int choiceSecond = Convert.ToInt16(Console.ReadLine());
            foreach (var i in purchase)
            {
                if (i.Name == choiceFirst & i.Quantity >= choiceSecond)
                {
                    i.Cost = (i.Cost / i.Quantity) * (i.Quantity - choiceSecond);
                    i.Quantity = i.Quantity - choiceSecond;
                }
            }
            }

            public static void WorkPurchase(List<ShoppingCart> purchase)//метод работы с покупками
            {
            Console.Clear();
            Console.WriteLine("\r\n" + "Выберите действие" + "\n");
            Console.WriteLine("1-Мои товары в корзине" + "\r\n" + "2-Удалить покупку из корзины" + "\r\n" + " 3-Перейти в магазин");
            int choicePurchas = Convert.ToInt16(Console.ReadLine());
            switch (choicePurchas)
            {
                case 1:
                    ShowInfoShoppingCar(purchase);
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 2:
                    Remove(purchase);
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    break;
                    
                default:
                    Console.WriteLine("Не корректный ввод данных");
                    break;
            }
               
        }


        public static void MagazinInterface(Person.Client User)// метод работы с магазином
        {
            Console.Clear();
            List<Goods> product = new List<Goods>();
            List<ShoppingCart> purchase = new List<ShoppingCart>();
            product.Add(new Goods("Книга", 4.55, 4));
            product.Add(new Goods("Планшет", 1004.55, 2));
            product.Add(new Goods("Монитор", 12001.10, 3));
            product.Add(new Goods("Пиво", 120.5, 15));
            product.Add(new Goods("Вино", 545.13, 10));
            ShowInfo(product);
            Action();
            void Action()
            {
                
                Console.WriteLine("\r\n" + "Выберите действие" + "\n");  //вывод текста на экран
                Console.WriteLine("1-Купить" + "\r\n" + "2-Мои покупки" + "\r\n" + "3-Выставить свой товар" + "\r\n" + "4-Оплатить" + "\r\n" + "5-Выход");
                int choice = Convert.ToInt16(Console.ReadLine()); //запись значения выбора в переменную типа инт
                switch (choice)
                {
                    case 1:
                        Buy(product, purchase);
                        Console.ReadLine();
                        Action();
                        break;
                    case 2:
                        WorkPurchase(purchase);
                        Console.Clear();
                        Action();
                            break;
                    case 3:
                        Console.Clear();
                        MyGoods(product);
                        Action();
                        break;
                    case 4:
                        double amount = 0;
                        foreach (var i in purchase)
                        {
                            amount += i.Cost;//получаем сумму товаров из корзины
                        }
                        

                        if (amount > User.Balance)//проверка на наличие нужной суммы на счету
                        {
                            Console.WriteLine("Вашей суммы не хватает,поплните баланс или удалите покупку из корзины");
                            Console.ReadLine();
                            Person.Client.ClientInterface(User);
                        }
                        else
                        {
                            User.Balance = User.Balance - amount;//снимаем с баланса сумму покупок
                            Console.WriteLine($"Остаток Вашей суммы после оплаты : {User.Balance}");
                            Console.ReadLine();
                            Person.Client.ClientInterface(User);
                        }
                        break;
                    case 5:
                        Environment.Exit(0);// закрытие консоли
                        break;
                    default:
                        Console.WriteLine("Не корректный ввод данных");
                        break;
                }

            }
            Console.ReadKey();
        }

    }

}
