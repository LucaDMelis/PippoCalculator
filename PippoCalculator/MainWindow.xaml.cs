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

namespace PippoCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<string> symbles = new List<string> { "+", "-", "*", "/" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string el = b.Content.ToString();

            if (symbles.Contains(el))
                el = " " + el + " ";

            tb.Text += el;
           
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                result();
            }
            catch (Exception exc)
            {
                tb.Text = "Error!";
            }
        }

        private void result()
        {
            int iOp = 0;
            if (tb.Text.Contains("+"))
            {
                iOp = tb.Text.IndexOf("+");
            }
            else if (tb.Text.Contains("-"))
            {
                iOp = tb.Text.IndexOf("-");
            }
            else if (tb.Text.Contains("*"))
            {
                iOp = tb.Text.IndexOf("*");
            }
            else if (tb.Text.Contains("/"))
            {
                iOp = tb.Text.IndexOf("/");
            }
            else
            {
                //tb.Text = "Error!";
                return;
            }
            String op = tb.Text.Substring(iOp, 1);
            double op1 = Convert.ToDouble(tb.Text.Substring(0, iOp));
            double op2 = Convert.ToDouble(tb.Text.Substring(iOp + 1, tb.Text.Length - iOp - 1));

            if (op == "+")
            {
                tb.Text = (op1 + op2).ToString();
            }
            else if (op == "-")
            {
                tb.Text = (op1 - op2).ToString();
            }
            else if (op == "*")
            {
                tb.Text = (op1 * op2).ToString();
            }
            else
            {
                tb.Text = (op1 / op2).ToString();
            }

        }

        private void Canc_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length > 0)
            {
                tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);
            }
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
