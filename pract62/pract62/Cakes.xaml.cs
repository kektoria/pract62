using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pract62
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cakes : ContentPage
    {
        public List<Cake> cakes { get; set; }
        public Cakes()
        {
            InitializeComponent(); 

            cakes = new List<Cake>
            {
                new Cake {Name="Шоколадный бисквит на кипятке",
                    Category="Бисквитный",
                    Unit="Кг.",
                    Fats = 300,
                    Belky = 200,
                    Yglevody = 50,
                    Vitamins = 10,
                    Price = 1000,
                    Provider="Метрополис",
                    Count=10,
                    Recipe="Смешать все «сухое»: муку, сахар, соду, разрыхлитель и какао. Взбить яйца, добавить к ним молоко и растительное масло. Соединить, перемешать до однородности.Добавить стакан крутого кипятка, всё тщательно и быстро перемешать.Вылить тесто в форму.А дальше: или просто к чаю или кофе, или пропитать, промазать кремом.Выпекать в предварительно разогретой духовке при 160-180 градусах",
                    ImagePath="chocolate.jpg"},

                new Cake {Name="Торт Муравьиная горка с маком",
                    Category="Песочный",
                    Unit="Кг.",
                    Fats = 10,
                    Belky = 300,
                    Yglevody = 150,
                    Vitamins = 300,
                    Price = 600,
                    Provider="Кувертюр",
                    Count=5,
                    Recipe="Сливочное масло растереть с сахаром.Добавить яйцо и сметану, соль, соду, разрыхлитель и просеянную муку.Все перемешать и убрать в холодильник на время.Для крема взбить вареную сгущенку со сливочным маслом.Добавить в крем мак и перемешать.Тесто из холодильника и натереть на терке на противень и поставить в духовку разогретую до 180 на 20 минут.Перемешать и подать торт на стол.",
                    ImagePath = "sand.jpg"},

                new Cake {Name="Торт мороженное",
                    Category="Вафельный",
                    Unit="Кг.",
                    Fats = 500,
                    Belky = 300,
                    Yglevody = 100,
                    Vitamins = 100,
                    Price = 450,
                    Provider="Кусняшно",
                    Count=7.5,
                    Recipe="Печенье измельчить в блендере.Сливочное масло растопить, затем все смешать и перемешать.Форму для выпечки выстелить пищевой пленкой, выложить печенье и отправить в морозильник на 10 минут.Сливки взбить в плотную массу.В мороженое небольшими порциями добавлять взбитые сливки.В форму с коржом выложить взбитое мороженое со сливками и вернуть в морозильник.",
                    ImagePath = "vafel.jpg"},

                new Cake {Name="Торт Сахара",
                    Category="Твороженный",
                    Unit="Кг.",
                    Fats = 50,
                    Belky = 150,
                    Yglevody = 250,
                    Vitamins = 300,
                    Price = 300,
                    Provider="Хлебпром",
                    Count=1,
                    Recipe="Яйца взбиваем с сахаром.Добовляем охлажденное сливочное масло и муку перемешиваем и убираем в холодильник.Делим тесто и тонко раскатываем.Выпекаем коржи в духовке, разогретой до 200 градусов.Взбиваем творог, сливочное масло, сгущенку и сметану.Коржи смазываем творожным кремом и выкладываем один на другой.Даём торту пропитаться и можно подавать к столу.",
                    ImagePath = "tvorog.jpg"}
            };

            Label header = new Label
            {
                Text = "\r\r\r\r\r\rОнлайн кулинария\n(заказ и покупка тортов)",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.Blue,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontAttributes = FontAttributes.Bold,
            };

            ListView listView = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = cakes,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Name");
                    Binding companyBinding = new Binding { Path = "Price", StringFormat = "Цена торта {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "ImagePath");
                    return imageCell;
                })
            };
            listView.ItemTapped += OnItemTapped;
            this.Content = new StackLayout { Children = { header, listView, runningtitle, date, button } };
        }
        Cake selectedCake;
        public void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedCake = e.Item as Cake;
            if (selectedCake != null)
            {
                runningtitle.Text = $"Торт: {selectedCake.Name}";
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (selectedCake != null)
            {
                Navigation.PushAsync(new MainPage(selectedCake));
            }
            else
                DisplayAlert("Ошибка", "Выбери торт", "Ок");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (selectedCake != null)
            {
                Navigation.PushAsync(new Calculate(1, selectedCake.Price));
            }
            else
                DisplayAlert("Ошибка", "Выбери торт", "Ок");
        }
    }
}