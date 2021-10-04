using System.Threading.Tasks;
using GameCreator.Config;
using GraphQlClient.Core;
using Zenject;

namespace GameCreator.Features.DayTime
{
    public class WeatherApiService
    {
        [Inject] WeatherApiConfig apiConfig;

        public async Task<string> QueryCity(string city)
        {
            var apiReference = apiConfig.ApiReference;
            
            var getCityQuery = apiReference.GetQueryByName(apiConfig.GetCityQueryName, GraphApi.Query.Type.Query);
            getCityQuery.SetArgs(new { name = city });
            
            var request = await apiReference.Post(getCityQuery);
            return HttpHandler.FormatJson(request.downloadHandler.text);
        }
    }
}