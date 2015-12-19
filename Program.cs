using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafi
{
    class Program
    {
        static void Main(string[] args)
        {

            Showmessage w = write;
            Showarray r = read;
            int i;
            int ww;
            string label=null;
            G1 g = new G1();
            G1.V v1 = new G1.V(){num=0,label=null};
            G1.V v2 = new G1.V() {num=0,label=null };
            int vib;
            while (true)
            { Console.Clear();
                Console.WriteLine("1.Добавить вершину\n2.Добавить дугу\n3.Удалить вершину\n4.Удалить дугу\n5.Вывести лейбл вершины\n6.Вывести лейбл дуги\n7.Вывести лейбл дуги i-смежной вершине\n8.Вывести вес деги i-смежной вершине\n9.Алгоритм Уоршалла\n10.Завершщение работы");
                vib=int.Parse(Console.ReadLine());
                if (vib == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Введите номер вершины");
                    i = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите лейбл вершины");
                    label = Console.ReadLine();
                    v1.num = i;
                    v1.label = label;
                    g.VINSERT(v1, w);
                    Console.ReadKey();
                }
                if (vib == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Введите номер начальной вершины");
                    v1.num= int.Parse(Console.ReadLine());
                    v1.label = null;
                    Console.WriteLine("Введите номер конечной вершины");
                    v2.num = int.Parse(Console.ReadLine());
                    v2.label = null;
                    Console.WriteLine("Введите лейбл дуги");
                    label = Console.ReadLine();
                    Console.WriteLine("Введите вес дуги");
                    ww = int.Parse(Console.ReadLine());
                    g.XINSERT(v1, v2, ww, label, w);
                    Console.ReadKey();
                }
                if (vib == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Введите номер вершины");
                    v1.num = int.Parse(Console.ReadLine());
                    v1.label = null;
                    g.VDELETE(v1, w);
                    Console.ReadKey();
                }
                if (vib == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Введите номер начальной вершины");
                    v1.num = int.Parse(Console.ReadLine());
                    v1.label = null;
                    Console.WriteLine("Введите номер конечной вершины");
                    v2.num = int.Parse(Console.ReadLine());
                    v2.label = null;
                    g.XDELETE(v1, v2, w);
                    Console.ReadKey(); 
                }
                if (vib == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Введите номер вершины");
                    v1.num = int.Parse(Console.ReadLine());
                    v1.label = null;
                    g.VLABEL(v1, w);
                    Console.ReadKey();
                }
                if (vib == 6)
                {
                    Console.Clear();
                    Console.WriteLine("Введите номер начальной вершины");
                    v1.num = int.Parse(Console.ReadLine());
                    v1.label = null;
                    Console.WriteLine("Введите номер конечной вершины");
                    v2.num = int.Parse(Console.ReadLine());
                    g.XLABEL(v1, v2, w);
                    Console.ReadKey();
                }
                if (vib == 7)
                {
                    Console.Clear();
                    Console.WriteLine("Введите номер вершины");
                    v1.num = int.Parse(Console.ReadLine());
                    v1.label = null;
                    Console.WriteLine("Введите i");
                    i = int.Parse(Console.ReadLine());
                    g.SLabel(i, v1, w);
                    Console.ReadKey();
                }
                if (vib == 8)
                {
                    Console.Clear();
                    Console.WriteLine("Введите номер вершины");
                    v1.num = int.Parse(Console.ReadLine());
                    v1.label = null;
                    Console.WriteLine("Введите i");
                    i = int.Parse(Console.ReadLine());
                    g.SHeight(i, v1, w);
                    Console.ReadKey();
                }
                if (vib == 9)
                {
                    Console.Clear();
                    g.Worshall(r);
                    Console.ReadKey();
                }
                if (vib == 10)
                {
                    Console.Clear();
                    Console.WriteLine("Для завершения нажмите любую клавишу");
                    Console.ReadKey();
                    break;
                }
            }
        }
         static void write(string message)
        {

            Console.WriteLine(message);
        }
         static void read(bool[,] arr)
         {
             for (int i = 0; i < G1.i; ++i)
             {
                 for (int j = 0; j <G1.i; ++j)
                 {
                     if (arr[i, j] == false)
                         Console.Write("0\t");
                     else
                         Console.Write("1\t");
                 }
                 Console.WriteLine();
             }
         }
          
    }
}
