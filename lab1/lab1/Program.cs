using System;

namespace lab1
{
   class Program
    {
        static void Main(string[] args)
        {
            double a;
            double b;
            double c;
            Console.WriteLine("Введите a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите b: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите c: ");
            c = Convert.ToDouble(Console.ReadLine());

            Task task = new Task(a, b, c);
            IDecideAble<Task, double[]> tasker = new Tasker();
            try
            {
                var result = tasker.Calculation(task);

                if (result != null)       //если решение есть - вывыдем в консоль
                {
                    if (result[0] == result[1])
                    {
                        Console.WriteLine("x1= {0}", result[0]);       //если корень один
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("x1= {0}\nx2= {1}", result[0], result[1]);
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.WriteLine("Действительных корней нет");
                    Console.ReadKey();
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
