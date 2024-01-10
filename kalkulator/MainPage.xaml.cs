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
                isaction = true;
                next = true;
                if ((sender as Button).ClassId.Length == 1&&(sender as Button).ClassId!="=")
                    action = char.Parse((sender as Button).ClassId);
                else
                {
                    switch (action)
                    {
                        case '+':
                            ResultText.Text = (double.Parse(x) + double.Parse(y)).ToString();
                            break;
                        case '-':
                            ResultText.Text = (double.Parse(x) - double.Parse(y)).ToString();
                            break;
                        case '/':
                            ResultText.Text = (double.Parse(x) / double.Parse(y)).ToString();
                            break;
                        case 'x':
                            ResultText.Text = (double.Parse(x) * double.Parse(y)).ToString();
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
