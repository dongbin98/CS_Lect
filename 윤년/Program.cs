using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 윤년
{
    class Program
    {
        static void Main(string[] args)
        {
            int year;
            Console.Write("연도 입력 : ");
            year = int.Parse(Console.ReadLine());

            if ((year % 4 == 0) && (year % 100 != 0))
                Console.WriteLine("윤년입니다");
            else if ((year % 400) == 0)
                Console.WriteLine("윤년입니다");
            else
                Console.WriteLine("윤년이 아닙니다");
        }
    }
}
