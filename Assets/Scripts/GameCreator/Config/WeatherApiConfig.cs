using GraphQlClient.Core;
using UnityEngine;

namespace GameCreator.Config
{
    [CreateAssetMenu(fileName = "WeatherApiConfig", menuName = "Config/WeatherApiConfig")]
    public class WeatherApiConfig : ScriptableObject
    {

        [SerializeField] GraphApi apiReference;
        [SerializeField] string getCityQueryName;
        [SerializeField] string[] cities;

        public GraphApi ApiReference => apiReference;
        public string GetCityQueryName => getCityQueryName;
        public string[] Cities => cities;
    }
}