using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class MainWindow : Window
    {
        public DispatcherTimer timer;
        int t = 11;
        int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
            Timer_Set();
        }

        public void Timer_Set()
        {
            timer = new DispatcherTimer(DispatcherPriority.Send);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (t > 0)
            {
                t--;
                lblSeconds.Content = string.Format("00:0{0}:0{1}", t / 60, t % 60);
            }
            else
            {
                timer.Stop();
                MessageBox.Show("Ты чудовище, уходи.");
                Application.Current.Shutdown();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            if (counter == 10)
            {
                timer.Stop();
                MessageBox.Show("Умница! Уровень пройден!");
                Lvl2();
            }
        }

        public void Lvl2()
        {
            textBox.Clear();
            textBox.Text = "Level 2";
            smallGrid.Children.Clear();
            Button showImages = new Button()
            {
                Content = "Просто опросик",
                Height = 50,
                Width = 200,
                Margin = new Thickness(0, -200, 0, 250)
            };
            showImages.VerticalAlignment = VerticalAlignment.Bottom;
            showImages.Click += ThereAreNeedToBeAnImages_Click;
            lvl2.Children.Add(showImages);

        }

        private void ThereAreNeedToBeAnImages_Click(object sender, RoutedEventArgs e)
        {

            TextBox tekstik = new TextBox()
            {
                Text = "Кого возьмешь к себе домой?",
                Margin = new Thickness(200, 30, 200, 250),
                FontSize = 25,
                TextAlignment = TextAlignment.Center,
                Visibility = Visibility.Visible,
            };

            lvl2.Children.Add(tekstik);

            Button kitty = new Button()
            {
                Height = 100,
                Margin = new Thickness(50, 0, 575, 0),
                Content = "Кисоньку, конечно",

            };
            kitty.Click += animal_Click;
            lvl2.Children.Add(kitty);

            Button parrot = new Button()
            {
                Height = 100,
                Margin = new Thickness(300, 0, 300, 0),
                Content = "Папуга, естественно",

            };
            parrot.Click += animal_Click;
            lvl2.Children.Add(parrot);

            Button puppy = new Button()
            {
                Height = 100,
                Margin = new Thickness(575, 0, 50, 0),
                Content = "Песоньку, это точно",

            };
            puppy.Click += animal_Click;
            lvl2.Children.Add(puppy);
        }

        private void animal_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Прекрасно, я тоже!");
            Lvl3();
        }

        private void Lvl3()
        {
            textBox.Clear();
            textBox.Text = "Level 3";
            lvl2.Children.Clear();
            TextBox lastText = new TextBox()
            {
                Text = "Ты хто? Выбери ответ",
                FontSize = 20,
                TextAlignment = TextAlignment.Center
            };
            lastText.VerticalAlignment = VerticalAlignment.Top;
            lvl3.Children.Add(lastText);
            Button cuteThings = new Button()
            {
                Content = "Чудо, жми сюда для подтверждения ответа",
                FontSize = 20
            };
            cuteThings.VerticalAlignment = VerticalAlignment.Bottom;
            lvl3.Children.Add(cuteThings);
            cuteThings.Click += CuteThings_Click;
            ComboBox comboBox = new ComboBox()
            {
                Margin = new Thickness(250, 100, 180, 150),
                FontSize = 30
            };
            lvl3.Children.Add(comboBox);
            ObservableCollection<string> cB = new ObservableCollection<string>();
            cB.Add("Лучший кисик на свете");
            cB.Add("Лучший песик на свете");
            cB.Add("Лучший папуг на свете");
            comboBox.ItemsSource = cB;
        }

        private void CuteThings_Click(object sender, RoutedEventArgs e)
        {
            foreach (var element in lvl3.Children)
            {
                if (element is ComboBox comboB)
                {
                    if (comboB.SelectedItem is "Лучший кисик на свете")
                    {
                        MessageBox.Show("Да, ты с:");
                        
                    }
                    else if (comboB.SelectedItem is "Лучший песик на свете")
                    {
                        MessageBox.Show("Да, ты с:");
                        
                    }
                    else
                    {
                        MessageBox.Show("Да, ты с:");
                        
                    }
                }
            }
            EndOfGame();
        }

        public void EndOfGame()
        {
            MessageBox.Show("YOU ARE BREATHTAKING!");
            Application.Current.Shutdown();
        }
    } 
}
