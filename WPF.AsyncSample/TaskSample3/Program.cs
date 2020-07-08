using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSample3
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine("执行Task结束!");
            });
            //同步执行，task会阻塞主线程
            task.RunSynchronously();
            Console.WriteLine("执行主线程结束！");
            Console.ReadKey();
        }
    }
}
