using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace kalkulator {
    public partial class MainPage : ContentPage {
        string x = "", y = "";
        bool next = false;
        string action = null;
        double? result;
        public MainPage() {
            InitializeComponent();
            List<Button> buttons = Content.Children.OfType<Button>().ToList();
            foreach (var item in buttons) {
                item.Clicked += Button_Clicked;
                item.FontSize = 20;
            }
        }
        void Reset() {
            y = x = "";
            action = null;
            next = false;
            result = null;
        }
        private void Button_Clicked(object sender, EventArgs e) {
            string buttonText = (sender as Button).Text;
            string actionName = (sender as Button).ClassId;
            if (actionName != null) {
                if (actionName != "" && x == "")
                    x = result != null ? result.ToString() : "0";

                if (actionName == ",") {
                    if (!next && !x.Contains("."))
                        x = x.Length == 0 ? "0." : x + ".";
                    else if (next && !y.Contains("."))
                        y = y.Length == 0 ? "0." : y + ".";
                    UpperTextContent();
                    return;
                }
                if (actionName != "=") {
                    next = true;
                    action = (actionName);
                    //if (actionName != null && x == "" && next == true) {
                    //    x = "0";
                    //}
                    if (action != null && result != null) {
                        x = result.ToString();
                        y = "";
                        next = true;
                    }
                    switch (action) {
                        case "1/x":
                            result = 1 / double.Parse(x);
                            UpperText.Text = "1 / " + x.ToString();
                            ResultText.Text = result.ToString();
                            y = x = "";
                            action = null;
                            next = false;
                            return;
                        case "s":
                            result = Math.Sqrt(double.Parse(x));
                            ResultText.Text = result.ToString();
                            UpperText.Text = $"√{x}";
                            y = x = "";
                            action = null;
                            next = false;
                            return;
                        case "c":
                            ResultText.Text = "";
                            UpperText.Text = "";
                            Reset();
                            return;
                        default:
                            break;
                    }

                } else {
                    if (x == "" || y == "") {
                        result = double.Parse(x == "" ? y : x);
                        ResultText.Text = result.ToString();
                        y = x = "";
                        action = null;
                        next = false;
                        UpperTextContent();
                        return;
                    }

                    switch (action) {
                        case "+":
                            result = (double.Parse(x) + double.Parse(y));
                            break;
                        case "-":
                            result = (double.Parse(x) - double.Parse(y));
                            break;
                        case "/":
                            result = (double.Parse(x) / double.Parse(y));
                            break;
                        case "x":
                            result = (double.Parse(x) * double.Parse(y));
                            break;
                        case "^":
                            result = Math.Pow(double.Parse(x), double.Parse(y));
                            break;
                    }
                    ResultText.Text = result.ToString();
                    next = true;
                }
            } else {
                if (!next)
                    x += buttonText;
                else
                    y += buttonText;
            }
            UpperTextContent();



        }
        void UpperTextContent() {
            UpperText.Text = x + " " + action + " " + y;
        }
        void Result() {
            ResultText.Text = double.Parse(x).ToString();
        }
    }
}

