using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Stack.Date exampleDate = new Stack.Date();
                Console.WriteLine(exampleDate.dt);

                Stack priv = new Stack (14, 21, "Max", "Google");
                priv.OwnerOut();
                
                int lenght = 5;
                Stack temp = new Stack(lenght);
                for (;lenght > 0; lenght--)
                {
                    temp.Push(-1*lenght);
                }

                Console.WriteLine($" Разница между Max и Min: {StatisticOperation.Difference(temp)}\n Сумма всех элементов: {StatisticOperation.Sum(temp)}\n Кол-во элементов: {StatisticOperation.CountOfElem(temp)}");

                Console.WriteLine($"IsNegativ: {temp.IsNegative()}\tNegativeCount: {temp.NegativeCount()}");
                

                temp = temp - (-1);
                temp++;
                for (lenght = temp.Count; lenght > 0; lenght--)
                {
                    Console.WriteLine(temp.Peek());
                    temp.Pop();
                }


                Console.WriteLine("-------------------");

                Stack stack2 = new Stack(5);
                stack2.Push(4);
                stack2.Push(3);
                stack2.Push(5);
                stack2.Push(2);
                stack2.Push(3);
                Stack stack1 = new Stack(5);
                stack1 = stack1 < stack2;

                for (lenght = stack1.Count; lenght > 0; lenght--)
                {
                    Console.WriteLine(stack1.Peek());
                    stack1.Pop();
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
