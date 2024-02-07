using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pract62
{
    public partial class MainPage : ContentPage
    {
        double Ves;
        int Price;

        public MainPage (Cake cake)
        {
            InitializeComponent();
            Info(cake);
        }

        public void Info (Cake cake)
        {
            
            picture.Source = cake.ImagePath;
            name.Text = "Название: " + cake.Name;
            category.Text = "Категория: " + cake.Category;
            unit.Text = "Единица измерения: " + cake.Unit;
            fats.Text = "Жиры: " + cake.Fats;
            belky.Text = "Белки " + cake.Belky;
            yglevody.Text = "Углеводы: " + cake.Yglevody;
            vitamins.Text = "Витамины: " + cake.Vitamins;
            price.Text = "Цена: " + cake.Price;
            count.Text = "В наличии: " + cake.Count;
            provider.Text = "Поставщик:  " + cake.Provider;
            recipe.Text = "Рецепт: " + cake.Recipe;
            Price = cake.Price;
            
        }

        private void next_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(entry.Text) <= 10 && double.Parse(entry.Text) >= 0.5)
                {
                    if (double.Parse(entry.Text) <= double.Parse(count.Text.Remove(0, count.Text.IndexOf(':') + 1)))
                    {
                        Ves = double.Parse(entry.Text);
                        Navigation.PushAsync(new Calculate(Ves, Price));
                    }

                    else
                        DisplayAlert("Предупреждение", "В наличии столько нет", "Ок");
                }

                else
                    DisplayAlert("Ограничение", "Вес должен быть от 0.5 до 10 кг.", "Ок");
            }

            catch
            {
                DisplayAlert("Предупреждение", "Введи количество кг. торта", "Ок");
            }
        }

        private void back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
