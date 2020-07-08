using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSample5
{
    class Program
    {
        static void Main(string[] args)
        {
            //WhenAny / WhenAll / ContinueWith

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
            //task1，task2执行完了后执行后续操作
            Task.WhenAll(task1, task2).ContinueWith((t) => {
                Thread.Sleep(100);
                Console.WriteLine("执行后续操作完毕！");
            });

            Console.WriteLine("主线程执行完毕！");
            Console.ReadKey();


            //WhenAll/WhenAny方法不会阻塞主线程，当使用WhenAll方法时所有的task都执行完毕才会执行后续操作；
            //如果把栗子中的WhenAll替换成WhenAny，则只要有一个线程执行完毕就会开始执行后续操作，这里不再演示
        }
    }
}
