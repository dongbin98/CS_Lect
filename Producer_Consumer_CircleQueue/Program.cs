using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Producer_Consumer_CircleQueue
{
	public class Queue<Type>
	{
		private Type[] queue;
		private int front;
		private int rear;
		private int size;
		public bool isEmpty()
		{
			return front == rear ? true : false;
		}
		public bool isFull()
		{
			return (rear + 1) % size == front ? true : false;
		}
		public Queue(int size)
		{
			this.size = size;
			this.queue = new Type[size];
			this.front = 0;
			this.rear = 0;
		}
		public void Enqueue(Type item)
		{
			rear = (++rear) % size;
			queue[rear] = item;
		}
		public Type Dequeue()
		{
			front = (++front) % size;
			return queue[front];
		}
	}

	class Producer
	{
		Queue<string> queue;
		Random random = new Random(int.Parse(DateTime.Now.ToString("HHmmss")));
		public static int num;
		public Producer(Queue<string> queue)
		{
			this.queue = queue;
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
				lock (queue)
				{
					string data;
					if (num % 2 == 0)
						data = "apple";
					else
						data = "banana";
					data += new Random().Next(1, 100).ToString();
					while (queue.isFull())
					{
						Console.WriteLine($"{num}:{Thread.CurrentThread.Name}이 생산을 대기하는중");
						Monitor.Wait(queue);
					}
					queue.Enqueue(data);
					Console.WriteLine($"{num}:{Thread.CurrentThread.Name}이 {data}를 생산하였음");
					num++;
					Monitor.Pulse(queue);
				}
			}
		}
	}
	class Consumer
	{
		Queue<string> queue;
		Random random = new Random(int.Parse(DateTime.Now.ToString("HHmmss")));
		string value;
		public static int num2;
		public Consumer(Queue<string> queue)
		{
			this.queue = queue;
			num2 = 1;
		}
		public void run()
		{
			while (num2 < 10)
			{
				try
				{
					Thread.Sleep(random.Next(0, 10) * 50);
				}
				catch (Exception e) { Console.WriteLine("예외 발생"); }
				lock (queue)
				{
					while (queue.isEmpty())
					{
						Console.WriteLine($"                                  {num2}:{Thread.CurrentThread.Name}이 소비를 대기하는중");
						Monitor.Wait(queue);
					}
					value = queue.Dequeue();
					Console.WriteLine($"                                  {num2}:{Thread.CurrentThread.Name}이 {value}를 소비하였음");
					num2++;
					Monitor.Pulse(queue);
				}  
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Queue<string> queue = new Queue<string>(5);
			Thread p1 = new Thread(new Producer(queue).run); p1.Name = "Producer1";
			Thread p2 = new Thread(new Producer(queue).run); p2.Name = "Producer2";
			Thread c1 = new Thread(new Consumer(queue).run); c1.Name = "Consumer1";
			Thread c2 = new Thread(new Consumer(queue).run); c2.Name = "Consumer2";

			c1.Start(); p1.Start(); c2.Start(); p2.Start();
			p1.Join(); c1.Join(); p2.Join(); c2.Join();
		}
	}
}
