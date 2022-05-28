using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 여러수
{
    class Program
    {
        static void Main(string[] args)
        {
            // 암스트롱 수
            Console.WriteLine("암스트롱수");
            int a, b, c;
            for(int i = 100; i < 500; i++) {
                a = i / 100;
                b = (i - a * 100) / 10;
                c = i - a * 100 - b * 10;

                if (i == (Math.Pow(a, 3) + Math.Pow(b, 3) + Math.Pow(c, 3)))
                    Console.WriteLine($"i = {i}\n a, b, c = {a}, {b}, {c}");
            }

            // 소수
            Console.WriteLine("소수");
            for (int i = 2; i <= 100; i++) {
                c = 0;
                for (int j = 2; j < i; j++)
                    if (i % j == 0) c++;
                if (c == 0) Console.WriteLine($"Prime number = {i}");
            }

            // 회문수
            Console.WriteLine("회문수");
            int input, number, result = 0;
            Console.Write("정수 입력 : ");
            number = input = int.Parse(Console.ReadLine());
            while(input != 0) {
                result = result * 10 + input % 10;
                input /= 10;
            }
            Console.WriteLine($"number = {number}, result = {result}");
            if (number == result) Console.WriteLine("회문수입니다");
            else Console.WriteLine("회문수아닙니다");

            // 최대공약수 최소공배수
            Console.WriteLine("최대공약수 최소공배수");
            int num1, num2;
            Console.WriteLine("두 수를 입력하세요");
            num1 = int.Parse(Console.ReadLine());
            num2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"최대공약수 : {gcd(num1, num2)}");
            Console.WriteLine($"최소공배수 : {lcm(num1, num2)}");
        }
        public static int gcd(int a, int b) {
            while (b != 0)
            {
                int tmp = a % b;
                a = b;
                b = tmp;
            }
            return Math.Abs(a);
        }
        public static int lcm(int a, int b) {
            int value = gcd(a, b);
            if (value == 0) return 0;
            return Math.Abs((a * b) / value);
        }
    }
}
