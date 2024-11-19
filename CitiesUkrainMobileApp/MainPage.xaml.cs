using Map = Microsoft.Maui.Controls.Maps.Map;

namespace CitiesUkrainMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void CitiesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CitiesPage());
        }

        private async void FindPathButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            //await Navigation.PushAsync(/*FindPathPage()*/); // Перехід на сторінку "Знайти шлях"
        }

        private async void AboutButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoPage());
        }
    }
}
