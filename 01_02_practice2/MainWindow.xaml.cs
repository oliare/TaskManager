using System;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace _01_02_practice2
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private Process p = new Process();

        public MainWindow()
        {
            InitializeComponent();
            RefreshProcess(null, null);
            timer = new DispatcherTimer();

            timer.Interval = new TimeSpan(0, 1, 0);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void RefreshProcess(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = Process.GetProcesses();
        }

        private void EndProcess(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedProcess = grid.SelectedItem as Process;
                if (selectedProcess != null)
                {
                    selectedProcess.Kill();
                }
                else
                    MessageBox.Show("No process selected!");
            }
            catch (Exception)
            {
                MessageBox.Show("Access is denied");
            }
        }
        private void ViewProcessInfo(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedProcess = grid.SelectedItem as Process;
                if (selectedProcess != null)
                {
                    MessageBox.Show($"Process Name: {selectedProcess.ProcessName}\n" +
                                    $"Id: {selectedProcess.Id}\n" +
                                    $"Priority: {selectedProcess.PriorityClass}\n" +
                                    $"Start Time: {selectedProcess.StartTime}\n" +
                                    $"Virtual Memory Size: {selectedProcess.VirtualMemorySize64}\n" +
                                    $"Exit Time: {selectedProcess.ExitTime}");
                }
                else
                    MessageBox.Show("No process selected!");
            }
            catch (Exception)
            {
                MessageBox.Show("Access is denied");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            RefreshProcess(sender, null);
        }

        private void Timer_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer.Interval = new TimeSpan(0,0,1);
            timer.Start();
        }
        private void Timer_Click_2(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start(); 
        }
        private void Timer_Click_5(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start(); 
        }
        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
            if (e.Key == Key.Enter)
            {
                var path = textBox.Text;
                p.StartInfo.FileName = path;
                p.Start();
            }

            }
            catch (Exception)
            {
                MessageBox.Show("Unpossible to start process");
            }
        }
    }
}
