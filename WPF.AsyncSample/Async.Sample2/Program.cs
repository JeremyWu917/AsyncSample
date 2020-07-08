using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.Sample2
{
    class Program
    {
        static void Main(string[] args)
        {
            //调用异步方法
            string content = GetContentAsync(Environment.CurrentDirectory + @"/test.txt").Result;
            //调用同步方法
            //string content = GetContent(Environment.CurrentDirectory + @"/test.txt");
            Console.WriteLine(content);
            Console.ReadKey();
        }

        //异步读取文件内容
        async static Task<string> GetContentAsync(string filename)
        {

            FileStream fs = new FileStream(filename, FileMode.Open);
            var bytes = new byte[fs.Length];
            //ReadAync方法异步读取内容，不阻塞线程
            Console.WriteLine("开始读取文件");
            int len = await fs.ReadAsync(bytes, 0, bytes.Length);
            string result = Encoding.UTF8.GetString(bytes);
            return result;
        }
        //同步读取文件内容
        static string GetContent(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            var bytes = new byte[fs.Length];
            //Read方法同步读取内容，阻塞线程
            int len = fs.Read(bytes, 0, bytes.Length);
            string result = Encoding.UTF8.GetString(bytes);
            return result;
        }

    }
}
