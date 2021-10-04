using System.Threading.Tasks;
using GameCreator.Config;
using GraphQlClient.Core;
using UnityEngine;
using Zenject;

namespace GameCreator.Features.TimeSettings
{
    public class WeatherApiService
    {
        [Inject] TimeSettingsConfig apiConfig;

        public async Task<WeatherRequestResult> QueryCity(string city)
        {
            var apiReference = apiConfig.WeatherApiReference;

            var getCityQuery = apiReference.GetQueryByName(apiConfig.GetCityQueryName, GraphApi.Query.Type.Query);
            getCityQuery.SetArgs(new { name = city });

            var request = await apiReference.Post(getCityQuery);

            return JsonUtility.FromJson<WeatherRequestResult>(request.downloadHandler.text);
        }
    }
}