using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_04
{
    class Stack
    {
        private Owner owner;
        private DateTime date;
        public class Date
        {
            public string dt { get; set; }
            public Date() { dt = DateTime.Today.ToString(); }
        }

        private int[] items;  // элементы стека                                !!! СДлеать приватным !!!
        private int count;  // количество элементов
        private int length;
        const int n = 10;   // количество элементов в массиве по умолчанию
        public Stack() : this (n)
        {
            
        }
        public Stack(int length) : this (length, 0, "Nope", "Nope")
        {
            
        }
        public Stack (int length, int id, string name, string nameOrg)
        {
            date = new DateTime();
            date = DateTime.Now;
            owner = new Owner();
            this.length = length;
            items = new int[length];
            this.owner.id = id;
            this.owner.name = name;
            this.owner.nameOrg = nameOrg;

        }
        public void OwnerOut()
        {
            Console.WriteLine($"Id: {owner.id}\nName: {owner.name}\nOrganizationName: {owner.nameOrg}\nCreate date: {date.ToString()}");
        }
        // пуст ли стек
        public bool IsEmpty
        {
            get { return count == 0; }
        }
        // размер стека
        public int Count
        {
            get { return count; }
        }
        public int Length
        {
            get { return length; }
        }
        // добвление элемента
        public void Push(int item)
        {
            // если стек заполнен, выбрасываем исключение
            if (count == items.Length)
                throw new InvalidOperationException("Переполнение стека");
            items[count++] = item;
        }
        // извлечение элемента
        public int Pop()
        {
            // если стек пуст, выбрасываем исключение
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            int item = items[--count];
            items[count] = default(int); // сбрасываем ссылку
            return item;
        }
        // возвращаем элемент из верхушки стека
        public int Peek()
        {
            if (count == 0)
                throw new InvalidOperationException("Невозможно обратиться к элементу(.Peek). Стэк пуст!");
            return items[count - 1];
        }

        public Stack Clone()
        {
            Stack st = new Stack(this.length);

            for (int i = 0; i < this.count; i++)
                st.Push(this.items[i]);

            return st;
        }

        public bool Contains(int num)
        {
            foreach (var i in this.items)
                if (i == num)
                    return true;
            return false;
        }


        public static Stack operator -(Stack parmStack, int x)
        {
            Stack returnStack = new Stack(parmStack.Count);
            for (int i = parmStack.Count; i > 0; i--)
            {
                if (parmStack.Peek() == x)
                {
                    parmStack.Pop();
                }
                else
                {
                    returnStack.Push(parmStack.Pop());
                }
            }
            return returnStack;
        }

        public static Stack operator ++(Stack parmStack)
        {
            if (parmStack.length > parmStack.Count)
            {
                parmStack.Push(parmStack.Peek());
                return parmStack;
            }
            throw new InvalidOperationException("Невозможно дублировать верхний элемент стека, т.к. стек полон!");
        }

        public static Stack operator <(Stack stack1, Stack stack2)
        {
            Stack result = stack1.Clone();
            Stack st = stack2.Clone();
            ISet<int> set = new HashSet<int>();
            while(!st.IsEmpty)
            {
                var item = st.Pop();
                if (st.Contains(item))
                    set.Add(item);
                else if (set.Contains(item))
                    continue;
                else
                    result.Push(item);
            }
            return result;
        }

        public static Stack operator >(Stack stack2, Stack stack1)
        {
            Stack result = stack1.Clone();
            Stack st = stack2.Clone();
            ISet<int> set = new HashSet<int>();
            while (!st.IsEmpty)
            {
                var item = st.Pop();
                if (st.Contains(item))
                    set.Add(item);
                else if (set.Contains(item))
                    continue;
                else
                    result.Push(item);
            }
            return result;
        }

    }
}
