using GraphQlClient.Core;
using UnityEngine;

namespace GameCreator.Config
{
    [CreateAssetMenu(fileName = "TimeSettingsConfig", menuName = "Config/TimeSettingsConfig")]
    public class TimeSettingsConfig : ScriptableObject
    {

        [SerializeField] GraphApi weatherApiReference;
        [SerializeField] string getCityQueryName;
        [SerializeField] string[] cities;

        public GraphApi WeatherApiReference => weatherApiReference;
        public string GetCityQueryName => getCityQueryName;
        public string[] Cities => cities;
    }
}