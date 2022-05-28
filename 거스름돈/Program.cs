using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 거스름돈
{
    class Program
    {
        static void Main(string[] args)
        {
            int price, money = 1000;
            int coin500, coin100, coin50, coin10, coin5, coin1;

            Console.Write("지불할 금액을 입력하세요 : ");
            price = money - int.Parse(Console.ReadLine());
            Console.WriteLine($"거스름돈 : {price}");
            coin500 = price / 500; price = price - coin500 * 500;
            coin100 = price / 100; price = price - coin100 * 100;
            coin50 = price / 50; price = price - coin50 * 50;
            coin10 = price / 10; price = price - coin10 * 10;
            coin5 = price / 5; price = price - coin5 * 5;
            coin1 = price / 1; price = price - coin1 * 1;

            Console.WriteLine($"500원 : {coin500}\n100원 : {coin100}\n50원 : {coin50}\n10원 : {coin10}\n5원 : {coin5}\n1원 : {coin1}");
        }
    }
}
