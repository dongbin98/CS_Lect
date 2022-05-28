using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 삼각형넓이
{
    class Program
    {
        static double getArea(double l1, double l2, double l3)
        {
            double l = l1 + l2 + l3;
            double area = Math.Sqrt(Math.Pow(l - l1, 2) + Math.Pow(l - l2, 2) + Math.Pow(l - l3, 2));
            return area;
        }
        static void Main(string[] args)
        {
            double line1, line2, line3, Area;
            Console.WriteLine("3변의 길이를 각 입력하시오");
            line1 = Double.Parse(Console.ReadLine());
            line2 = Double.Parse(Console.ReadLine());
            line3 = Double.Parse(Console.ReadLine());
            Area = getArea(line1, line2, line3);
            Console.WriteLine($"삼각형의 넓이는 {Area:F5} 입니다.");
        }
    }
}
