using System;
using GameCreator.Config;
using UnityEngine;
using Zenject;

namespace GameCreator.Features.TimeSettings
{
    public class WeatheApiTestScene : MonoBehaviour
    {
        [Inject] WeatherApiService weatherApiService;
        [Inject] TimeSettingsConfig timeSettingsConfig;

        async void Start()
        {
            foreach (var city in timeSettingsConfig.Cities)
            {
                var result = await weatherApiService.QueryCity(city);
                
                ;

                var timestamp = long.Parse(result.data.getCityByName.weather.timestamp);
                var time2 = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime.ToUniversalTime();
                
                Debug.Log(result.data.getCityByName.name + " - " + time2);
            }
        }
    }
}