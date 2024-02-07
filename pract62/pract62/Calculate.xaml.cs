using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pract62
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculate : ContentPage
    {
        double _price, _ves;

        public Calculate(double Kg, double Price)
        {
            InitializeComponent();
            metr.Text = "Кол-во кг.: " + Kg;
            price.Text = "Цена за кг. торта: " + Price;
            _price = Price;
            _ves = Kg;
            Calculator(_price);
        }

        public void Calculator(double price)
        {
            double total_price = price;
            string switchs = "";
            if (switch1.IsToggled == true && switch2.IsToggled == false && switch3.IsToggled == false)
            {
                switchs = "1";
            }

            if (switch1.IsToggled == true && switch2.IsToggled == true && switch3.IsToggled == false)
            {
                switchs = "12";
            }

            if (switch1.IsToggled == true && switch2.IsToggled == true && switch3.IsToggled == true)
            {
                switchs = "123";
            }

            if (switch1.IsToggled == false && switch2.IsToggled == true && switch3.IsToggled == true)
            {
                switchs = "23";
            }

            if (switch1.IsToggled == false && switch2.IsToggled == false && switch3.IsToggled == true)
            {
                switchs = "3";
            }

            if (switch1.IsToggled == false && switch2.IsToggled == true && switch3.IsToggled == false)
            {
                switchs = "2";
            }

            if (switch1.IsToggled == true && switch2.IsToggled == false && switch3.IsToggled == true)
            {
                switchs = "13";
            }

            switch (switchs)
            {
                case "1":
                    total_price = (total_price + price * 0.4) * _ves;
                    break;

                case "2":
                    total_price = (total_price + price * 0.2) * _ves;
                    break;

                case "3":
                    total_price = (total_price + price * 0.1) * _ves;
                    break;

                case "12":
                    total_price = (total_price + price * 0.4 + price * 0.2) * _ves;
                    break;

                case "13":
                    total_price = (total_price + price * 0.4 + price * 0.1) * _ves;
                    break;

                case "123":
                    total_price = (total_price + price * 0.4 + price * 0.2 + price * 0.1) * _ves;
                    break;

                case "23":
                    total_price = (total_price + price * 0.2 + price * 0.1) * _ves;
                    break;

                default:
                    total_price = price * _ves;
                    break;
            }

            cost.Text = "Стоимость: " + total_price.ToString();
        }

        private void next_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PopAsync();
        }

        private void back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();

        }

        private void switch1_Toggled(object sender, ToggledEventArgs e)
        {
            Calculator(_price);
        }
    }
}