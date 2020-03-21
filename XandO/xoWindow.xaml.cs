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
using System.Windows.Shapes;

namespace XandO
{
    /// <summary>
    /// Логика взаимодействия для xoWindow.xaml
    /// </summary>
    public partial class xoWindow : Window
    {
        int n = 0;
        Button btn = new Button();
        bool pers = false;
        bool duelOrBot;
        public xoWindow(bool duelOrBot)
        {
            InitializeComponent();
            field();
            this.duelOrBot = duelOrBot;
        }


        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if(duelOrBot)
            {
                if (!pers)
                {
                    pers = true;
                    (sender as Button).Tag = "o";
                    (sender as Button).Content = "O";
                }
                else
                {
                    pers = false;
                    (sender as Button).Tag = "x";
                    (sender as Button).Content = "X";

                }

                (sender as Button).IsEnabled = false;
                check((sender as Button).Tag.ToString());
            }

            if(!duelOrBot)
            {
                bool proverka = false;
                (sender as Button).Tag = "o";
                (sender as Button).Content = "O";

                (sender as Button).IsEnabled = false;

                check("o");
                botMove(botCheck("x"), "x",ref proverka);
                botMove(botCheck("o"), "o",ref proverka);
                check("x");


                
            }
        }

        private List<int> botCheck(string xo)
        {
            List<int> num = new List<int>();
            int n = 1;
            foreach (Button item in OvnGrid.Children)
            {
                if (!item.IsEnabled && item.Tag as string == xo)
                {
                    num.Add(n);
                }
                n++;
            }
            return num;
        }
        private void botMove(List<int> num, string xo, ref bool proverka)
        {
            if ((num.Contains(2) && num.Contains(3) || num.Contains(4) && num.Contains(7) || num.Contains(5) && num.Contains(9)) && (OvnGrid.Children[0] as Button).IsEnabled)
            {
                    proverka = true;
                    (OvnGrid.Children[0] as Button).IsEnabled = false;
                    (OvnGrid.Children[0] as Button).Tag = "x";
                    (OvnGrid.Children[0] as Button).Content = "X";
            }

            else if ((num.Contains(1) && num.Contains(3) || num.Contains(5) && num.Contains(8)) && (OvnGrid.Children[1] as Button).IsEnabled)
            {
                    proverka = true;
                    (OvnGrid.Children[1] as Button).IsEnabled = false;
                    (OvnGrid.Children[1] as Button).Tag = "x";
                    (OvnGrid.Children[1] as Button).Content = "X";
            }

            else if ((num.Contains(1) && num.Contains(2) || num.Contains(6) && num.Contains(9) || num.Contains(5) && num.Contains(7)) && (OvnGrid.Children[2] as Button).IsEnabled)
            {
                    proverka = true;
                    (OvnGrid.Children[2] as Button).IsEnabled = false;
                    (OvnGrid.Children[2] as Button).Tag = "x";
                    (OvnGrid.Children[2] as Button).Content = "X";
            }

            else if ((num.Contains(1) && num.Contains(7) || num.Contains(5) && num.Contains(6)) && (OvnGrid.Children[3] as Button).IsEnabled)
            {
                    proverka = true;
                    (OvnGrid.Children[3] as Button).IsEnabled = false;
                    (OvnGrid.Children[3] as Button).Tag = "x";
                    (OvnGrid.Children[3] as Button).Content = "X";
            }

            else if ((num.Contains(2) && num.Contains(8) || num.Contains(4) && num.Contains(6) || num.Contains(1) && num.Contains(9) || num.Contains(3) && num.Contains(7)) && (OvnGrid.Children[4] as Button).IsEnabled)
            {
                    proverka = true;
                    (OvnGrid.Children[4] as Button).IsEnabled = false;
                    (OvnGrid.Children[4] as Button).Tag = "x";
                    (OvnGrid.Children[4] as Button).Content = "X";
            }

            else if ((num.Contains(3) && num.Contains(9) || num.Contains(4) && num.Contains(5))&&(OvnGrid.Children[5] as Button).IsEnabled)
            {
                    proverka = true;
                    (OvnGrid.Children[5] as Button).IsEnabled = false;
                    (OvnGrid.Children[5] as Button).Tag = "x";
                    (OvnGrid.Children[5] as Button).Content = "X";
            }

            else if ((num.Contains(1) && num.Contains(4) || num.Contains(8) && num.Contains(9) || num.Contains(5) && num.Contains(3)) && (OvnGrid.Children[6] as Button).IsEnabled)
            {
                    proverka = true;
                    (OvnGrid.Children[6] as Button).IsEnabled = false;
                    (OvnGrid.Children[6] as Button).Tag = "x";
                    (OvnGrid.Children[6] as Button).Content = "X";
            }

            else if ((num.Contains(7) && num.Contains(9) || num.Contains(2) && num.Contains(5)) && (OvnGrid.Children[7] as Button).IsEnabled)
            {
                    proverka = true;
                    (OvnGrid.Children[7] as Button).IsEnabled = false;
                    (OvnGrid.Children[7] as Button).Tag = "x";
                    (OvnGrid.Children[7] as Button).Content = "X";
            }

            else if ((num.Contains(7) && num.Contains(8) || num.Contains(3) && num.Contains(6) || num.Contains(1) && num.Contains(5)) && (OvnGrid.Children[8] as Button).IsEnabled)
            {
                    proverka = true;
                    (OvnGrid.Children[8] as Button).IsEnabled = false;
                    (OvnGrid.Children[8] as Button).Tag = "x";
                    (OvnGrid.Children[8] as Button).Content = "X";
            }

            else if (xo == "o" && proverka == false) 
                {
                    foreach (Button item in OvnGrid.Children)
                    {
                        if (item.IsEnabled)
                        {
                            item.IsEnabled = false;
                            item.Tag = "x";
                            item.Content = "X";
                            break;
                        }
                    }
                }
            if (xo == "o") proverka = false;
            
        }

        private void field()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    btn = new Button();
                    btn.FontSize = 50;
                    Grid.SetColumn(btn, j);
                    Grid.SetRow(btn, i);
                    btn.Click += Btn_Click;
                    OvnGrid.Children.Add(btn);
                    n++;
                }
            }
        }

        private void check(string xo)
        {
            List<int> num = new List<int>();
            int n = 1;
            foreach (Button item in OvnGrid.Children)
            {
                if (!item.IsEnabled && (item.Tag as string) == xo)
                {
                    num.Add(n);
                }
                n++;
            }
            if (num.Contains(1) && num.Contains(2) && num.Contains(3) ||
                num.Contains(4) && num.Contains(5) && num.Contains(6) ||
                num.Contains(7) && num.Contains(8) && num.Contains(9) ||
                num.Contains(1) && num.Contains(5) && num.Contains(9) ||
                num.Contains(3) && num.Contains(5) && num.Contains(7) ||
                num.Contains(1) && num.Contains(4) && num.Contains(7) ||
                num.Contains(2) && num.Contains(5) && num.Contains(8) ||
                num.Contains(3) && num.Contains(6) && num.Contains(9)) 
            {
                MessageBox.Show($"Winner : {xo}");
                DialogResult = true;
                Close();
            }
            else if (num.Count==5)
            {
                MessageBox.Show("Drawn game :)");
                DialogResult = true;
                Close();
            }

        }

        private void OvnGrid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
