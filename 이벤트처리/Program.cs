using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 이벤트처리
{
    class Program
    {
        class EventApp
        {
            public EventHandler MyEvent;
            void MyEventHandler(object sender, EventArgs e)
            {
                Console.WriteLine("Hello World");
            }
            public EventApp()
            {
                this.MyEvent += new EventHandler(MyEventHandler);
            }
            public void InvokeEvent()
            {
                if (MyEvent != null)
                    MyEvent(this, null);
            }
        }
        static void Main(string[] args)
        {
            new EventApp().InvokeEvent();
        }
    }
}
