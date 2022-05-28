using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FinamExam2
{
    class Philosophe
    {
        Dining d;
        int p_id;
        string pName;
        public Philosophe(Dining d, int p_id, string pName)
        {
            this.d = d;
            this.p_id = p_id;
            this.pName = pName;
        }
        public void run()
        {
            int doEat = 0;
            while (doEat != 1)
            {
                Thread.Sleep(new Random().Next(5, 10) * 70);
                doEat = d.get(p_id, pName);
                if (doEat == 1)
                {
                    Console.WriteLine($"철학자 {pName} 식사를 시작했습니다.");
                    d.put(p_id, pName);
                }
                else
                {
                    Console.WriteLine($"철학자 {pName} 사용하려한 포크은 아직 사용중입니다.");
                }
            }
        }
    }
    class Dining
    {
        int p_id;
        string pName;
        bool[] fork = { false, false, false, false, false };
        int left, right;
        public Dining() { }
        public Dining(int p_id, string pName)
        {
            this.p_id = p_id;
            this.pName = pName;
        }
        public int isUse(int p_id)
        {
            if (p_id == 0) left = 4;
            else left = p_id - 1;
            right = p_id;
            if (!fork[right])
            {
                if (!fork[left]) return 1;
                else return 0;
            }
            else return 0;
        }
        public int get(int p_id, string pName)
        {
            lock (this)
            {
                this.p_id = p_id;
                this.pName = pName;
                if (isUse(this.p_id) == 0) return 0;
                else
                {
                    if (p_id == 0) left = 4;
                    else left = p_id - 1;
                    right = p_id;
                    try
                    {
                        fork[right] = true;
                        fork[left] = true;
                    } catch (IndexOutOfRangeException e)
                    {
                       Console.WriteLine("underflow!");
                    }
                    Console.WriteLine($"철학자 {pName} 두 포크 {right + 1}번 {left + 1}번을 집어들었습니다.");
                    return 1;
                }
            }
        }
        public void put(int p_id, string pName)
        {
            lock (this)
            {
                if (p_id == 0) left = 4;
                else left = p_id - 1;
                right = p_id;
                try
                {
                    fork[right] = false;
                    fork[left] = false;
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("overflow!");
                }
                Console.WriteLine($"철학자 {pName} 두 포크 {right + 1}번 {left + 1}번을 내려놓았습니다.");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dining d = new Dining();
            // 객체 생성
            Philosophe philosephe1 = new Philosophe(d, 0, "영희");
            Philosophe philosephe2 = new Philosophe(d, 1, "철수");
            Philosophe philosephe3 = new Philosophe(d, 2, "짱구");
            Philosophe philosephe4 = new Philosophe(d, 3, "미애");
            Philosophe philosephe5 = new Philosophe(d, 4, "닷넷");
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

            p1.Start(); p2.Start(); p3.Start(); p4.Start(); p5.Start();
            p1.Join(); p2.Join(); p3.Join(); p4.Join(); p5.Join();
        }
    }
}
