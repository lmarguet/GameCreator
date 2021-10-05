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
        public Temperature temperature;
        public Clouds clouds;
        public WeatherSummary summary;
    }

    [Serializable]
    public class WeatherSummary
    {
        public string title;
        public string description;
        public string icon;
    }

    [Serializable]
    public class Clouds
    {
        public string all;
    }

    [Serializable]
    public class Temperature
    {
        public string actual;
    }
}