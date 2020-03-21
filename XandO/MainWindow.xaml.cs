using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Threading;

namespace XandO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lb1.ItemsSource = matches;
        }
        ObservableCollection<TimeSpan> matches = new ObservableCollection<TimeSpan>();
        int seconds;
        public void fastestGames(xoWindow window)
        {
            seconds = 0;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            if (window.ShowDialog() == true)
            {
                timer.Stop();
                if (matches.Count < 3)
                {
                    matches.Add(TimeSpan.FromSeconds(seconds));
                }
                else if (matches.Count >= 3)
                {
                    for (int i = 0; i < matches.Count; i++)
                    {
                        if (matches[i].TotalSeconds > seconds)
                        {
                            matches[i] = TimeSpan.FromSeconds(seconds);
                        }
                    }
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            fastestGames(new xoWindow(true)); 
           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            fastestGames(new xoWindow(false));
        }
    }
}
