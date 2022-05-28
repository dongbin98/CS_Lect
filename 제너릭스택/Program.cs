using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 제너릭스택
{
    class Program
    {
        class Stack<StackType>
        {
            private StackType[] stack = new StackType[3];
            private int sp = -1;
            public void Push(StackType element)
            {
                if (sp >= stack.Length-1) Console.WriteLine($"오버플로우 발생감지! - {element}");
                else stack[++sp] = element;
            }
            public StackType Pop()
            {
                if(sp <= -1) {
                    Console.Write("언더플로우 발생감지! - ");
                    return stack[stack.Length-1];
                }
                else return stack[sp--];
            }
        }
        static void Main(string[] args)
        {
            Stack<int> stk1 = new Stack<int>();
            Stack<double> stk2 = new Stack<double>();
            stk1.Push(1);   stk1.Push(2);   stk1.Push(3);  stk1.Push(4);
            Console.WriteLine(stk1.Pop());
            Console.WriteLine(stk1.Pop());
            Console.WriteLine(stk1.Pop());
        }
    }
}
