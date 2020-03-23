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
using System.Windows.Threading;

namespace Quest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer timer;
        public TimeSpan timetozero;
        public readonly TimeSpan interval = TimeSpan.FromMilliseconds(-15);

        public MainWindow()
        {
            InitializeComponent();
            Timer_Set();
        }

        public void Timer_Set() 
        {
            timer = new DispatcherTimer(DispatcherPriority.Send);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = TimeSpan.FromMilliseconds(15);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblSeconds.Content = DateTime.Now.Second;
            CommandManager.InvalidateRequerySuggested();
            lblSeconds.Visibility = Visibility.Visible;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            counter++;
            if (counter == 10 && (int)lblSeconds.Content != 0)
            {
                MessageBox.Show("Уровень пройден");
            }
            else if (counter <= 10 && (int)lblSeconds.Content != 0)
            {

            }
            else
            {
                MessageBox.Show("Не успел, старайся лучше");
            }


            //if()
            //    {
            //    for (int i = 0; i < 10; i++)
            //    {

            //    }
            //}
        }
    }
}
