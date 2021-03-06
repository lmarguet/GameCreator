using System;
using System.Collections.Generic;
using System.Linq;
using GameCreator.Extensions;
using GameCreator.Features.TimeSettings;
using GraphQlClient.Core;
using UnityEngine;

namespace GameCreator.Config
{
    [CreateAssetMenu(fileName = "TimeSettingsConfig", menuName = "Config/TimeSettingsConfig")]
    public class TimeSettingsConfig : ScriptableObject
    {
        [Serializable]
        public struct TimeRenderConfig
        {
            public TimeOfTheDay timeOfTheDay;
            public Material Skybox;
            public GameObject LightPrefab;
        }

        [Serializable]
        public struct CityConfig
        {
            public string Name;
            public int GmtOffset; // TODO Needs daylight saving time solution
        }

        [SerializeField] GraphApi weatherApiReference;
        [SerializeField] string getCityQueryName;
        [SerializeField] CityConfig[] cities;
        [SerializeField] TimeRenderConfig[] timeRenderConfigs;
        [SerializeField] int realTimeRenderIntervalSeconds;

        public GraphApi WeatherApiReference => weatherApiReference;
        public string GetCityQueryName => getCityQueryName;
        public IEnumerable<CityConfig> Cities => cities;
        public int RealTimeRenderIntervalSeconds => realTimeRenderIntervalSeconds;

        public TimeRenderConfig GetTimeRenderConfig(TimeOfTheDay timeOfTheDay)
        {
            return timeRenderConfigs.Where(x => x.timeOfTheDay == timeOfTheDay).ToList().RandomElement();
        }

        public CityConfig GetCity(string city)
        {
            return cities.First(x => x.Name == city);
        }
    }
}