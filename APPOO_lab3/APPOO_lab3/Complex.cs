using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace APPOO_Lab3
{
    class Complex : IComparable//, IComparer<Complex>
    {
        private int real;
        private int img;
        public Complex()
        {
            real = 0; img = 0;
        }
        public Complex(int real, int img)
        {
            this.real = real;
            this.img = img;
        }
        public Complex(Complex a)
        {
            this.real = a.real;
            this.img = a.img;
        }
        ~Complex()
        {
            real = 0;
            img = 0;
        }

        public static bool operator <(Complex obj1, Complex obj2)
        {
            return obj1.real < obj2.real;
        }
        public static bool operator >(Complex obj1, Complex obj2)
        {
            return obj1.real > obj2.real;
        }

        public int getImg() { return img; }
        public int getReal() { return real; }

        public int CompareTo(object obj)
        {
            var item = obj as Complex;
            if (item == null)
            {
                return 1;
            }
            //Console.WriteLine(real + " " + item.real);
            return real.CompareTo(item.real);
        }

        public override string ToString()
        {
            return String.Format("{0} + {1}i",
                this.real, this.img);
        }
        public override int GetHashCode()
        {
            return real.GetHashCode() ^ img.GetHashCode();
        }

        internal int CompateTo(Complex a)
        {
            if (a == null)
            {
                return 1;
            }
            return real.CompareTo(a.real);
        }
    }
}
