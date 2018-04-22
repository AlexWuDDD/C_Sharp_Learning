using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using System.Threading;

namespace SimpleWorker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker bgWorker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();

            bgWorker.WorkerReportsProgress      = true;
            bgWorker.WorkerSupportsCancellation = true;

            bgWorker.DoWork             += DoWork_Handler;
            bgWorker.ProgressChanged    += ProgressChanged_Handler;
            bgWorker.RunWorkerCompleted += RunWorkerCompleted_Handler;
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            if (!bgWorker.IsBusy)
                bgWorker.RunWorkerAsync(); //获取后台线程并且执行DoWork事件处理程序
        }

        private void ProgressChanged_Handler(object sender, ProgressChangedEventArgs args)
        {
            progressBar.Value = args.ProgressPercentage;
        }

        private void DoWork_Handler(object sender, DoWorkEventArgs args)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for(int i = 1; i <= 10; ++i)
            {
                if(worker.CancellationPending)
                {
                    args.Cancel = true;
                    break;
                }
                else
                {
                    worker.ReportProgress(i * 10);//希望向主线程汇报进度的时候，调用ReportProgress方法。触发ProgressChanged事件，主线程可以处理附加到ProgressChangeds事件上的处理程序
                    Thread.Sleep(500);
                }
            }
        }

        //处理后台线程完成Dowork事件处理程序的执行之后需要执行的代码
        private void RunWorkerCompleted_Handler(object sender, RunWorkerCompletedEventArgs args)
        {
            progressBar.Value = 0;
            if (args.Cancelled)
                MessageBox.Show("Process was cancelled", "Process Cancelled");
            else
                MessageBox.Show("Process completed normally", "Process Completed");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            bgWorker.CancelAsync();//把CancellationPending属性设置为true.DoWorker事件处理程序需要检查这个属性来决定是否应该停止处理
        }
    }
}
