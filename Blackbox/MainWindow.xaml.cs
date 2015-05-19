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

namespace Blackbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ ";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            char input = 'A';
            char output = textBox1.Text[0];
            int inputindex = abc.IndexOf(input);
            int outputindex = abc.IndexOf(output);
            int diff = outputindex - inputindex;
            Console.WriteLine("size" + abc.Length);

            Console.WriteLine(inputindex);
            Console.WriteLine(outputindex);

            string pass = string.Empty;
            string expec = textBox2.Text;
            foreach (char item in expec)
            {
                int findex = abc.IndexOf(item);
                int orgindex = findex - diff;
                if (orgindex < 0)
                {
                    orgindex += abc.Length;
                }
                pass += abc[orgindex];
            }
            textBox3.Text = pass;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string expec = textBox4.Text;
            string pass = expec[0].ToString();
            int firstn = abc.IndexOf(expec[0]);
            for (int i = 1; i < expec.Length; i++)
            {
                int cindex = abc.IndexOf(expec[i]);
                int orgindex = cindex - firstn;
                firstn += cindex;
                firstn = firstn % abc.Length;
                if (orgindex < 0)
                {
                    orgindex += abc.Length;
                }
                pass += abc[orgindex];
            }
            textBox5.Text =pass;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            char input = 'A';
            char output = Convert.ToChar(textBox6.Text);
            int inputindex = abc.IndexOf(input);
            int outputindex = abc.IndexOf(output);
            int diff = outputindex - inputindex;
            string pass = string.Empty;
            string expec = textBox7.Text;
            foreach (char item in expec)
            {
                int findex = abc.IndexOf(item);
                int orgindex = findex - diff;
                if (orgindex < 0)
                {
                    orgindex += abc.Length;
                }
                pass += abc[orgindex];
            }
            pass = ReverseString(pass);
            textBox8.Text = pass;
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            string expec = textBox4_1.Text;
            string pass = expec[0].ToString();
            char output = textBox4_2.Text[0];
            int diff = abc.IndexOf(output);
            Console.WriteLine(diff);
            for (int i = 1; i < expec.Length; i++)
            {
                int cindex = abc.IndexOf(expec[i]);
                int bfcindex = abc.IndexOf(expec[i - 1]);
                int orgindex = cindex - bfcindex - diff + abc.IndexOf(pass[i - 1]);
                if (orgindex < 0)
                {
                    orgindex += abc.Length*2;
                }
                orgindex = orgindex % abc.Length;
                pass += abc[orgindex];
            }
            textBox4_3.Text = pass;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            string expec = textBox5_1.Text;
            char output = textBox5_2.Text[0];
            int vdiff = abc.IndexOf(output);
            int ss = (abc.IndexOf(expec[0]) - vdiff) + abc.Length * 2;
            string pass = abc[ss % abc.Length].ToString();

            for (int i = 1; i < expec.Length; i++)
            {
                int cindex = abc.IndexOf(expec[i]);
                int bfcindex = abc.IndexOf(expec[i - 1]);
                int orgindex = cindex - bfcindex * 2 + abc.IndexOf(pass[i - 1]);
                if (orgindex < 0)
                {
                    orgindex += abc.Length * 2;
                }
                orgindex = orgindex % abc.Length;
                pass += abc[orgindex];
            }
            pass = ReverseString(pass);
            textBox5_3.Text = pass;
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            string expec = textBox6_1.Text;
            char output = textBox6_2.Text[0];
            int vdiff = abc.IndexOf(output);
            int ss = (abc.IndexOf(expec[0]) - vdiff) + abc.Length * 2;
            string pass = abc[ss % abc.Length].ToString();

            for (int i = 1; i < expec.Length; i++)
            {
                int cindex = 0;
                int bfcindex = 0;
                int orgindex = 0;
                switch (i % 4)
                {
                    case 2:
                        cindex = abc.IndexOf(expec[i + 1]);
                        bfcindex = abc.IndexOf(expec[i - 1]);
                        orgindex = cindex - bfcindex * 2 - 1 + abc.IndexOf(pass[i - 1]);
                        break;
                    case 3:
                        cindex = abc.IndexOf(expec[i - 1]);
                        bfcindex = abc.IndexOf(expec[i]);
                        orgindex = cindex - bfcindex * 2 - 1 + abc.IndexOf(pass[i - 1]);
                        break;
                    case 1:
                        cindex = abc.IndexOf(expec[i]);
                        bfcindex = abc.IndexOf(expec[i - 1]);
                        orgindex = cindex - bfcindex * 2 - 1 + abc.IndexOf(pass[i - 1]);
                        break;
                    default:
                        cindex = abc.IndexOf(expec[i]);
                        bfcindex = abc.IndexOf(expec[i - 2]);
                        orgindex = cindex - bfcindex * 2 - 1 + abc.IndexOf(pass[i - 1]);
                        break;
                }
                if (orgindex < 0)
                {
                    orgindex += abc.Length * 2;
                }
                orgindex = orgindex % abc.Length;
                pass += abc[orgindex];
            }
            textBox6_3.Text = pass;
        }
    }
}
