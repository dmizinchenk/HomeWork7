using System;

namespace HomeWork7
{
    class Money
    {
        int gryvna, kop;
        public Money(int g, int k)
        {
            if (g >= 0 && k >= 0)
            {
                this.gryvna = g + k /100;
                this.kop = k % 100;
            }
            else
                throw new Exception("Сумма не может быть отрицательной");
        }
        public static Money operator+(Money s1, Money s2)
        {
            return new Money(s1.gryvna + s2.gryvna + (s1.kop + s2.kop) / 100, (s1.kop + s2.kop) % 100);
        }
        public static Money operator -(Money s1, Money s2)
        {
            if (s2 > s1)
                throw new Exception("Вы банкрот!");
            return new Money((s1.gryvna * 100 + s1.kop - (s2.gryvna * 100 + s2.kop)) / 100, (s1.gryvna * 100 + s1.kop - (s2.gryvna * 100 + s2.kop)) % 100);
        }
        public static Money operator --(Money s)
        {
            if (s.gryvna * 100 + s.kop - 1 < 0)
                throw new Exception("Вы банкрот!");
            return new Money((s.gryvna * 100 + s.kop - 1) / 100, (s.gryvna * 100 + s.kop - 1) % 100);
        }
        public static Money operator ++(Money s)
        {
            return new Money((s.gryvna * 100 + s.kop + 1) / 100, (s.gryvna * 100 + s.kop + 1) % 100);
        }
        public static Money operator *(Money s, int v)
        {
            return new Money((s.gryvna * 100 + s.kop) * v / 100, (s.gryvna * 100 + s.kop) * v % 100);
        }
        public static Money operator /(Money s, int v)
        {
            return new Money((s.gryvna * 100 + s.kop) / v / 100, (s.gryvna * 100 + s.kop) / v % 100);
        }
        public static bool operator ==(Money s1, Money s2)
        {
            return s1.gryvna == s2.gryvna & s1.kop == s2.kop;
        }
        public static bool operator !=(Money s1, Money s2)
        {
            return s1.gryvna != s2.gryvna || s1.kop != s2.kop;
        }
        public static bool operator >(Money s1, Money s2)
        {
            return s1.gryvna * 100 + s1.kop > s2.gryvna * 100 + s2.kop;
        }
        public static bool operator <(Money s1, Money s2)
        {
            if (s1.gryvna == s2.gryvna)
                return s1.kop < s2.kop;
            return s1.gryvna < s2.gryvna;
        }
        public override string ToString()
        {
            return $"{gryvna} гривны {kop} копеек";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Money myCash = new Money(20, 357);
            Money myFriendCash = new Money(50, 2);
            myFriendCash /= 2;
            myFriendCash--;
            Console.WriteLine($"У меня {myCash}");
            Console.WriteLine($"Я богаче своего друга - {myCash > myFriendCash}");
            try
            {
                Money lost = myCash - new Money(200, 65);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
