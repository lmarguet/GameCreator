using System;

namespace GameCreator.Features.DayTime
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
    }

    [Serializable]
    public class Weather
    {
        public string timestamp;
    }
}