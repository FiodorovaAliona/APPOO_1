using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace APPOO_Lab3
{
    class Program
    {
        public static bool isReal(Complex a)
        {
            return (a.getImg() == 0);
        }

        public static void func1()
        {
            //Создаем и заполняем контейнер
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                
                int real, img;
                Console.Write("Enter real part: ");
                real = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter img part: ");
                img = Convert.ToInt32(Console.ReadLine());
                arrayList.Add(new Complex(real, img));
            }

            //Просмотр контейнера
            Console.WriteLine("ArrayList1:");
            foreach (Complex a in arrayList)
            {
                Console.WriteLine(a.ToString());
            }
            Console.WriteLine();

            //Изменить контейнер, удалив из него одни элементы и заменив другие
            arrayList.RemoveAt(2);
            arrayList[0] = new Complex(11, 0);

            //Просмотреть контейнер, используя для доступа к его элементам итераторы
            Console.WriteLine("ArrayList1:");
            var arrayIterator = arrayList.GetEnumerator();
            while (arrayIterator.MoveNext())
            {
                Console.WriteLine(arrayIterator.Current.ToString());
            }
            Console.WriteLine();

            //Создать второй контейнер этого же класса и заполнить его данными того же типа, что и первый контейнер.
            ArrayList arrayListSec = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                Complex a = new Complex();
                int real, img;
                Console.Write("Enter real part: ");
                real = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter img part: ");
                img = Convert.ToInt32(Console.ReadLine());
                arrayListSec.Add(new Complex(real, img));
            }

            //Изменить первый контейнер, удалив из него n элементов после заданного и добавив затем в него все элементы из второго контейнера.
            for (int i = 3; i < arrayList.Count;)
            {
                arrayList.RemoveAt(i);
            }
            arrayList.AddRange(arrayListSec);

            //Просмотреть первый и второй контейнеры.
            Console.WriteLine("ArrayList1:");
            foreach (Complex a in arrayList)
            {
                Console.WriteLine(a.getReal() + " + " + a.getImg() + "i");
            }
            Console.WriteLine();
            Console.WriteLine("ArrayList2:");
            foreach (Complex a in arrayListSec)
            {
                Console.WriteLine(a.getReal() + " + " + a.getImg() + "i");
            }
            Console.WriteLine();
        }

        public static void func2()
        {
            //Создаем и заполняем контейнер
            List<Complex> arrayList = new List<Complex>();
            for (int i = 0; i < 5; i++)
            {
                Complex a = new Complex();
                int real, img;
                Console.Write("Enter real part: ");
                real = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter img part: ");
                img = Convert.ToInt32(Console.ReadLine());
                arrayList.Add(new Complex(real, img));
            }

            //Отсортировать его по убыванию элементов.
            arrayList.Sort((a, b) => b.CompateTo(a));

            //Просмотреть контейнер
            Console.WriteLine("ArrayList:");
            foreach (Complex a in arrayList)
            {
                Console.WriteLine(a.getReal() + " + " + a.getImg() + "i");
            }
            Console.WriteLine();

            //Используя подходящий алгоритм, найти в контейнере элемент, удовлетворяющий заданному условию.
            Console.WriteLine("Real = " + ((arrayList.Find(isReal) == null) ? "false" : arrayList.Find(isReal).ToString()));
            Console.WriteLine();

            //Переместить элементы, удовлетворяющие заданному условию в другой контейнер
            Stack<Complex> stack = new Stack<Complex>();
            List<Complex> arrayListCopy = new List<Complex>();
            foreach (Complex a in arrayList.FindAll(isReal))
            {
                stack.Push(a);
                arrayListCopy.Add(a);
            }

            //Просмотреть второй контейнер
            Console.WriteLine("Stack:");
            foreach (Complex a in stack)
            {
                Console.WriteLine(a.getReal() + " + " + a.getImg() + "i");
            }
            Console.WriteLine();

            //Отсортировать первый и второй контейнеры по возрастанию элементов
            arrayList.Sort();
            arrayListCopy.Sort((a, b) => b.CompateTo(a));
            stack.Clear();
            foreach (Complex a in arrayListCopy)
            {
                stack.Push(a);
            }

            //Просмотреть их
            Console.WriteLine("ArrayList:");
            foreach (Complex a in arrayList)
            {
                Console.WriteLine(a.getReal() + " + " + a.getImg() + "i");
            }
            Console.WriteLine();
            Console.WriteLine("Stack:");
            foreach (Complex a in stack)
            {
                Console.WriteLine(a.getReal() + " + " + a.getImg() + "i");
            }
            Console.WriteLine();

            //Получить третий контейнер путем слияния первых двух
            List<Complex> list = new List<Complex>();
            list.AddRange(arrayList);
            list.AddRange(stack);

            //Просмотреть третий контейнер
            Console.WriteLine("Final List:");
            foreach (Complex a in list)
            {
                Console.WriteLine(a.getReal() + " + " + a.getImg() + "i");
            }
            Console.WriteLine();

            //Подсчитать, сколько элементов, удовлетворяющих заданному условию, содержит третий контейнер
            Console.WriteLine("Count of real = " + list.Count(isReal));

            //Определить, есть ли в третьем контейнере элемент, удовлетворяющий заданному условию
            Console.WriteLine("Real = " + ((list.Find(isReal) == null) ? "false" : list.Find(isReal).ToString()));
        }

        static void Main(string[] args)
        {
            //func1();
            func2();
            Console.ReadKey();
        }
    }
}
