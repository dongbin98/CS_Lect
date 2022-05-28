using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Producer_Consumer_Stack
{
	class Stack<Type>
	{
		private Type[] stack;
		private int size, top;
		public Stack(int size)
		{
			this.size = size;
			stack = new Type[size];
			top = -1;
		}
		public bool isEmpty()
        {
			if (top == -1) return true;
			else return false;
        }
		public bool isFull()
        {
			if (top == size-1) return true;
			else return false;
        }
		public void Push(Type item)
		{
			stack[++top] = item;
		}
		public Type Pop()
		{
			return stack[top--];
		}
	}
	class Producer
	{
		Stack<string> stack;
		Random random = new Random(int.Parse(DateTime.Now.ToString("HHmmss")));
		public static int num;
		public Producer(Stack<string> stack)
		{
			this.stack = stack;
			num = 1;
		}
		public void run()
		{
			while (num < 10)
			{
				try
				{
					Thread.Sleep(random.Next(5, 10) * 70);
				}
				catch (Exception e) { Console.WriteLine("예외 발생"); }
				lock (stack)
				{
					string data;
					if (num % 2 == 0)
						data = "apple";
					else
						data = "banana";
					data += new Random().Next(1, 100).ToString();
					while (stack.isFull())
					{
						Console.WriteLine($"{num}:{Thread.CurrentThread.Name}이 생산을 대기하는중");
						Monitor.Wait(stack);
					}
					stack.Push(data);
					Console.WriteLine($"{num}:{Thread.CurrentThread.Name}이 {data}를 생산하였음");
					num++;
					Monitor.Pulse(stack);
				}
			}
		}
	}
	class Consumer
	{
		Stack<string> stack;
		Random random = new Random(int.Parse(DateTime.Now.ToString("HHmmss")));
		string value;
		public static int num2;
		public Consumer(Stack<string> stack)
		{
			this.stack = stack;
			num2 = 1;
		}
		public void run()
		{
			while (num2 < 10)
			{
				try
				{
					Thread.Sleep(random.Next(0, 10) * 40);
				}
				catch (Exception e) { Console.WriteLine("예외 발생"); }
				lock (stack)
				{
					while (stack.isEmpty())
					{
						Console.WriteLine($"                                  {num2}:{Thread.CurrentThread.Name}이 소비를 대기하는중");
						Monitor.Wait(stack);
					}
					value = stack.Pop();
					Console.WriteLine($"                                  {num2}:{Thread.CurrentThread.Name}이 {value}를 소비하였음");
					num2++;
					Monitor.Pulse(stack);
				}
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Stack<string> stack = new Stack<string>(4);
			Object _lock = new Object();
			Thread p1 = new Thread(new Producer(stack).run); p1.Name = "Producer1";
			Thread p2 = new Thread(new Producer(stack).run); p2.Name = "Producer2";
			Thread c1 = new Thread(new Consumer(stack).run); c1.Name = "Consumer1";
			Thread c2 = new Thread(new Consumer(stack).run); c2.Name = "Consumer2";

			c1.Start(); p1.Start(); c2.Start(); p2.Start();
			p1.Join(); c1.Join(); p2.Join(); c2.Join();
		}
	}
}
