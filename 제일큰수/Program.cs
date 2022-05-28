using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 제일큰수
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> intList = new List<int>();
            //int item;
            int max = 0;
            int num = 0;
            
            Console.WriteLine("정수를 입력하시오 (0은 종료)");
            while (true)
            {
                String intStr = Console.ReadLine();
                String[] str = intStr.Split(' ');
                
                foreach (String s in str)
                {
                    //if ((num = int.Parse(s)) == 0)
                    //    break;
                    num = int.Parse(s);
                    max = num > max ? num : max;
                }
                if (int.Parse(str[str.Length-1]) == 0) 
                    break;
                //while ((item = int.Parse(Console.ReadLine())) != 0)
                //{
                //    intList.Add(item);
                //}
            }
            Console.WriteLine($"최댓값은 {max}입니다");
            //Console.WriteLine($"최댓값은 {intList.Max()}입니다");
        }
    }
}
