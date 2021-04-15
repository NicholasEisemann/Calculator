using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Data;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {

        public static class Calculator
        {
            // Определим функции для доступных операторов
            private static Dictionary<char, Func<double, double, double>> Operators { get; } = new Dictionary<char, Func<double, double, double>> {
        { '+', (a, b) => a + b },
        { '-', (a, b) => a - b },
        { '/', (a, b) => a / b },
        { '%', (a, b) => a % b },
        { '*', (a, b) => a * b }
    };

            public static double Calc(string Expression)
            {
                // Очистим нашу строку от "мусора" в лице пробелов и прочих нехороших знаков
                Expression = string.Concat(Expression.Where(x => char.IsDigit(x) || Operators.ContainsKey(x) || x == '.'));

                try
                {
                    int begin = 0;
                    int end = 0;

                    // Заведем переменные для хранения наших чисел и оператора
                    string a = string.Empty;
                    string b = string.Empty;
                    char op = '\0';

                    // Считаем переменную a из строки
                    while (end < Expression.Length && (char.IsDigit(Expression[end]) || Expression[end] == '.'))
                        end++;
                    a = Expression.Substring(0, end);

                    // Если строка закончилась, значит нам отдали только одно число. Его же и вернем
                    if (end == Expression.Length)
                        return double.Parse(a);

                    // Считаем оператор
                    op = Expression[end++];

                    begin = end;

                    // Считаем переменную b
                    while (end < Expression.Length && (char.IsDigit(Expression[end]) || Expression[end] == '.'))
                        end++;
                    b = Expression.Substring(begin, end - begin);


                    // Достанем из словаря нужную нам функцию и запустим ее с двумя параметрами
                    return Operators[op](double.Parse(a), double.Parse(b));
                    
                }
                catch
                {
                    // Выражение некорректно и не может быть вычислено 
                    throw new EvaluateException();
                }
            }
        }





        public MainPage()
        {
            InitializeComponent();
        }

        void Button_Clicked_AC(System.Object sender, System.EventArgs e)
        {
            LableText.Text = "";
        }

        void Button_Clicked_0(System.Object sender, System.EventArgs e)
        {
            LableText.Text = LableText.Text + "0";
        }

        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            if (LableText.Text == "0")
            {
                LableText.Text = "1";
            }
            else
            {
                LableText.Text = LableText.Text + "1";
            }
        }

        void Button_Clicked_2(System.Object sender, System.EventArgs e)
        {
            if (LableText.Text == "0")
            {
                LableText.Text = "2";
            }
            else
            {
                LableText.Text = LableText.Text + "2";
            }
        }

        void Button_Clicked_3(System.Object sender, System.EventArgs e)
        {
            if (LableText.Text == "0")
            {
                LableText.Text = "3";
            }
            else
            {
                LableText.Text = LableText.Text + "3";
            }
        }

        void Button_Clicked_4(System.Object sender, System.EventArgs e)
        {
            if (LableText.Text == "0")
            {
                LableText.Text = "4";
            }
            else
            {
                LableText.Text = LableText.Text + "4";
            }
        }

        void Button_Clicked_5(System.Object sender, System.EventArgs e)
        {
            if (LableText.Text == "0")
            {
                LableText.Text = "5";
            }
            else
            {
                LableText.Text = LableText.Text + "5";
            }
        }

        void Button_Clicked_6(System.Object sender, System.EventArgs e)
        {
            if (LableText.Text == "0")
            {
                LableText.Text = "6";
            }
            else
            {
                LableText.Text = LableText.Text + "6";
            }
        }

        void Button_Clicked_7(System.Object sender, System.EventArgs e)
        {
            if (LableText.Text == "0")
            {
                LableText.Text = "7";
            }
            else
            {
                LableText.Text = LableText.Text + "7";
            }
        }

        void Button_Clicked_8(System.Object sender, System.EventArgs e)
        {
            if (LableText.Text == "0")
            {
                LableText.Text = "8";
            }
            else
            {
                LableText.Text = LableText.Text + "8";
            }
        }

        void Button_Clicked_9(System.Object sender, System.EventArgs e)
        {
            if (LableText.Text == "0")
            {
                LableText.Text = "9";
            }
            else
            {
                LableText.Text = LableText.Text + "9";
            }
        }

        void Button_Clicked_plus(System.Object sender, System.EventArgs e)
        {
            LableText.Text = LableText.Text + "+";
        }

        void Button_Clicked_minus(System.Object sender, System.EventArgs e)
        {
            LableText.Text = LableText.Text + "-";
        }

        void Button_Clicked_multiply(System.Object sender, System.EventArgs e)
        {
            LableText.Text = LableText.Text + "*";
        }

        void Button_Clicked_equally(System.Object sender, System.EventArgs e)
        {
            double equally = Calculator.Calc(LableText.Text);
            string v = equally.ToString();
            LableText.Text = v;

        }

        void Button_Clicked_share(System.Object sender, System.EventArgs e)
        {
            LableText.Text = LableText.Text + "/";
        }

        void Button_Clicked_comma(System.Object sender, System.EventArgs e)
        {
            LableText.Text = LableText.Text + ".";
        }

        void Button_Clicked_percent(System.Object sender, System.EventArgs e)
        {
            double equally = Calculator.Calc(LableText.Text);
            double num = equally / 100;
            string v = num.ToString();
            LableText.Text = v;
        }
    }


}
