using System;

namespace Magazin
{
    
        class Program 
        {
            public static void Main(string[] args)
            {
                Console.Clear();// очистка консоли
                Console.WriteLine("Приветствуем в нашем Магазине! Выберите действие" + "\n");  //вывод текста на экран
                Console.WriteLine("1-Регистрация;" + "\r\n" + "2-Выход");
                int res = Convert.ToInt16(Console.ReadLine()); //запись значения выбора в переменную типа инт

            while (res!=1 & res!=2)// пока пользователь не введет нужное число вызываем снова функцию
            {
                Main(args);
            }
                switch (res)
                {
                    case 1:
                        Person.Client.Registration();// вызов метода для регистрации пользователя из класса клиент
                        break;

                    case 2:
                        Environment.Exit(0);// закрытие консоли
                        break;

                    default:
                        Console.WriteLine("Не корректный ввод данных");
                        break;

                }
                
                Console.ReadLine();// ожидание нажатия клавиши для выхода из консоли
            }

        }
    }





    
        

    
