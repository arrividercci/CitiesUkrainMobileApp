using CitiesUkrainMobileApp.Entities;
using SQLite;

namespace CitiesUkrainMobileApp;

public partial class CitiesPage : ContentPage
{
    private readonly SQLiteAsyncConnection connection;

    public CitiesPage()
    {
        InitializeComponent();
        this.connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "cities.db3"),
                SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);

        LoadCities();
    }

    // Завантажуємо міста з бази даних
    private async Task LoadCities()
    {
        var cities = await connection.Table<City>().ToListAsync();
        CitiesCollectionView.ItemsSource = cities;
    }

    private async void OnNavigateToRoute(object sender, EventArgs e)
    {
        var button = sender as Button;
        var city = button?.CommandParameter as City;

        if (city != null)
        {
            await Navigation.PushAsync(new RoutePage(city));
        }
    }


    // Метод для сортування за назвою
    private async void OnSortByNameClicked(object sender, EventArgs e)
    {
        var cities = await connection.Table<City>().ToListAsync();
        var sortedCities = cities.OrderBy(city => city.Name).Distinct().ToList();
        CitiesCollectionView.ItemsSource = null;
        CitiesCollectionView.ItemsSource = sortedCities;
    }

    // Метод для сортування за відстанню до Києва
    private async void OnSelectByDistanceAndPopulationClicked(object sender, EventArgs e)
    {
        var cities = await connection.Table<City>().ToListAsync();
        var sortedCities = cities.Where(city => city.DistanceToKyiv <= 500 && city.Population >= 500000).Distinct().ToList();
        CitiesCollectionView.ItemsSource = null;
        CitiesCollectionView.ItemsSource = sortedCities;
    }

    private async void OnSelectMaxAndMinDistanceClicked(object sender, EventArgs e)
    {
        var cities = await connection.Table<City>().ToListAsync();
        var cityWithMaxDistance = cities.OrderByDescending(c => c.DistanceToKyiv).FirstOrDefault();
        var cityWithMinDistance = cities.Where(c => c.Name != "Київ").OrderBy(c => c.DistanceToKyiv).FirstOrDefault();
        string message = $"Найбільша дистанція:\n" +
                         $"- Місто: {cityWithMaxDistance.Name}\n" +
                         $"- Відстань: {cityWithMaxDistance.DistanceToKyiv} км\n\n" +
                         $"Найменша дистанція:\n" +
                         $"- Місто: {cityWithMinDistance.Name}\n" +
                         $"- Відстань: {cityWithMinDistance.DistanceToKyiv} км";
        await DisplayAlert("Результати", message, "OK");
    }
}