using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FinalExam1
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
		public void put(Type item)
		{
			lock (this) {
				try
                {
					rear = (++rear) % size;
					queue[rear] = item;
                } catch (IndexOutOfRangeException e)	// overflow exception catch
                {
					Console.WriteLine($"{Thread.CurrentThread.Name} wait");
					Monitor.Wait(this);
				} finally
                {
					queue[rear] = item;
					Console.WriteLine($"{Thread.CurrentThread.Name} {queue[rear]} 삽입");
					Monitor.Pulse(this);
				}
				/*
				while (isFull())				// overflow prevention
				{
					Console.WriteLine($"{Thread.CurrentThread.Name} wait");
					Monitor.Wait(this);
				}
				rear = (++rear) % size;
				queue[rear] = item;
				Console.WriteLine($"{Thread.CurrentThread.Name} {queue[rear]} 삽입");
				Monitor.Pulse(this);
				*/
			}
		}
		public Type get(string waitItem)
		{
			lock (this)
			{
				while (isEmpty())				// underflow prevention
				{
					Console.WriteLine($"{Thread.CurrentThread.Name} {waitItem} wait");
					Monitor.Wait(this);
				}
				front = (++front) % size;
				Console.WriteLine($"{Thread.CurrentThread.Name} {queue[front]} 삭제");
				Monitor.Pulse(this);
				return queue[front];
			}
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
				string data;
				if (num % 2 == 0)
					data = "apple";
				else
					data = "orange";
				data += new Random().Next(1, 100).ToString();
				queue.put(data);
				num++;
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
				string data;
				if (num2 % 2 == 0)
					data = "apple";
				else
					data = "orange";
				value = queue.get(data);
				num2++;
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Queue<string> queue = new Queue<string>(2);
			Thread p1 = new Thread(new Producer(queue).run); p1.Name = "Producer";
			Thread c1 = new Thread(new Consumer(queue).run); c1.Name = "Consumer";

			c1.Start(); p1.Start();
			p1.Join(); c1.Join();
		}
	}
}
