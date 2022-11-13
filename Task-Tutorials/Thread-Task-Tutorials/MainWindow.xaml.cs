using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Thread_Task_Tutorials
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 1、开启一个线程
            // 方式1
            //Task task = new(() => { });
            //task.Start();

            //// 方式2
            //Task.Run(() => { });

            //// 方式3
            //Task.Factory.StartNew(() => { });

            // 2、多线程中的异常处理
            // 注意：多线程内部发生异常后，try-catch 无法步骤异常
            // 若想捕捉到异常需要批量等待

            //try
            //{
            //    List<Task> tasks = new();
            //    //string k = string.Empty;
            //    for (int i = 0; i < 110; i++)
            //    {
            //        string k = $"TaskAdvanced_Click_{i}";
            //        tasks.Add(Task.Run(() =>
            //        {
            //            if (k.Equals("TaskAdvanced_Click_2"))
            //            {
            //                throw new Exception("TaskAdvanced_Click_2 异常");
            //            }
            //            else if (k.Equals("TaskAdvanced_Click_5"))
            //            {
            //                throw new Exception("TaskAdvanced_Click_5 异常");
            //            }
            //            else if (k.Equals("TaskAdvanced_Click_8"))
            //            {
            //                throw new Exception("TaskAdvanced_Click_8 异常");
            //            }
            //        }));
            //        Task.WaitAll(tasks.ToArray());
            //    }
            //}
            //catch (AggregateException ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //}


            // 3、线程取消
            // 线程抛出异常时就不再继续往下执行了，其实就取消了
            // 方式一、自定义一个变量

            //bool isOk = true;
            //for (int i = 0; i < 20; i++)
            //{
            //    string k = $"Exception_{i}";
            //    Task.Run(() =>
            //    {
            //        if (!isOk)
            //        {
            //            throw new Exception($"线程异常取消了-{k}");
            //        }
            //        else
            //        {
            //            Debug.WriteLine($"线程正常开始了-{k}");
            //        }

            //        try
            //        {
            //            if (k.Equals("Exception_6"))
            //            {
            //                //isOk = false;
            //                throw new Exception("异常发生了");
            //            }
            //            else if (k.Equals("Exception_15"))
            //            {
            //                //isOk = false;
            //                throw new Exception("异常发生了");
            //            }
            //        }
            //        catch (Exception)
            //        {
            //            isOk = false;
            //        }
            //    });

            //}

            // 方式二、采用线程安全的做法 CancellationTokenSource 实例 IsCancellationRequested 属性和 Cancel 方法

            CancellationTokenSource cts = new();
            //_ = cts.IsCancellationRequested;
            for (int i = 0; i < 200; i++)
            {
                string k = $"Exception_{i}";
                Task.Run(() =>
                {
                    if (cts.IsCancellationRequested)
                    {
                        throw new Exception($"线程Id-{Environment.CurrentManagedThreadId}异常取消了-{k}");
                    }
                    else
                    {
                        Debug.WriteLine($"线程正常开始了-{k}");
                    }

                    try
                    {
                        if (k.Equals("Exception_6"))
                        {
                            throw new Exception("异常发生了");
                        }
                        else if (k.Equals("Exception_15"))
                        {
                            throw new Exception("异常发生了");
                        }
                    }
                    catch (Exception)
                    {
                        cts.Cancel();
                    }

                    if (cts.IsCancellationRequested)
                    {
                        throw new Exception($"线程Id-{Environment.CurrentManagedThreadId}异常取消了-{k}");
                    }
                    else
                    {
                        Debug.WriteLine($"线程正常结束了-{k}");
                    }
                }, cts.Token);

            }

            // 4、临时变量问题
            // 临时变量需要定义在线程外面，如果线程内对临时变量赋值的话

            // 5、线程安全问题


        }
    }
}
