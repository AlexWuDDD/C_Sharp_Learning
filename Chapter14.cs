using System;
namespace Chapter14{

    delegate void Handler();

    public class IncrementerEventArgs : EventArgs{
        public int ItercationCount{get; set;}
    }
    //发布者
    class Incrementer{
        public event EventHandler<IncrementerEventArgs> CountedADozen;
        public void DoCount()
        {
            IncrementerEventArgs args = new IncrementerEventArgs();
            for(int i = 1; i < 100; ++i)
                if(i%12 ==0 && CountedADozen != null){
                    args.ItercationCount = i;
                    CountedADozen(this, args);
                }
        } 
    }

    //订阅者
    class Dozens{
        public int DozemsCount{get; private set;}
        public Dozens(Incrementer incrementer){
            DozemsCount = 0;
            incrementer.CountedADozen += IncrementerDozensCount; //订阅事件
        }

        void IncrementerDozensCount(object source, IncrementerEventArgs e) //声明时间处理函数
        {
            Console.WriteLine("Incremented at iteration: {0} in {1}", e.ItercationCount, source.ToString());
            DozemsCount++;
        }
    }

    class Publisher{
        public event EventHandler SimpleEvent;
        public void RaiseTheEvent(){SimpleEvent(this, null);}
    }

    class Subscriber{
        public void MethodA(object o, EventArgs e){Console.WriteLine("AAA");}
        public void MethodB(object o, EventArgs e){Console.WriteLine("BBB");}
    }
    class Program{
        static void MainTest(){
            Console.WriteLine("Alex is cool!");

            Console.WriteLine("************************************************************");
            Incrementer incrementer = new Incrementer(); //发布者
            Dozens dozensCounter = new Dozens(incrementer); //订阅者

            incrementer.DoCount();
            Console.WriteLine("Number of dozens = {0}", dozensCounter.DozemsCount);

            Console.WriteLine("*************************************************************");
            Publisher p = new Publisher();
            Subscriber s = new Subscriber();

            p.SimpleEvent += s.MethodA;
            p.SimpleEvent += s.MethodB;
            p.RaiseTheEvent();
            Console.WriteLine("\r\nRemove MethodB");
            p.SimpleEvent -= s.MethodB;
            p.RaiseTheEvent();
        }
    }
}