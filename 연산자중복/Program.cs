using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 연산자중복
{
    class Program
    {
        class Even
        {
            int evenNumber;
            public Even(int n)
            {
                evenNumber = (n % 2 == 0) ? n : n + 1;
            }
            public static Even operator ++(Even e)

            {
                e.evenNumber += 2;
                return e;
            }
            public static Even operator --(Even e)
            {
                e.evenNumber -= 2;
                return e;
            }
            public void PrintEven()
            {
                Console.WriteLine("Even Number = " + evenNumber);
            }
        }
        static void Main(string[] args)
        {
            Even e = new Even(4);
            e.PrintEven();
            ++e;
            e.PrintEven();
            --e;
            e.PrintEven();
        }
    }
}
