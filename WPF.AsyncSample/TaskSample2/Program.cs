using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSample2
{
    class Program
    {
        /// <summary>
        /// 有参数Task研究
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ////1.new方式实例化一个Task，需要通过Start方法启动
            Task<string> task = new Task<string>(() =>
            {
                return $"hello, task1的ID为{Thread.CurrentThread.ManagedThreadId}";
            });
            task.Start();

            ////2.Task.Factory.StartNew(Func func)创建和启动一个Task
            Task<string> task2 = Task.Factory.StartNew<string>(() =>
            {
                return $"hello, task2的ID为{ Thread.CurrentThread.ManagedThreadId}";
            });

            ////3.Task.Run(Func func)将任务放在线程池队列，返回并启动一个Task
            Task<string> task3 = Task.Run<string>(() =>
            {
                return $"hello, task3的ID为{ Thread.CurrentThread.ManagedThreadId}";
            });

            Console.WriteLine("执行主线程！");
            Console.WriteLine(task.Result);
            Console.WriteLine(task2.Result);
            Console.WriteLine(task3.Result);
            Console.ReadKey();

            // 注意task.Resut获取结果时会阻塞线程，即如果task没有执行完成，会等待task执行完成获取到Result，然后再执行后边的代码
        }
    }
}
