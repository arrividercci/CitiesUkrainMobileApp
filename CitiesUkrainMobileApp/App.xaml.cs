using CitiesUkrainMobileApp.Entities;

namespace CitiesUkrainMobileApp
{
    public partial class App : Application
    {
        private readonly SqliteConnectionFactory connectionFactory;
        public App(SqliteConnectionFactory connectionFactory)
        {
            InitializeComponent();

            MainPage = new AppShell();

            this.connectionFactory = connectionFactory;
        }

        protected override async void OnStart()
        {
            var cities = new List<City>
            {
                new City { Name = "Київ", DistanceToKyiv = 0, Population = 2884000, Lat = 50.4501, Lng = 30.5234 },
                new City { Name = "Харків", DistanceToKyiv = 478, Population = 1439000, Lat = 49.9935, Lng = 36.2304 },
                new City { Name = "Одеса", DistanceToKyiv = 475, Population = 1012000, Lat = 46.4825, Lng = 30.7233 },
                new City { Name = "Дніпро", DistanceToKyiv = 391, Population = 967000, Lat = 48.4647, Lng = 35.0462 },
                new City { Name = "Донецьк", DistanceToKyiv = 693, Population = 909000, Lat = 48.0159, Lng = 37.8028 },
                new City { Name = "Запоріжжя", DistanceToKyiv = 516, Population = 728000, Lat = 47.8388, Lng = 35.1396 },
                new City { Name = "Львів", DistanceToKyiv = 540, Population = 721000, Lat = 49.8397, Lng = 24.0297 },
                new City { Name = "Кривий Ріг", DistanceToKyiv = 423, Population = 630000, Lat = 47.9105, Lng = 33.3918 },
                new City { Name = "Миколаїв", DistanceToKyiv = 482, Population = 480000, Lat = 46.9750, Lng = 31.9946 },
                new City { Name = "Маріуполь", DistanceToKyiv = 764, Population = 431000, Lat = 47.0951, Lng = 37.5413 },
                new City { Name = "Вінниця", DistanceToKyiv = 267, Population = 370000, Lat = 49.2331, Lng = 28.4682 },
                new City { Name = "Чернігів", DistanceToKyiv = 148, Population = 288000, Lat = 51.4982, Lng = 31.2893 },
                new City { Name = "Полтава", DistanceToKyiv = 342, Population = 286000, Lat = 49.5883, Lng = 34.5514 },
                new City { Name = "Черкаси", DistanceToKyiv = 193, Population = 279000, Lat = 49.4444, Lng = 32.0598 },
                new City { Name = "Херсон", DistanceToKyiv = 567, Population = 279000, Lat = 46.6354, Lng = 32.6169 },
                new City { Name = "Суми", DistanceToKyiv = 338, Population = 265000, Lat = 50.9077, Lng = 34.7981 },
                new City { Name = "Житомир", DistanceToKyiv = 137, Population = 264000, Lat = 50.2547, Lng = 28.6587 },
                new City { Name = "Рівне", DistanceToKyiv = 324, Population = 243000, Lat = 50.6199, Lng = 26.2516 },
                new City { Name = "Івано-Франківськ", DistanceToKyiv = 615, Population = 236000, Lat = 48.9226, Lng = 24.7097 },
                new City { Name = "Тернопіль", DistanceToKyiv = 422, Population = 225000, Lat = 49.5535, Lng = 25.5948 },
                new City { Name = "Кам'янське", DistanceToKyiv = 365, Population = 225000, Lat = 48.5117, Lng = 34.6020 },
                new City { Name = "Кропивницький", DistanceToKyiv = 298, Population = 224000, Lat = 48.5079, Lng = 32.2623 },
                new City { Name = "Луцьк", DistanceToKyiv = 396, Population = 217000, Lat = 50.7472, Lng = 25.3254 },
                new City { Name = "Ужгород", DistanceToKyiv = 808, Population = 115000, Lat = 48.6208, Lng = 22.2879 },
                new City { Name = "Чернівці", DistanceToKyiv = 542, Population = 265000, Lat = 48.2908, Lng = 25.9346 },
                new City { Name = "Біла Церква", DistanceToKyiv = 88, Population = 210000, Lat = 49.8098, Lng = 30.1121 },
                new City { Name = "Мелітополь", DistanceToKyiv = 558, Population = 150000, Lat = 46.8333, Lng = 35.3640 },
                new City { Name = "Бердянськ", DistanceToKyiv = 711, Population = 115000, Lat = 46.7667, Lng = 36.7836 },
                new City { Name = "Краматорськ", DistanceToKyiv = 616, Population = 148000, Lat = 48.7188, Lng = 37.5849 },
                new City { Name = "Сєвєродонецьк", DistanceToKyiv = 675, Population = 106000, Lat = 48.9484, Lng = 38.4911 },
                new City { Name = "Умань", DistanceToKyiv = 211, Population = 82500, Lat = 48.7544, Lng = 30.2211 },
                new City { Name = "Бровари", DistanceToKyiv = 25, Population = 109000, Lat = 50.5109, Lng = 30.7858 },
                new City { Name = "Ірпінь", DistanceToKyiv = 21, Population = 64000, Lat = 50.5218, Lng = 30.2504 },
                new City { Name = "Мукачево", DistanceToKyiv = 777, Population = 85500, Lat = 48.4432, Lng = 22.7186 },
                new City { Name = "Донецьк", DistanceToKyiv = 693, Population = 909000, Lat = 48.0159, Lng = 37.8028 },
                new City { Name = "Луганськ", DistanceToKyiv = 776, Population = 425000, Lat = 48.5732, Lng = 39.3006 }
            };
            var database = connectionFactory.CreateConnection();
            await database.DropTableAsync<City>();
            await database.CreateTableAsync<City>();
            await database.InsertAllAsync(cities);
            base.OnStart();
        }
    }
}
