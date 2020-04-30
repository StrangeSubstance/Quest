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
        int numOfLvl;

        public MainWindow()
        {
            InitializeComponent();
            Timer_Set();
            numOfLvl = 1;
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
            skip.Visibility = Visibility.Visible;
            numOfLvl = 2;
            Button back = new Button() 
            {
                Margin = new Thickness(0, 27, 618, 0),
                Content = "Вернуться назад",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 35,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 121
            };
            back.Click += Back_Click;
            bigGrid.Children.Add(back);
            
            Button showImages = new Button()
            {
                Content = "Просто опросик",
                Height = 50,
                Width = 200,
                Margin = new Thickness(0, -200, 0, 250)
            };
            showImages.VerticalAlignment = VerticalAlignment.Bottom;
            showImages.Click += ThereAreNeedToBeAnImages_Click;
            smallGrid.Children.Add(showImages);

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

            smallGrid.Children.Add(tekstik);

            Button kitty = new Button()
            {
                Height = 100,
                Margin = new Thickness(50, 0, 575, 0),
                Content = "Кисоньку, конечно",

            };
            kitty.Click += animal_Click;
            smallGrid.Children.Add(kitty);

            Button parrot = new Button()
            {
                Height = 100,
                Margin = new Thickness(300, 0, 300, 0),
                Content = "Папуга, естественно",

            };
            parrot.Click += animal_Click;
            smallGrid.Children.Add(parrot);

            Button puppy = new Button()
            {
                Height = 100,
                Margin = new Thickness(575, 0, 50, 0),
                Content = "Песоньку, это точно",

            };
            puppy.Click += animal_Click;
            smallGrid.Children.Add(puppy);
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
            smallGrid.Children.Clear();
            skip.Visibility = Visibility.Visible;
            numOfLvl = 3;
            TextBox lastText = new TextBox()
            {
                Text = "Ты хто? Выбери ответ",
                FontSize = 20,
                TextAlignment = TextAlignment.Center
            };
            lastText.VerticalAlignment = VerticalAlignment.Top;
            smallGrid.Children.Add(lastText);
            Button cuteThings = new Button()
            {
                Content = "Чудо, жми сюда для подтверждения ответа",
                FontSize = 20
            };
            cuteThings.VerticalAlignment = VerticalAlignment.Bottom;
            smallGrid.Children.Add(cuteThings);
            cuteThings.Click += CuteThings_Click;
            ComboBox comboBox = new ComboBox()
            {
                Margin = new Thickness(250, 100, 180, 150),
                FontSize = 30
            };
            smallGrid.Children.Add(comboBox);
            ObservableCollection<string> cB = new ObservableCollection<string>();
            cB.Add("Лучший кисик на свете");
            cB.Add("Лучший песик на свете");
            cB.Add("Лучший папуг на свете");
            comboBox.ItemsSource = cB;
        }

        private void CuteThings_Click(object sender, RoutedEventArgs e)
        {
            foreach (var element in smallGrid.Children)
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
            Lvl4();
        }
        private void Lvl4()
        {
            textBox.Clear();
            textBox.Text = "Level 4";
            smallGrid.Children.Clear();
            skip.Visibility = Visibility.Visible;
            numOfLvl = 4;
            TextBox question = new TextBox()
            {
                Height = 50,
                FontSize = 25,
                Width = 400,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, -280, 0, 0),
                Text = "Выбери свой пол, пожалуйста:"
            };
            smallGrid.Children.Add(question);

            RadioButton female = new RadioButton()
            {
                Content = "Женщина",
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 70, 0, 0)
            };
            smallGrid.Children.Add(female);

            RadioButton male = new RadioButton()
            {
                Content = "Мужчина",
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 120, 0, 0)
            };
            smallGrid.Children.Add(male);

            Button confirm = new Button
            {
                Content = "Спасибо, а теперь подтверди выбор",
                FontSize = 20,
                Height = 50,
                Width = 400,
                Margin = new Thickness(0, 50, 0, 0)
            };
            smallGrid.Children.Add(confirm);
            confirm.Click += Confirm_Click;
        }


        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            NextStep();
        }

        private void NextStep()
        {
            smallGrid.Children.Clear();
            TextBox sorry = new TextBox()
            {
                Height = 50,
                FontSize = 25,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, -280, 0, 0),
                Text = "Ой, я не могу пока что считать результаты, в любом случае.."
            };
            smallGrid.Children.Add(sorry);
            TextBox newQuestion = new TextBox()
            {
                Text = "Лучше свое любимое домашнее животное отметь",
                FontSize = 25,
                Height = 50,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, -180, 0, 0)
            };
            smallGrid.Children.Add(newQuestion);
            CheckBox kitty = new CheckBox()
            {
                FontSize = 25,
                Content = "Ласковый котенок",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 110, 0, 0)
            };
            smallGrid.Children.Add(kitty);
            CheckBox parrot = new CheckBox()
            {
                FontSize = 25,
                Content = "Потрясающий папуг",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(20, 150, 0, 0)
            };
            smallGrid.Children.Add(parrot);
            CheckBox puppy = new CheckBox()
            {
                FontSize = 25,
                Content = "Прелестный песик",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 190, 0, 0)
            };
            smallGrid.Children.Add(puppy);
            Button newConfirm = new Button()
            {
                FontSize = 25,
                Content = "Жмякай сюда, пожалуйста",
                Margin = new Thickness(0, 150, 0, 0),
                Height = 50,
                Width = 310
            };
            smallGrid.Children.Add(newConfirm);
            newConfirm.Click += NewConfirm_Click;
        }

        private void NewConfirm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Это лучший выбор, я считаю");
            Lvl5();
        }

        public void Lvl5()
        {
            textBox.Clear();
            textBox.Text = "Level 5";
            smallGrid.Children.Clear();
            skip.Visibility = Visibility.Visible;
            numOfLvl = 5;
            TextBox tB = new TextBox()
            {
                Text = "А теперь серьезно.. Вот курс нескольких валют:",
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            smallGrid.Children.Add(tB);
            ListBox listBox = new ListBox()
            {
                FontSize = 25,
                Margin = new Thickness(0,40,0,0),
                HorizontalContentAlignment = HorizontalAlignment.Center
            };
            ObservableCollection<string> lB = new ObservableCollection<string>();
            lB.Add("1 доллар = 74,66 рублей");
            lB.Add("1 евро = 80,63 рубля");
            lB.Add("1 тенге = 0,17 рубля");
            listBox.ItemsSource = lB;
            smallGrid.Children.Add(listBox);
            Label labelHelp = new Label()
            {
                Margin = new Thickness(0, 150, 0, 0),
                FontSize = 25,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Content = "Проанализируй имеющуюся информацию и, с учетом нынешней \nполитической ситуации в мире " +
                "и нынешней цены \nна нефть, предскажи, как будет изменяться стоимость \nрубля по " +
                "отношению к доллару, тенге и евро."
            };
            smallGrid.Children.Add(labelHelp);

            TimerIsOut();
        }

        public void TimerIsOut()
        {
            timer = new DispatcherTimer(DispatcherPriority.Send);
            timer.Tick += new EventHandler(TIO_Tick);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        public void TIO_Tick(object sender, EventArgs e)
        {
            if (t > 0)
            {
                t--;
            }
            else
            {
                timer.Stop();
                MessageBox.Show("Мммммм... Понятно..");
                NextStepLvl5();
            }
        }

        public void NextStepLvl5()
        {
            smallGrid.Children.Clear();
            Label tBox = new Label()
            {
                Content = "Хахах, ладно, я пошутила. Вот списочек милых животных",
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };
            smallGrid.Children.Add(tBox);

            ListView listView = new ListView() 
            {
                Margin = new Thickness(0,70,0,70)
            };

            GridView gridView = new GridView();
            GridViewColumn column1 = new GridViewColumn
            {
                Header = "Животное",
                Width = 400,
                HeaderContainerStyle = (Style)Resources["ColumnHeaderLarge"],
                DisplayMemberBinding = new Binding("Животное")
                //CellTemplate = (DataTemplate)FindResource("keyForPuppy")
            };
            
            gridView.Columns.Add(column1);

            GridViewColumn column2 = new GridViewColumn
            {
                Header = "Есть ли крылья",
                Width = 400,
                HeaderContainerStyle = (Style)Resources["ColumnHeaderLarge"],
                DisplayMemberBinding = new Binding("Летает")
            };
            gridView.Columns.Add(column2);
            listView.Items.Add(new MyAnimal { Животное = "Кисик", Летает = "Неть" });
            listView.Items.Add(new MyAnimal { Животное = "Песик", Летает = "Неть" });
            listView.Items.Add(new MyAnimal { Животное = "Папуг", Летает = "Дя" });

            Button buttonNext = new Button
            {
                FontSize = 25,
                VerticalAlignment = VerticalAlignment.Bottom,
                Content = "Пройти дальше, что ли.."
            };
            smallGrid.Children.Add(buttonNext);
            buttonNext.Click += ButtonNext_Click;
            
            listView.View = gridView;
            smallGrid.Children.Add(listView);
        }
        

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Хихи, проходи дальше");
            Lvl6();
        }

        public void Lvl6() 
        {
            textBox.Clear();
            textBox.Text = "Level 6";
            smallGrid.Children.Clear();
            skip.Visibility = Visibility.Visible;
            numOfLvl = 6;
            Label oops = new Label() 
            {
                Content = "Ой, а куда все пропали?\nХмммм, попробуешь ниже нажать\nна правую кнопку?",
                FontSize = 25,
                Margin = new Thickness(150,0,150,220)
            };
            smallGrid.Children.Add(oops);

            Label clickHere = new Label()
            {
                Content = "Воть сюда с:",
                FontSize = 25,
                Margin = new Thickness(200, 150, 200, 70)
            };
            smallGrid.Children.Add(clickHere);

            ContextMenu contextMenu = new ContextMenu()
            {
                FontSize = 25,
                HorizontalContentAlignment = HorizontalAlignment.Center
            };
            clickHere.ContextMenu = contextMenu;
            MenuItem wooow = new MenuItem() 
            {
                Header = "Ого, все здесь с:",
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            contextMenu.Items.Add(wooow);
            MenuItem puppy = new MenuItem() 
            {
                FontSize = 15,
                Header = "Щеночечьки",//то, что отображается в контекст меню
                Name = "puppies"//ключ, по которому можно вызвать айтем в другом методе
            };
            contextMenu.Items.Add(puppy);
            MenuItem kitty = new MenuItem()
            {
                FontSize = 15,
                Header = "Китюнечьки",//то, что отображается в контекст меню
                Name = "kitties"//ключ, по которому можно вызвать айтем в другом методе
            };
            contextMenu.Items.Add(kitty);
            MenuItem parrot = new MenuItem()
            {
                FontSize = 15,
                Header = "Папужики",//то, что отображается в контекст меню
                Name = "parrots"//ключ, по которому можно вызвать айтем в другом методе
            };
            contextMenu.Items.Add(parrot);
            parrot.Click += Parrot_Click;
            puppy.Click += Puppy_Click;
            kitty.Click += Kitty_Click;
        }

        private void Kitty_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кисики - замурррчательные животные,\nГлавная цель - научить отзываться на свое имя");
            Lvl7();
        }

        private void Puppy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Песики - Прекрасные животинки,\nГлавная цель - научить подавать лапу");
            Lvl7();
        }

        private void Parrot_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Папужики - такие очаровашки,\nГлавная цель - научить их говорить");
            Lvl7();
        }

        public void Lvl7()
        {
            textBox.Clear();
            textBox.Text = "Level 7";
            smallGrid.Children.Clear();
            skip.Visibility = Visibility.Visible;
            numOfLvl = 7;
            TreeView treeView = new TreeView() 
            {
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Width = 400,
                Margin = new Thickness(0,5,0,150)
            };
            smallGrid.Children.Add(treeView);
            TreeViewItem animal = new TreeViewItem() 
            {
                FontSize = 25,
                Header = "Животные"
            };
            treeView.Items.Add(animal);
            TreeViewItem kitty = new TreeViewItem() 
            {
                FontSize = 20,
                Header = "Кисонька"
            };
            animal.Items.Add(kitty);
            TreeViewItem puppy = new TreeViewItem() 
            {
                FontSize = 20,
                Header = "Песонька"
            };
            animal.Items.Add(puppy);
            TreeViewItem birds = new TreeViewItem()
            {
                FontSize = 25,
                Header = "Птички"
            };
            treeView.Items.Add(birds);
            TreeViewItem parrot = new TreeViewItem() 
            {
                FontSize = 20,
                Header = "Попугайчик"
            };
            birds.Items.Add(parrot);

            Label FinalO4ka = new Label() 
            {
                Content = "Список еще будет обновляться, а пока..Можешь идти дальше",
                Margin = new Thickness(0,210,0,70),
                FontSize = 25,
                HorizontalContentAlignment = HorizontalAlignment.Center
            };
            smallGrid.Children.Add(FinalO4ka);

            Button final = new Button() 
            {
                FontSize = 25,
                Content = "Ого, переход на последний уровень?",
                Margin = new Thickness(0,270,0,20),
                HorizontalContentAlignment = HorizontalAlignment.Center
            };
            smallGrid.Children.Add(final);
            final.Click += Final_Click;
        }

        private void Final_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вау, мы почти сделали это..");
            Lvl8();
        }

        public void Lvl8() 
        {
            textBox.Clear();
            textBox.Text = "Level 8";
            smallGrid.Children.Clear();
            skip.Visibility = Visibility.Hidden;
            numOfLvl = 8;
            DataGrid dataGrid = new DataGrid() 
            {
                //AutoGenerateColumns = true,
                FontSize = 25
            };
            smallGrid.Children.Add(dataGrid);

            List<Animal> animals = new List<Animal>
            {
                new Animal { Животное = "Кисонька", Возраст = "от 2 до 16" },
                new Animal { Животное = "Песонька", Возраст = "от 10 до 13" },
                new Animal { Животное = "Папуг", Возраст = "от 5 до 10" }
            };
            dataGrid.ItemsSource = animals;

            Label lastLB = new Label() 
            {
                Content = "Ого, пришло время подвести итоги..",
                FontSize = 25,
                Margin = new Thickness(0,250,0,30),
                HorizontalContentAlignment = HorizontalAlignment.Center
            };
            smallGrid.Children.Add(lastLB);
            Button lastB = new Button() 
            {
                FontSize = 25,
                Content = "Подвести итоги",
                VerticalAlignment = VerticalAlignment.Bottom
            };
            smallGrid.Children.Add(lastB);
            lastB.Click += LastB_Click;
        }

        private void LastB_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Надеюсь, тебе стало лучше");
            EndOfGame();
        }

        public void EndOfGame()
        {
            MessageBox.Show("YOU ARE BREATHTAKING!");
            Application.Current.Shutdown();
        }

        public class MyAnimal
        {
            public string Животное { get; set; }

            public string Летает { get; set; }
        }

        public class Animal
        {
            public string Животное { get; set; }
            public string Возраст { get; set; }
        }

        private void Skip_Click(object sender, RoutedEventArgs e)
        {
            switch (numOfLvl)
            {
                case 1:
                    Lvl2();
                    timer.Stop();
                    break;
                case 2:
                    Lvl3();
                    break;
                case 3:
                    Lvl4();
                    break;
                case 4:
                    Lvl5();
                    break;
                case 5:
                    Lvl6();
                    timer.Stop();
                    break;
                case 6:
                    Lvl7();
                    break;
                case 7:
                    Lvl8();
                    break;
                default:
                    break;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            switch (numOfLvl)
            {
                case 2:
                    MessageBox.Show("Проще уж было перезапустить программу, мда");
                    Close();
                    break;
                case 3:
                    Lvl2();
                    break;
                case 4:
                    Lvl3();
                    break;
                case 5:
                    Lvl4();
                    timer.Stop();
                    break;
                case 6:
                    Lvl5();
                    break;
                case 7:
                    Lvl6();
                    break;
                case 8:
                    Lvl7();
                    break;
                default:
                    break;
            }
        }
    }


}
