using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP10
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            n = CheckInt();
            LinkedList<double> list = new LinkedList<double>();
            list.Beg = list.MakeList(n);
            Point<double> beg = list.Beg;
            list.ShowList(list.Beg);
            double d = GetXn(list, n);
            Console.WriteLine();
            PrintNewList(list, n, d);
        }
        public static int CheckInt()
        {
            int d;
            bool ok;
            Console.WriteLine("Введите количество действительных чисел в списке");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out d);
                if (!ok) Console.WriteLine("Ошибка ввода. Необходимо ввести целое число");
                if (d < 2) Console.WriteLine("Ошибка ввода. Необходимо ввести число >= 2");
            } while (!ok || d < 2);

            return d;
        }
        public static double GetXn(LinkedList<double> list, int n)
        {
            Point<double> p = list.Beg;
            for (int i = 1; i < n && p != null; i++)
                p = p.Next;
            return (double)p.Data;
        }
        public static void PrintNewList(LinkedList<double> list, int n, double Xn)
        {
            Point<double> p = list.Beg;
            while (p != null && p.Next != null)
            {
                Console.WriteLine((double)p.Data - Xn);
                p = p.Next;//переход к следующему элементу
            }
        }
    }

    public class Point<T>
    {
        public object Data { get; set; }
        public Point<T> Next { get; set; }

        public Point()
        {
            Next = null;
            Data = default(T);
        }

        public Point(T data)
        {
            Data = data;
            Next = null;
        }

        public Point(Random rnd)
        {
            double n = Math.Round((rnd.NextDouble() * 20), 2);
            Data = n;
            Next = null;
        }

        public override string ToString()
        {
            return Data.ToString() + " ";
        }
    }

    public class LinkedList<T>
    {
        public Point<T> Beg { get; set; }

        public LinkedList()
        {
            Beg = null;
        }

        public LinkedList(Point<T> data)
        {
            Beg = data;
        }

        public LinkedList(LinkedList<T> list)
        {
            Beg = list.Beg;
        }

        public LinkedList(int size)
        {
            this.Beg = this.MakeList(size);
        }

        public LinkedList(Random rnd)
        {
            Point<T> p = new Point<T>(rnd);
            Beg = p;
        }

        public Point<T> MakePoint(T num)
        {
            Point<T> p = new Point<T>(num);
            return p;
        }

        public Point<T> MakePoint(Random rnd)
        {
            Point<T> p = new Point<T>(rnd);
            return p;
        }
        //добавление в начало однонаправленного списка
        public Point<T> MakeList(int size)
        {
            Random rnd = new Random();
            Point<T> beg = MakePoint(rnd);//создаем первый элемент
            Console.WriteLine("The element \"{0}\" is adding...", beg.Data);
            for (int i = 1; i < size; i++)
            {
                //создаем элемент и добавляем в начало списка
                Point<T> p = MakePoint(rnd);
                Console.WriteLine("The element \"{0}\" is adding...", p.Data);
                //создаем элемент и добавляем в начало списка
                p.Next = beg;
                beg = p;
            }
            return beg;
        }
        public void ShowList(Point<T> Beg)
        {
            //проверка наличия элементов в списке
            if (Beg == null)
            {
                Console.WriteLine("The List is empty");
                return;
            }
            Point<T> p = Beg;
            while (p != null)
            {
                Console.WriteLine(p);
                p = p.Next;//переход к следующему элементу
            }
            Console.WriteLine();
        }
    }
}
