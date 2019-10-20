using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_04
{
    static class StatisticOperation
    {
        public static int Sum(Stack y)
        {
            Stack x = y.Clone();
            int sum = 0;
            for (int i = x.Count;i > 0; i-- )
            {
                sum += x.Peek();
                x.Pop();
            }
            return sum;
        }

        public static int Difference(Stack y)
        {
            Stack x = y.Clone();
            int max = 0;
            int min = x.Peek();
            for (int i = x.Count; i > 0; i--)
            {
                if (x.Peek() > max)
                    max = x.Peek();
                else if (x.Peek() < min)
                    min = x.Peek();

                x.Pop();
            }

            return max - min;
        }

        public static int CountOfElem(Stack y)
        {
            int count = 0;
            Stack x = y.Clone();
            while (!x.IsEmpty)
            {
                count++;
                x.Pop();
            }

            return count;
        }

        public static bool IsNegative(this Stack stack1)
        {
            if (NegativeCount(stack1) == 0)
                return false;
            else
                return true;
        }

        public static int NegativeCount(this Stack stack1)
        {
            Stack workStack = stack1.Clone();
            int count = 0;
            while(!workStack.IsEmpty)
            {
                if (workStack.Pop() < 0)
                    count++;
            }
            return count;
        }
    }
}
