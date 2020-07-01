using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal
{
    class Program
    {
        static void Main(string[] args)
        {
            int Shot; //количество выстрелов в серии
            int MinShot; //минимальное количество попаданий в серии
            int MaxShot; //максимальное количество попаданий в серии
            double Miss; //Вероятность попадания при одном выстреле
            double P; //вероятность заданного числа попадания
           // Shot = 6;
            //MinShot = 3;
           // MaxShot = 6;
            //Miss = 0.3;
            P = 0;
           
            
                Console.Write("Введите количество выстрелов:  ");
                Shot = Convert.ToInt32(Console.ReadLine());
                if (Shot > 100)
                {
                    Console.Write("Количество выстрелов превышает допустимое");
                    return;
                }
                Console.Write("Введите максимальное количество попаданий:  ");
                MaxShot = Convert.ToInt32(Console.ReadLine());
                if (MaxShot > Shot)
                {
                    Console.Write("Количество попаданий не может быть ольше количества выстрелов");
                    return;
                }

                Console.Write("Введите минимальное количество попаданий:  ");
                MinShot = Convert.ToInt32(Console.ReadLine());
                if (MaxShot < MinShot)
                {
                    Console.Write("Значение количества максимальных попаданий не может быть ниже количества минимальных попаданий");
                    return;
                }

                Console.Write("Введите вероятность попадания при одном выстреле:  ");
                Miss = Convert.ToDouble(Console.ReadLine());
                if (Miss > 1)
                {
                    Console.Write("Шанс попаданий не может быть выше 1");
                    return;
                }
            

            int Factorial(int x)
            {
                
                if (x ==0)
                {
                    return 1;
                }
                else
                {
                    return x * Factorial(x - 1);
                }
                
            }

            double[,] Massiv = new double[Shot,5];
            

            for (int i = MinShot; i < MaxShot; i++)
            {
              
                Massiv[i, 1] = Factorial(Shot) / (Factorial(i) * Factorial(Shot - i));
                Massiv[i, 2] = Math.Pow(Miss, i);
                Massiv[i, 3] = Math.Pow((1 - Miss), (Shot-i));
                Massiv[i, 4] = Massiv[i, 1] * Massiv[i, 2] * Massiv[i, 3];
                P = P + Massiv[i, 4];              
            }
            P = 100*Math.Round(P, 2);



            Console.WriteLine("Вероятность равна: " + P + "%");
            Console.ReadLine();
        }
    }
}
