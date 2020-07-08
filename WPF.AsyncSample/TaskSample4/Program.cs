using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSample4
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(() => {
                Thread.Sleep(500);
                Console.WriteLine("线程1执行完毕！");
            });
            task1.Start();
            Task task2 = new Task(() => {
                Thread.Sleep(1000);
                Console.WriteLine("线程2执行完毕！");
            });
            task2.Start();
            //阻塞主线程。task1,task2都执行完毕再执行主线程
            //执行【task1.Wait();task2.Wait();】可以实现相同功能
            Task.WaitAll(new Task[] { task1, task2 });
            Console.WriteLine("主线程执行完毕！");
            Console.ReadKey();
        }
    }
}
