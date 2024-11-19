using CitiesUkrainMobileApp.Entities;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;
using System;
using System.Linq;
using System.Threading.Tasks;

using Map = Microsoft.Maui.Controls.Maps.Map;

namespace CitiesUkrainMobileApp;

public partial class RoutePage : ContentPage
{
    private readonly City _destinationCity;
        
    public RoutePage(City city)
    {
        InitializeComponent();
        _destinationCity = city;
        LoadRouteAsync();
    }

    private async Task LoadRouteAsync()
    {
        try
        {
            // �������� ���������� �����������
            var location = await Geolocation.GetLastKnownLocationAsync() ?? await Geolocation.GetLocationAsync();

            if (location == null)
            {
                await DisplayAlert("�������", "�� ������� �������� ���������������.", "��");
                return;
            }

            // ������ ������ �����������
            var userPin = new Pin
            {
                Label = "���� ���������������",
                Location = new Location(location.Latitude, location.Longitude),
                Type = PinType.Place
            };
            map.Pins.Add(userPin);

            // ������ ������ ����
            var cityPin = new Pin
            {
                Label = _destinationCity.Name,
                Location = new Location(_destinationCity.Lat, _destinationCity.Lng),
                Type = PinType.Place
            };
            map.Pins.Add(cityPin);

            // �������� �������� (Polyline)
            var routeLine = new Polyline
            {
                StrokeColor = Colors.Blue,
                StrokeWidth = 3
            };

            // ������ ����� ��������
            routeLine.Geopath.Add(new Location(location.Latitude, location.Longitude));
            routeLine.Geopath.Add(new Location(_destinationCity.Lat, _destinationCity.Lng));

            map.MapElements.Add(routeLine);

            // ������������ ������ ����������� �����
            SetMapView(location, _destinationCity);
        }
        catch (Exception ex)
        {
            await DisplayAlert("�������", $"���� ���� �� ���: {ex.Message}", "��");
        }
    }

    private void SetMapView(Location userLocation, City destinationCity)
    {
        // ���������� ������
        var centerLat = (userLocation.Latitude + destinationCity.Lat) / 2;
        var centerLng = (userLocation.Longitude + destinationCity.Lng) / 2;

        // ���������� ������
        var distance = Location.CalculateDistance(
            new Location(userLocation.Latitude, userLocation.Longitude),
            new Location(destinationCity.Lat, destinationCity.Lng),
            DistanceUnits.Kilometers);

        map.MoveToRegion(MapSpan.FromCenterAndRadius(
            new Location(centerLat, centerLng),
            Distance.FromKilometers(distance / 2 + 5)));
    }
}
