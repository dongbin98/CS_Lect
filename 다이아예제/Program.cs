using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 다이아예제
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, size = 0;
            Console.Write("다이아 크기 입력 : ");
            size = int.Parse(Console.ReadLine());
            for (i = 1; i < size; i++) {
                for (j = 1; j < size - i; j++)
                    Console.Write(' ');
                for(j = 1; j <= i; j++) {
                    if (j == 1) Console.Write('*');
                    else Console.Write(' ');
                }
                for(j = 1; j <= i -1; j++) {
                    if (j == (i - 1)) Console.Write('*');
                    else Console.Write(' ');
                }
                Console.WriteLine();
            }
            for (i = size - 1; i > 0; i--) {
                for (j = 1; j < size - i + 1; j++)
                    Console.Write(' ');
                for (j = 1; j <= i - 1; j++) {
                    if (j == 1) Console.Write('*');
                    else Console.Write(' ');
                }
                for (j = 1; j <= i -2; j++) {
                    if (j == i - 2) Console.Write('*');
                    else Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
