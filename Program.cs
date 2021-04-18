using System;

namespace Ugadai_Chislo
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            Program a=new Program();
            a.init();
        }

        void init()
        {

            Random random = new Random();
            int value = random.Next(0, 100000);

            Console.WriteLine("Пользователь, попробуйте угадать, какое число я загадал. Введите первое число и мы начнём.");
            CheckNumber(UserEnterNumber(), value);
            Console.ReadLine();
        }

        static bool NotAllDigits(string raw)
        {
            //Избавляемся от пробелов
            string DeliteSpace = raw.Trim();
            if (DeliteSpace.Length == 0)
            {
                return true;
            }
            //Проверяем каждый символ на то, что он является числом
            for (int index = 0; index < DeliteSpace.Length; index++)
            {
                if (Char.IsDigit(DeliteSpace[index]) == false)
                {
                    return true;
                }
            }
            //Всё в порядке: перед нами число
            return false;
        }

        static int UserEnterNumber()
        {

            bool doubleNumber = false;

            string entValue = Console.ReadLine();

            for (int i = 0; i < entValue.Length; i++)
            {
                if (entValue[i] == ',')
                {
                    doubleNumber = true;
                }
            }
            while (doubleNumber)
            {
                doubleNumberError();
                entValue = Console.ReadLine();
                doubleNumber = false;

                for (int i = 0; i < entValue.Length; i++)
                {
                    if (entValue[i] == ',')
                    {
                        doubleNumber = true;
                    }

                }

            }

            while (NotAllDigits(entValue))
            {
                NotNumberError();
                entValue = Console.ReadLine();
            }

            int ans = Convert.ToInt32(entValue);
            return ans;
        }

        static void doubleNumberError()
        {
            Console.WriteLine("Вы ввели число с плавующей точкой, я с такими числами пока работать не умею. Попробуйте другое число.");
        }

        static void NotNumberError()
        {
            Console.WriteLine("Вы ввели не число. Попробуйте ввести число, состоящее тоько из цифр.");
        }

        void CheckNumber(int a, int randValue)
        {

            while (a < randValue)
            {
                Console.WriteLine("Ммм, не угадал. Я загадал число побольше.");
                a = UserEnterNumber();
            }
            while (a > randValue)
            {
                Console.WriteLine("Уууу, большое число. Введи число поменьше");
                a = UserEnterNumber();
            }

            Console.WriteLine("Молодец, ты угадал число которое я загадал.");
        }

    }
    
    
}
