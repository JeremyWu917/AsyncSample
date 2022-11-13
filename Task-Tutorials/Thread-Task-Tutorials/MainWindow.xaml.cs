using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

            try
            {
                List<Task> tasks = new();
                string k = string.Empty;
                for (int i = 0; i < 10; i++)
                {
                    k = $"TaskAdvanced_Click_{i}";
                    tasks.Add(Task.Run(() =>
                    {
                        if (k.Equals("TaskAdvanced_Click_2"))
                        {
                            throw new Exception("TaskAdvanced_Click_2 异常");
                        }
                        else if (k.Equals("TaskAdvanced_Click_5"))
                        {
                            throw new Exception("TaskAdvanced_Click_5 异常");
                        }
                        else if (k.Equals("TaskAdvanced_Click_8"))
                        {
                            throw new Exception("TaskAdvanced_Click_8 异常");
                        }
                    }));
                    Task.WaitAll(tasks.ToArray());
                }
            }
            catch (AggregateException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            // 3、线程取消

            // 4、临时变量问题

            // 5、线程安全问题


        }
    }
}
