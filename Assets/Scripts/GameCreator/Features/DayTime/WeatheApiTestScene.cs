using GameCreator.Config;
using UnityEngine;
using Zenject;

namespace GameCreator.Features.DayTime
{
    public class WeatheApiTestScene : MonoBehaviour
    {
        [Inject] WeatherApiService weatherApiService;
        [Inject] WeatherApiConfig weatherApiConfig;

        async void Start()
        {
            foreach (var city in weatherApiConfig.Cities)
            {
                var result = await weatherApiService.QueryCity(city);
                Debug.Log(result);
                var json = JsonUtility.FromJson<WeatherRequestResult>(result);
                Debug.Log(json);
            }
        }
    }

}