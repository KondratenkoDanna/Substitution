using System;
using System.Collections.Generic;

namespace LinkedListLibrary
{
    public class PData
    {
        public PData pred;
        public string country;
        public string brand;
        public int power;
        public int year;
        public int price;

        public PData()
        {
            pred = null;
            Console.Clear();
            Console.WriteLine("_____________Введите поля новой записи_____________");
            Console.Write("Введите страну изготовителя: ");
            country = Console.ReadLine();
            Console.Write("Введите марку: ");
            brand = Console.ReadLine();
            Console.Write("Введите мощность: ");
            power = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите год выпуска: ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите первоначальную цену: ");
            price = Convert.ToInt32(Console.ReadLine());
        }
        public void printPData()
        {
            Console.WriteLine("___________________________________________________");
            Console.Write("странa изготовителя: ");
            Console.WriteLine(country);
            Console.Write("маркa: ");
            Console.WriteLine(brand);
            Console.Write("мощность: ");
            Console.WriteLine(power);
            Console.Write("год выпуска: ");
            Console.WriteLine(year);
            Console.Write("первоначальная цена: ");
            Console.WriteLine(price);
        }
    }


    class Stack
    {
        PData top;
        int size, count;
        Stack(int n, PData elem = null) // создание стека
        {
            top = elem;
            size = n;
            count = (elem == null) ? 0 : 1;
        }
        public void Push(PData elem)
        {
            if (count < size)
            {
                elem.pred = top;
                top = elem;
                count++;
            }
        }
        public PData Pop()
        {
            if (count > 0)
            {
                PData result = top;
                top = top.pred;
                count--;
                return result;
            }
            return null;
        }
        public void Edit(int i)
        {
            Stack temp = new Stack(i);
            for (int j = 1; j < i; j++)
            {
                temp.Push(this.Pop());
            }

            Console.Clear();
            Console.WriteLine("_____________Введите поля для изменения записи_____________");
            Console.Write("Введите страну изготовителя: ");
            top.country = Console.ReadLine();
            Console.Write("Введите марку: ");
            top.brand = Console.ReadLine();
            Console.Write("Введите мощность: ");
            top.power = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите год выпуска: ");
            top.year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите первоначальную цену: ");
            top.price = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            for (int j = 1; j < i; j++)
            {
                this.Push(temp.Pop());
            }
        }
        public void Print()
        {
            PData pointer = top;

            while (pointer != null)
            {
                pointer.printPData();
                pointer = pointer.pred;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите количество записей: ");
            Stack stack = new Stack(Convert.ToInt32(Console.ReadLine()));
            string n;
            for (int i = 0; i < stack.size; ++i)
            {
                PData elem = new PData();
                stack.Push(elem);
            }
            do
            {
                Console.WriteLine();
                Console.Write("Введите номер записи для изменения или ENTER для завершении: ");
                n = Console.ReadLine();

                if (n != "")
                {
                    stack.Edit(Convert.ToInt32(n));
                    stack.Print();
                }
                else break;
            } while (true);

            Console.ReadKey();
        }
    }
}