using System;
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
        }
        

        [SerializeField] GraphApi weatherApiReference;
        [SerializeField] string getCityQueryName;
        [SerializeField] string[] cities;
        [SerializeField] TimeRenderConfig[] timeRenderConfigs;

        public GraphApi WeatherApiReference => weatherApiReference;
        public string GetCityQueryName => getCityQueryName;
        public string[] Cities => cities;

        public TimeRenderConfig GetTimeRenderConfig(TimeOfTheDay timeOfTheDay)
        {
            return timeRenderConfigs.Where(x => x.timeOfTheDay == timeOfTheDay).ToList().RandomElement();
        }
    }
}