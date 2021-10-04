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

                var cityData = result.data.getCityByName;
                var latitude = double.Parse(cityData.coord.lat);
                var longitude = double.Parse(cityData.coord.lon);
                var convertedTime = TimeUtil.GetTimeForCoordinates(latitude, longitude);

                Debug.Log(cityData.name + " - " + convertedTime.TimeOfDay + " -  " + TimeUtil.GetTimeOfTheDay(convertedTime));
                
                
            }
        }
    }
}