using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console.Async.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMain();
        }

        static void TestMain()
        {
            System.Console.WriteLine("Start\n");
            GetValueAsync();
            System.Console.Write("End\n");

            System.Console.WriteLine("==================================Cut Line=================================\n");
            System.Console.WriteLine("Start\n");
            GetSumAsync(0, 10);
            System.Console.Write("End\n");

            System.Console.ReadKey();
        }

        static async Task GetValueAsync()
        {
            await Task.Run(() =>
            {
                //Thread.Sleep(1000);
                for (int i = 0; i < 5; ++i)
                {
                    System.Console.WriteLine(String.Format("From task : {0}", i));
                }
            });
            System.Console.WriteLine("Task End");
        }


        static async Task GetSumAsync(int a, int b)
        {
            int Sum = 0;
            await Task.Run(() =>
            {

                for (int i = a; i < b; i++)
                {
                    Sum += i;
                }
            });
            System.Console.WriteLine("Sum:{0}",Sum);
        }
    }
}
