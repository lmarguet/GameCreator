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
            public TimeOfDay TimeOfDay;
            public Material Skybox;
        }
        

        [SerializeField] GraphApi weatherApiReference;
        [SerializeField] string getCityQueryName;
        [SerializeField] string[] cities;
        [SerializeField] TimeRenderConfig[] timeRenderConfigs;

        public GraphApi WeatherApiReference => weatherApiReference;
        public string GetCityQueryName => getCityQueryName;
        public string[] Cities => cities;

        public TimeRenderConfig GetTimeRenderConfig(TimeOfDay timeOfDay)
        {
            return timeRenderConfigs.Where(x => x.TimeOfDay == timeOfDay).ToList().RandomElement();
        }
    }
}