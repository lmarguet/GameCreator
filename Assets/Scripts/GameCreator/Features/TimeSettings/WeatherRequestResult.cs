using System;

namespace GameCreator.Features.TimeSettings
{
    [Serializable]
    public class WeatherRequestResult
    {
        public WeatherRequestCityData data;
    }

    [Serializable]
    public class WeatherRequestCityData
    {
        public City getCityByName;
    }

    [Serializable]
    public class City
    {
        public string id;
        public string name;
        public Weather weather;
        public CityCoordinates coord;
    }

    [Serializable]
    public class CityCoordinates
    {
        public string lon;
        public string lat;
    }

    [Serializable]
    public class Weather
    {
        public string timestamp;
    }
}