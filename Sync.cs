using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ConsoleApp3
{
    public class Message
    {
        private string msg;
        
        public string Msg 
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get { return msg; }
            
            [MethodImpl(MethodImplOptions.Synchronized)]
            set { msg = value; }
        }
    
        [MethodImpl(MethodImplOptions.Synchronized)]
        public Message(string str) { Msg = str; }
    }
    
    public class Waiter 
    {
        private Message msg;
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public Waiter(Message m) { msg = m; }
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Run()
        {
            string name = Thread.CurrentThread.Name;
        
            try 
            {
                Console.WriteLine(name + " ждем вызов метода notify: " + (long) (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
                Monitor.Wait(msg);
            } 
            catch(ThreadInterruptedException e)
            {
                Console.WriteLine(e.ToString());
            }
            
            Console.WriteLine(name + " : " + msg.Msg);
        }
    }
    
    public class Notifier
    {
        private Message msg;
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public Notifier(Message m) { msg = m; }
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Run()
        {
            string name = Thread.CurrentThread.Name;
            Console.WriteLine(name + " стартовал");
        
            try
            {
                Thread.Sleep(1000);
            
                msg.Msg = name + " поток Notifier отработал";
                
                //Monitor.Pulse(msg);
                Monitor.PulseAll(msg);
            }
            catch(ThreadInterruptedException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Message msg = new Message("обработать");
            
            Waiter waiter1 = new Waiter(msg);
            
            Thread thread1 = new Thread(new ThreadStart(waiter1.Run));
            thread1.Name = "waiter1";
            thread1.Start(); 
            
            Waiter waiter2 = new Waiter(msg);
            
            Thread thread2 = new Thread(new ThreadStart(waiter2.Run));
            thread2.Name = "waiter2";
            thread2.Start(); 
            
            Notifier notifier = new Notifier(msg);
            
            Thread thread = new Thread(new ThreadStart(notifier.Run));
            thread.Name = "notifier";
            thread.Start(); 
		
		    Console.WriteLine("Стартовали все потоки");
        }
    }
}