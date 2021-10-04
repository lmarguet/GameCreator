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
                Debug.Log(result);
                var json = JsonUtility.FromJson<WeatherRequestResult>(result);
                Debug.Log(json);
            }
        }
    }

}