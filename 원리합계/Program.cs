using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 원리합계
{
    class Program
    {
        static void Main(string[] args)
        {
            double 원금, 이율, 기간, 원리합계;
            Console.WriteLine("원금과 이율 기간을 각 입력하시오");
            Console.Write("원금 : "); 원금 = Double.Parse(Console.ReadLine());
            Console.Write("이율 : "); 이율 = Double.Parse(Console.ReadLine());
            Console.Write("기간 : "); 기간 = Double.Parse(Console.ReadLine());
            원리합계 = 원금 * Math.Pow(1 + 이율 / 100, 기간);
            Console.WriteLine($"{원리합계}원 입니다.");

        }
    }
}
