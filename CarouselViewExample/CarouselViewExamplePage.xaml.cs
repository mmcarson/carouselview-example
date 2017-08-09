using System.Collections.ObjectModel;
using CarouselView.FormsPlugin.Abstractions;
using Xamarin.Forms;

namespace CarouselViewExample
{
	public class Item
	{
		public string name { get; set; }
		public int id { get; set; }
        public ImageSource imgsrc { get; set; }
	}

    public partial class CarouselViewExamplePage : ContentPage
    {
        public CarouselViewExamplePage()
        {
            InitializeComponent();

			var carouselDataTemplate = new DataTemplate(() =>
			{
                var lbl = new Label
                {
                    BackgroundColor = Color.Red,
                    TextColor = Color.White,
					FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HeightRequest = 100,
                    WidthRequest = 200,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.EndAndExpand,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center					
                };
                lbl.SetBinding(Label.TextProperty, "name");

                var img = new Image
                {
                    HeightRequest = 100,
                    WidthRequest = 100,
                    VerticalOptions = LayoutOptions.StartAndExpand
                };
                img.SetBinding(Image.SourceProperty, "imgsrc");

				var labelSL = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
				};
				labelSL.Children.Add(lbl);
                labelSL.Children.Add(img);

                return labelSL;
			});

            var myCarousel = new CarouselViewControl
            {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
            };
            // i'm not actually using the 'id' field
            myCarousel.ItemsSource = new ObservableCollection<Item> { new Item(){name = "Clay", id = 1, imgsrc = ImageSource.FromUri(new System.Uri("https://pbs.twimg.com/profile_images/814155292778921986/RFwwHFm1_400x400.jpg"))}, new Item(){name = "AlexRainman", id = 2, imgsrc = ImageSource.FromUri(new System.Uri("https://pbs.twimg.com/profile_images/814155292778921986/RFwwHFm1_400x400.jpg"))} };
            myCarousel.ItemTemplate = carouselDataTemplate; //new DataTemplate (typeof(MyView));
			myCarousel.Position = 0; //default
			myCarousel.InterPageSpacing = 10;
			myCarousel.Orientation = CarouselViewOrientation.Horizontal;

			var sl = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
			};
            sl.Children.Add(myCarousel);

            Content = sl;
        }
    }


}
