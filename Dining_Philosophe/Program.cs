using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dining_Philosophe
{
    class Philosophe
    {
        Dining d;
        int p_id;
        public Philosophe(Dining d, int p_id)
        {
            this.d = d;
            this.p_id = p_id;
        }
        public void run()
        {
            int doEat = 0;
            while(doEat != 1)
            {
                Thread.Sleep(new Random().Next(5, 10) * 70);
                doEat = d.get_chopstick(p_id);
                if(doEat == 1)
                {
                    Console.WriteLine($"철학자 {p_id + 1}호가 식사를 마치고 젓가락을 내려놓는 중입니다.");
                    d.put_chopstick(p_id);
                }
                else
                {
                    Console.WriteLine($"철학자 {p_id + 1}호가 사용하려한 젓가락은 아직 사용중입니다.");
                }
            }
        }
    }
    class Dining
    {
        int p_id;
        bool[] chopstick = { false, false, false, false, false };
        int left, right;
        public Dining() { }
        public Dining(int p_id)
        {
            this.p_id = p_id;
        }
        public int isUse(int p_id)
        {
            if (p_id == 0) left = 4;
            else left = p_id - 1;
            right = p_id;
            if (!chopstick[right])
            {
                if (!chopstick[left]) return 1;
                else return 0;
            }
            else return 0;
        }
        public int get_chopstick(int p_id)
        {
            lock(this)
            {
                this.p_id = p_id;
                if (isUse(this.p_id) == 0) return 0;
                else
                {
                    if (p_id == 0) left = 4;
                    else left = p_id - 1;
                    right = p_id;
                    chopstick[right] = true;
                    chopstick[left] = true;
                    Console.WriteLine($"철학자 {p_id + 1}호가 두 젓가락 {right + 1}번 {left + 1}번을 집어들었습니다.");
                    return 1;
                }
            }
        }
        public void put_chopstick(int p_id)
        {
            lock (this)
            {
                if (p_id == 0) left = 4;
                else left = p_id - 1;
                right = p_id;
                Console.WriteLine($"철학자 {p_id + 1}호가 두 젓가락 {right + 1}번 {left + 1}번을 내려놓았습니다.");
                chopstick[right] = false;
                chopstick[left] = false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dining d = new Dining();
            // 객체 생성
            Philosophe philosephe1 = new Philosophe(d, 0);
            Philosophe philosephe2 = new Philosophe(d, 1);
            Philosophe philosephe3 = new Philosophe(d, 2);
            Philosophe philosephe4 = new Philosophe(d, 3);
            Philosophe philosephe5 = new Philosophe(d, 4);
            // ThreadStart 델리게이트 객체 생성
            ThreadStart tstart1 = new ThreadStart(philosephe1.run);
            ThreadStart tstart2 = new ThreadStart(philosephe2.run);
            ThreadStart tstart3 = new ThreadStart(philosephe3.run);
            ThreadStart tstart4 = new ThreadStart(philosephe4.run);
            ThreadStart tstart5 = new ThreadStart(philosephe5.run);
            // 쓰레드 생성
            Thread p1 = new Thread(tstart1);
            Thread p2 = new Thread(tstart2);
            Thread p3 = new Thread(tstart3);
            Thread p4 = new Thread(tstart4);
            Thread p5 = new Thread(tstart5);
            /* 쓰레드 생성 축약
            Thread p1 = new Thread(new Philosophe(d, 0).run);
            Thread p2 = new Thread(new Philosophe(d, 1).run);
            Thread p3 = new Thread(new Philosophe(d, 2).run);
            Thread p4 = new Thread(new Philosophe(d, 3).run);
            Thread p5 = new Thread(new Philosophe(d, 4).run);
            */
            p1.Start(); p2.Start(); p3.Start(); p4.Start(); p5.Start();
            p1.Join();  p2.Join();  p3.Join();  p4.Join();  p5.Join();
        }
    }
}
