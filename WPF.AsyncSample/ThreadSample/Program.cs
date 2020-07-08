using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th1 = new Thread(() => {
                Thread.Sleep(500);
                Console.WriteLine("线程1执行完毕！");
            });
            th1.Start();
            Thread th2 = new Thread(() => {
                Thread.Sleep(1000);
                Console.WriteLine("线程2执行完毕！");
            });
            th2.Start();
            //阻塞主线程
            th1.Join();
            th2.Join();
            Console.WriteLine("主线程执行完毕！");
            Console.ReadKey();
        }
    }
}
