using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace kalkulator
{
    public partial class MainPage : ContentPage
    {
        string x = "", y = "";
        bool next = false;
        char? action;
        double? result;
        public MainPage()
        {
            InitializeComponent();
            List<Button> buttons = Content.Children.OfType<Button>().ToList();
            foreach (var item in buttons)
            {
                item.Clicked += Button_Clicked;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string buttonText = (sender as Button).Text;
            bool isaction = false;
            if ((sender as Button).ClassId != null)
            {
                if ((sender as Button).ClassId == "-" && x == "")
                    x = "0";


                isaction = true;
                next = true;
                if ((sender as Button).ClassId.Length == 1&&(sender as Button).ClassId != "="&&x!="")
                {
                    action = char.Parse((sender as Button).ClassId);
                }
                else
                {
                    switch (action)
                    {
                        case '+':
                            result = (double.Parse(x) + double.Parse(y));
                            ResultText.Text = result.ToString();
                            break;
                        case '-':
                            result = (double.Parse(x) - double.Parse(y));
                            ResultText.Text = result.ToString();
                            break;
                        case '/':
                            result = (double.Parse(x) / double.Parse(y));
                            ResultText.Text = result.ToString();
                            break;
                        case 'x':
                            result = (double.Parse(x) * double.Parse(y));
                            ResultText.Text = result.ToString();
                            break;
                        case 'p':
                            result = Math.Pow(double.Parse(x) , double.Parse(y));
                            ResultText.Text = result.ToString();
                            break;
                        case 'c':
                            x = y = "";
                            action = null;
                            UpperText.Text = "";
                            next = false;
                            UpperText.Text = "";
                            ResultText.Text = "";
                            break;
                    }

                    x = y="";
                    action = null;
                    UpperText.Text = "";
                    next = false;
                }

            }
            if (isaction == false)
            {
                if (!next)
                    x += buttonText;
                else
                    y += buttonText;
            }

            UpperTextContent();
        }
        void UpperTextContent()
        {
            UpperText.Text = x + " " + action + " " + y;
        }
        void Result()
        {
            ResultText.Text = double.Parse(x).ToString();
        }
    }
}
