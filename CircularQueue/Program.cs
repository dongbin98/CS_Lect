using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularQueue
{
	public class CircularQueue
	{
		private int[] queue;
		private int front;
		private int rear;
		private int size;

		private bool isEmpty()
		{
			return front == rear ? true : false;
		}
		private bool isFull()
		{
			return (rear + 1) % size == front ? true : false;
		}
		public CircularQueue(int size)
		{
			this.size = size;
			this.queue = new int[size];
			this.front = 0;
			this.rear = 0;
		}
		public void Enqueue(int data)
		{
			if (isFull())
				Console.WriteLine("큐가 가득찼습니다.");
			else
			{
				rear = (++rear) % size;
				queue[rear] = data;
			}
		}
		public int Dequeue()
		{
			if (isEmpty())
			{
				return -1;
			}
			front = (++front) % size;
			int temp = queue[front];
			Console.WriteLine("출력:" + temp + " ");
			return temp;
		}
		public int getFront()
        {
			return queue[front];
        }
		public int getRear()
		{
			return queue[rear];
		}
		public void show()
		{
			Console.Write("현재 큐 : ");
			for (int i = front + 1; i != (rear + 1) % size; i = (i + 1) % size)
				Console.Write(queue[i] + " ");
			Console.WriteLine();
		}
	}
	class Program
    {
        static void Main(string[] args)
        {
			int queueSize;
			int select = 0;
			CircularQueue Queue;

			Console.Write("큐 사이즈 입력 : ");
			queueSize = int.Parse(Console.ReadLine());
			Queue = new CircularQueue(queueSize);
			Console.WriteLine($"큐 사이즈는 {queueSize}입니다.");
			Console.WriteLine("\n1: 인큐 2: 디큐: 3: 큐프런트 4: 큐리어 5: 큐 전체 6: 종료");
			while(select != 6)
            {
				Console.Write("선택 : ");
				select = int.Parse(Console.ReadLine());
				switch(select)
                {
					case 1:
						Console.Write("넣을 값 입력 : ");
						int tmp = int.Parse(Console.ReadLine());
						Queue.Enqueue(tmp);
						break;
					case 2:
						Queue.Dequeue();
						break;
					case 3:
						Console.WriteLine(Queue.getFront());
						break;
					case 4:
						Console.WriteLine(Queue.getRear());
						break;
					case 5:
						Queue.show();
						break;
					default:
						break;
                }
            }
        }
    }
}
